using ExpressionSerialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Linq;

namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    /// <summary>
    /// linq表达示可序列化
    /// </summary>
    public static class SerializeHelper
    {
        public static Expression<Func<T, TResult>> CreateExpression<T, TResult>(string expression, params object[] values)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            return System.Linq.Dynamic.DynamicExpression.ParseLambda<T, TResult>(expression, values);
        }

        public static XElement SerializeExpression(Expression predicate, IEnumerable<Type> knownTypes = null)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            var serializer = CreateSerializer(knownTypes);
            return serializer.Serialize(predicate);
        }

        public static XElement SerializeExpression<T, TResult>(Expression<Func<T, TResult>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            var knownTypes = new List<Type> { typeof(T) };
            var serializer = CreateSerializer(knownTypes);
            return serializer.Serialize(predicate);
        }

        public static Expression DeserializeExpression(XElement xmlExpression)
        {
            if (xmlExpression == null)
            {
                throw new ArgumentNullException("xmlExpression");
            }
            var serializer = CreateSerializer();
            return serializer.Deserialize(xmlExpression);
        }

        public static Expression<Func<T, TResult>> DeserializeExpression<T, TResult>(XElement xmlExpression)
        {
            if (xmlExpression == null)
            {
                throw new ArgumentNullException("xmlExpression");
            }
            try
            {
                var knownTypes = new List<Type> { typeof(T) };
                var serializer = CreateSerializer(knownTypes);
                return serializer.Deserialize<Func<T, TResult>>(xmlExpression);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public static Expression<Func<T, TResult>> DeserializeExpression<T, TResult>(XElement xmlExpression, IEnumerable<Type> knownTypes)
        {
            if (xmlExpression == null)
            {
                throw new ArgumentNullException("xmlExpression");
            }
            var serializer = CreateSerializer(knownTypes);
            return serializer.Deserialize<Func<T, TResult>>(xmlExpression);
        }

        private static ExpressionSerializer CreateSerializer(IEnumerable<Type> knownTypes = null)
        {
            if (knownTypes == null || !knownTypes.Any())
            {
                return new ExpressionSerializer();
            }
            var assemblies = new List<Assembly> { typeof(ExpressionType).Assembly, typeof(IQueryable).Assembly };
            knownTypes.ToList().ForEach(type => assemblies.Add(type.Assembly));
            var resolver = new TypeResolver(assemblies, knownTypes);
            var knownTypeConverter = new KnownTypeExpressionXmlConverter(resolver);
            var serializer = new ExpressionSerializer(resolver, new CustomExpressionXmlConverter[] { knownTypeConverter });
            return serializer;
        }
       
    }
}
