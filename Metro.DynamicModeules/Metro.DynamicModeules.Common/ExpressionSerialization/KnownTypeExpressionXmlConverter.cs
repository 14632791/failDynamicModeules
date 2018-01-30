// 源文件头信息：
// <copyright file="KnownTypeExpressionXmlConverter.cs">
// Copyright(c)2012-2012 EBOOOY.All rights reserved.
// CLR版本：4.0.30319.239




// 创建时间：2012/04/08 6:49
// 最后修改：2012/04/08 7:49
// </copyright>

using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;


namespace Metro.DynamicModeules.Common.ExpressionSerialization
{
    public class KnownTypeExpressionXmlConverter : CustomExpressionXmlConverter
    {
        private readonly TypeResolver resolver;

        public KnownTypeExpressionXmlConverter(TypeResolver @resolver)
        {
            this.resolver = @resolver;
        }

        ///<summary>
        ///  code originally in method ParseConstantFromElement(XElement xml, string elemName, Type expectedType)
        ///</summary>
        ///<param name="x"> </param>
        ///<param name="e"> </param>
        ///<returns> </returns>
        public override bool TryDeserialize(XElement x, out Expression e)
        {
            if (x.Name.LocalName == typeof(ConstantExpression).Name)
            {
                var element = x.Element("Type");
                if (element != null)
                {
                    Type serializedType = resolver.GetType(element.Value);
                    if (resolver.HasMappedKnownType(serializedType))
                    {
                        var xElement = x.Element("Value");
                        if (xElement != null)
                        {
                            string xml = xElement.Value;
                            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                            {
                                //if (typeof(IQueryable).IsAssignableFrom(expectedType) && IsIEnumerableOf(expectedType, knownType))
                                //{
                                //    dserializer = new DataContractSerializer(knownType.MakeArrayType(), this.resolver.knownTypes);
                                //    result = dserializer.ReadObject(ms);
                                //    result = Enumerable.ToArray(result);
                                //}					
                                DataContractSerializer dserializer = new DataContractSerializer(serializedType, resolver.knownTypes);
                                object instance = dserializer.ReadObject(ms);
                                e = Expression.Constant(instance);
                                return true;
                            }
                        }
                    }
                }
            }

            e = null;
            return false;
        }

        public override bool TrySerialize(Expression e, out XElement x)
        {
            //!Query`1 && !System.Linq.EnumerableQuery`1
            if (e.NodeType == ExpressionType.Constant && !typeof(IQueryable).IsAssignableFrom(e.Type))
            {
                var cx = (ConstantExpression)e;
                Type knownType;
                Type actualType = cx.Type;
                if (cx.Value != null && cx.Type != cx.Value.GetType())
                {
                    actualType = cx.Value.GetType();
                    //either convert Nullable`1 (cx.Type) to the actual ValueType
                    //or convert the actual ValueType to the Nullable`1
                    //UnaryExpression u = Expression.Convert(cx, cx.Type);
                    //LambdaExpression lambda = Expression.Lambda(u);
                    //Delegate fn = lambda.Compile();
                    //object result = fn.DynamicInvoke(new object[0]);
                    //cx = Expression.Constant(result);
                }
                if (resolver.HasMappedKnownType(actualType, out knownType))
                {
                    object instance = cx.Value;
                    var serializer = new DataContractSerializer(actualType, resolver.knownTypes);
                    using (var ms = new MemoryStream())
                    {
                        serializer.WriteObject(ms, instance);
                        ms.Position = 0;
                        var reader = new StreamReader(ms, Encoding.UTF8);
                        string xml = reader.ReadToEnd();
                        x = new XElement(typeof(ConstantExpression).Name, new XAttribute("NodeType", actualType), new XElement("Type", cx.Type),
                                         new XElement("Value", xml));

                        return true;
                    }
                }
            }

            x = null;
            return false;
            //if (typeof(IQueryable).IsAssignableFrom(instance.GetType()))
            //{
            //    if (typeof(Query<>).MakeGenericType(knownType).IsAssignableFrom(instance.GetType()))
            //    {
            //        return instance.ToString();
            //    }
            //    something = LinqHelper.CastToGenericEnumerable((IQueryable)instance, knownType);
            //    something = Enumerable.ToArray(something);
            //}
        }
    }
}