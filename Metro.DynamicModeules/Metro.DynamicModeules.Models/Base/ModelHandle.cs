using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Metro.DynamicModeules.Models
{
    public static class ModelHandle
    {
        /// <summary>
        /// 深度copy 2018.1.25
        /// </summary>
        /// <param name="realObject"></param>
        /// <returns></returns>
        public static T CloneModel<T>(this T realObject) where T : class
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, realObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }
        /// <summary>
        /// 比较--两个类型一样的实体类对象的值
        /// </summary>
        /// <param name="oneT"></param>
        /// <returns></returns>
        public static bool CompareModel<T>(this T oneT, T twoT) where T : class
        {
            bool result = true;//两个类型作比较时使用,如果有不一样的就false
            Type typeOne = oneT.GetType();
            Type typeTwo = twoT.GetType();
            //如果两个T类型不一样  就不作比较
            if (!typeOne.Equals(typeTwo)) { return false; }
            PropertyInfo[] pisOne = typeOne.GetProperties(); //获取所有公共属性(Public)
            PropertyInfo[] pisTwo = typeTwo.GetProperties();
            //如果长度为0返回false
            if (pisOne.Length <= 0 || pisTwo.Length <= 0)
            {
                return false;
            }
            //如果长度不一样，返回false
            if (!(pisOne.Length.Equals(pisTwo.Length))) { return false; }
            //遍历两个T类型，遍历属性，并作比较
            for (int i = 0; i < pisOne.Length; i++)
            {
                //获取属性名
                string oneName = pisOne[i].Name;
                string twoName = pisTwo[i].Name;
                //获取属性的值
                object oneValue = pisOne[i].GetValue(oneT, null);
                object twoValue = pisTwo[i].GetValue(twoT, null);
                //比较,只比较值类型
                if ((pisOne[i].PropertyType.IsValueType || pisOne[i].PropertyType.Name.StartsWith("String"))
                    && (pisTwo[i].PropertyType.IsValueType || pisTwo[i].PropertyType.Name.StartsWith("String")))
                {
                    if (oneName.Equals(twoName))
                    {
                        if (oneValue == null)
                        {
                            if (twoValue != null)
                            {
                                result = false;
                                break; //如果有不一样的就退出循环
                            }
                        }
                        else if (oneValue != null)
                        {
                            if (twoValue != null)
                            {
                                if (!oneValue.Equals(twoValue))
                                {
                                    result = false;
                                    break; //如果有不一样的就退出循环
                                }
                            }
                            else if (twoValue == null)
                            {
                                result = false;
                                break; //如果有不一样的就退出循环
                            }
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    //如果对象中的属性是实体类对象，递归遍历比较
                    bool b = CompareModel(oneValue, twoValue);
                    if (!b) { result = b; break; }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取实体entity的主键
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static object[] GetPrimaryKey<T>(this T entity) where T : class
        {
            ArrayList keys = new ArrayList();
            // Get entity's key name
            Type entityType = typeof(T);
            PropertyInfo[] props = entityType.GetProperties();
            foreach (var prop in props)
            {
                var attributes = prop.GetCustomAttributes(typeof(KeyAttribute), false).FirstOrDefault()
                    as KeyAttribute;
                if (attributes != null)
                {
                    var key = entityType.GetProperty(prop.Name).GetValue(entity, null);//获取字段值，你的类C.n是字段，不是属性
                    keys.Add(key);
                    //var v2 = entityType.GetProperty(prop.Name).GetValue(entity, null);//获取属性值
                }
            }
            return keys.ToArray();
        }

        /// <summary>
        /// 获取当前的表名
        /// </summary>
        /// <returns></returns>
        public static string GetTableName<T>() where T : class
        {
            string name = typeof(T).GetAttributeValue((TableAttribute ta) => ta.Name);
            if (string.IsNullOrEmpty(name))
            {
                Type type = typeof(T);
                name = type.Name;
            }
            return name;
        }

        static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector)
          where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }
    }
}
