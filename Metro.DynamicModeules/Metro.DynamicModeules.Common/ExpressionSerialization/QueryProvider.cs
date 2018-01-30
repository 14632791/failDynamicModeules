// 源文件头信息：
// <copyright file="QueryProvider.cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239




// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Resolver = ExpressionSerialization.TypeResolver;


namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    public abstract class QueryProvider : IQueryProvider
    {
        #region IQueryProvider Members

        IQueryable<TS> IQueryProvider.CreateQuery<TS>(Expression expression)
        {
            return new Query<TS>(this, expression);
        }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            Type elementType = Resolver.GetElementType(expression.Type);
            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(Query<>).MakeGenericType(elementType), new object[] {this, expression});
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        TS IQueryProvider.Execute<TS>(Expression expression)
        {
            return (TS)Execute(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            return Execute(expression);
        }

        #endregion

        public abstract string GetQueryText(Expression expression);

        public abstract object Execute(Expression expression);
    }
}