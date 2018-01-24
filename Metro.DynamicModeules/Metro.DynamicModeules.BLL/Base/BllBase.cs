///*************************************************************************/
///*
///* 文件名    ：BllBase.cs                                      
///* 程序说明  : 业务逻辑层基类
///* 原创作者  ：陈刚
///* 
///* Copyright 2015 Metro.DynamicModeules software
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interface.Service.Base;
using System.Linq.Expressions;
using Metro.DynamicModeules.BLL.Security;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.BLL.Base
{
    /// <summary>
    /// 业务逻辑层基类
    /// </summary>
    public class BllBase<T> : IServiceBase<T> where T : class
    {

        string _controllerName;
        protected string ControllerName
        {
            get
            {
                if (string.IsNullOrEmpty(_controllerName))
                {
                    Type type = typeof(T);
                    _controllerName = type.Name;
                }
                return _controllerName;
            }
        }
        private string GetApiUrl(string methodName)
        {
            return string.Format("{0}/{1}/{2}", GlobalData.WEBURL, ControllerName, methodName);
        }
        public object[] Add(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return WebRequestHelper.PostHttp<object[]>(GetApiUrl("Add"), apiParams);
        }

        public bool Add(IEnumerable<T> paramList, bool isSave = true)
        {
            var apiParams = new { paramList, isSave };
            return WebRequestHelper.PostHttp<bool>(GetApiUrl("Add"), apiParams);
        }

        public bool Commit(bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public bool Delete(bool isSave, object[] keyValues)
        {
            var apiParams = new { isSave, keyValues };
            return WebRequestHelper.PostHttp<bool>(GetApiUrl("Delete"), apiParams);
        }

        public bool Delete(bool isSave, IEnumerable<T> entities)
        {
            var apiParams = new { isSave, entities };
            return WebRequestHelper.PostHttp<bool>(GetApiUrl("Delete"), apiParams);
        }

        public bool Delete(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return WebRequestHelper.PostHttp<bool>(GetApiUrl("Delete"), apiParams);
        }

        public T Find(object[] keyValues)
        {
            return WebRequestHelper.PostHttp<T>(GetApiUrl("Find"), keyValues);
        }

        public async Task<IEnumerable<T>> GetSearchList(Expression<Func<T, bool>> where)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            return await WebRequestHelper.AsyncPostHttp<IEnumerable<T>>(GetApiUrl("GetSearchList"), xmlPredicate);
        }

        public IEnumerable<T> GetSearchListByPage<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> xmlOrderBy, int pageSize, int pageIndex, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public bool Update(Expression<Func<T, bool>> where, Dictionary<string, object> dic, bool isSave = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(T model, bool isSave = true)
        {
            throw new NotImplementedException();
        }
    }
}
