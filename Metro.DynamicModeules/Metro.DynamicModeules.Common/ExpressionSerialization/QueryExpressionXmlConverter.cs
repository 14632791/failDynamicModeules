// 源文件头信息：
// <copyright file="QueryExpressionXmlConverter.cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239




// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;


namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    public class QueryExpressionXmlConverter : CustomExpressionXmlConverter
    {
        private readonly QueryCreator _creator;
        private readonly TypeResolver _resolver;

        public QueryExpressionXmlConverter(QueryCreator @creator = null, TypeResolver resolver = null)
        {
            _creator = @creator;
            _resolver = resolver;
        }


        /// <summary>
        ///   Upon deserialization replace the Query (IQueryable) in the Expression tree with a new Query that has a different ConstantExpression. Re-create the Query, but with a different server-side IQueryProvider. For IQueryProvder, we just create a Linq.EnumerableQuery`1. Need both a working IQueryProvider and a new Query with ConstantExpression equal to actual data.
        /// </summary>
        /// <param name="expressionXml"> </param>
        /// <param name="e"> </param>
        /// <returns> </returns>
        public override bool TryDeserialize(XElement expressionXml, out Expression e)
        {
            if (_creator == null || _resolver == null)
            {
                throw new InvalidOperationException(string.Format("{0} and {1} instances are required for deserialization.", typeof(QueryCreator),
                                                                  typeof(TypeResolver)));
            }

            if (expressionXml.Name.LocalName == "Query")
            {
                Type elementType = _resolver.GetType(expressionXml.Attribute("elementType").Value);
                dynamic query = _creator.CreateQuery(elementType);
                e = Expression.Constant(query);
                return true;
            }
            e = null;
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="e"> </param>
        /// <param name="x"> </param>
        /// <returns> </returns>
        public override bool TrySerialize(Expression e, out XElement x)
        {
            if (e.NodeType == ExpressionType.Constant && typeof(IQueryable).IsAssignableFrom(e.Type))
            {
                Type elementType = ((IQueryable)((ConstantExpression)e).Value).ElementType;
                if (typeof(Query<>).MakeGenericType(new[] {elementType}) == e.Type)
                {
                    x = new XElement("Query", new XAttribute("elementType", elementType.FullName));
                    return true;
                }
            }
            x = null;
            return false;
        }
    }


    public abstract class CustomExpressionXmlConverter
    {
        public abstract bool TryDeserialize(XElement expressionXml, out Expression e);

        public abstract bool TrySerialize(Expression expression, out XElement x);
    }
}