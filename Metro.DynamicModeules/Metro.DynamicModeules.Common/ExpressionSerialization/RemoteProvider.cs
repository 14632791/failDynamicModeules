// 源文件头信息：
// <copyright file="RemoteProvider.cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239




// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;


namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    /// <summary>
    ///   IQueryProvider that has a (remote) Web HTTPWCF service as a backing data source. (analagous to the RemoteTable class).
    /// </summary>
    public class RemoteProvider : QueryProvider
    {
        private readonly WebHttpClient<IQueryService> client;
        private readonly TypeResolver resolver;
        private readonly ExpressionSerializer serializer;
        private readonly StripQuoteVisitor visitor;

        public RemoteProvider(WebHttpClient<IQueryService> client)
        {
            this.client = client;
            visitor = new StripQuoteVisitor();
            resolver = new TypeResolver(assemblies: null, knownTypes: client.knownTypes ?? new Type[0]);
            CustomExpressionXmlConverter queryconverter = new QueryExpressionXmlConverter(creator: null, resolver: resolver);
            CustomExpressionXmlConverter knowntypeconverter = new KnownTypeExpressionXmlConverter(resolver);
            serializer = new ExpressionSerializer(resolver, new[] {queryconverter, knowntypeconverter});
        }

        public override string GetQueryText(Expression expression)
        {
            return GetType().FullName;
        }

        /// <summary>
        ///   This makes an asynchronous network request. Silverlight users can expect this call to return synchronously, but will need to call this from a thread separate from the main UI thread. (For example, enclose this method call within ThreadPool.QueueUserWorkItem.)
        /// </summary>
        /// <param name="e"> </param>
        /// <returns> </returns>
        public override object Execute(Expression e)
        {
            if (e.NodeType == ExpressionType.Call)
            {
                Type returnType, elementType;
                var m = ((MethodCallExpression)e);
                if (m.Arguments[0] is ConstantExpression)
                {
                    var cx = ((ConstantExpression)m.Arguments[0]);
                    elementType = ((IQueryable)cx.Value).ElementType;
                    if (typeof(IEnumerable<>).MakeGenericType(elementType).IsAssignableFrom(m.Method.ReturnType))
                    {
                        returnType = elementType.MakeArrayType(); //typeof(IEnumerable<>).MakeGenericType(elementType);
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Expected for {0} of Type {1}\n Return Type of {2}", (m.Arguments[0]),
                                                                  typeof(ConstantExpression), typeof(IEnumerable<>).MakeGenericType(elementType)));
                    }
                }
                else
                {
                    returnType = m.Method.ReturnType;
                }

                m = (MethodCallExpression)visitor.Visit(m);
                XElement x = serializer.Serialize(m);
                object result = client.SynchronousCall(svc => svc.ExecuteQuery(x), returnType);
                return result;
            }
            else
            {
                throw new ArgumentException("Exrpression expected: " + typeof(MethodCallExpression));
            }
        }

        #region Nested type: StripQuoteVisitor

        private class StripQuoteVisitor : ExpressionVisitor
        {
            protected override Expression VisitMethodCall(MethodCallExpression m)
            {
                if (m.Method.DeclaringType == typeof(Queryable) && m.Arguments.Count == 2
                    && (m.Arguments[1] is UnaryExpression || m.Arguments[1].NodeType == ExpressionType.Quote))
                {
                    var cx = (ConstantExpression)m.Arguments[0];
                    //VisitUnary((UnaryExpression)m.Arguments[1]);
                    Expression e = base.VisitMethodCall(m); //strip quotes
                    return e;
                }
                return m; //else do not modify.
            }

            protected override Expression VisitUnary(UnaryExpression u)
            {
                var lambda = (LambdaExpression)StripQuotes(u);
                return lambda;
            }

            private Expression StripQuotes(Expression e)
            {
                while (e.NodeType == ExpressionType.Quote)
                {
                    e = ((UnaryExpression)e).Operand;
                }
                return e;
            }
        }

        #endregion
    }
}