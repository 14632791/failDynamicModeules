﻿
///*************************************************************************/
///*
///* 文件名    ：BllBase.cs                                      
///* 程序说明  : 业务逻辑层基类
///* 原创作者  ：陈刚
///* 
///* Copyright 2015 Metro.DynamicModeules software
///**************************************************************************/
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Metro.DynamicModeules.BLL.Base
{
    /// <summary>
    /// 业务逻辑层基类
    /// </summary>
    public class BllBase<T> where T : class  //: ICommonServiceAsyncBase<T> 
    {

        string _controllerName;
        protected virtual string GetControllerName()
        {
            if (string.IsNullOrEmpty(_controllerName))
            {
                Type type = typeof(T);
                _controllerName = type.Name;
            }
            return _controllerName;
        }

        protected string GetApiUrl(string methodName)
        {
            return string.Format("{0}/{1}/{2}", Globals.WEBURL, GetControllerName(), methodName);
        }
        public async Task<object[]> Add(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return await WebRequestHelper.PostHttpAsync<object[]>(GetApiUrl("Add"), apiParams);
        }

        public async Task<bool> Add(T[] paramList, bool isSave = true)
        {
            var apiParams = new { paramList, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Add1"), apiParams);
        }

        public async Task<bool> Delete(bool isSave, object[] keyValues)
        {
            var apiParams = new { isSave, keyValues };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Delete"), apiParams);
        }

        public async Task<bool> Delete(bool isSave, T[] entities)
        {
            var apiParams = new { isSave, entities };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Delete1"), apiParams);
        }

        public async Task<bool> Delete(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Delete2"), apiParams);
        }

        public async Task<T> Find(object[] keyValues)
        {
            return await WebRequestHelper.PostHttpAsync<T>(GetApiUrl("Find"), keyValues);
        }

        public virtual async Task<ObservableCollection<T>> GetSearchList(Expression<Func<T, bool>> where)
        {
            XElement xmlPredicate = xmlPredicate = SerializeHelper.SerializeExpression(where);
            return await WebRequestHelper.PostHttpAsync<ObservableCollection<T>>(GetApiUrl("GetSearchList"), xmlPredicate);
        }
        public async Task<long> GetListCount(Expression<Func<T, bool>> where)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            return await WebRequestHelper.PostHttpAsync<long>(GetApiUrl("GetListCount"), xmlPredicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize">可默认为0，就按配置的数量来定</param>
        /// <param name="pageIndex">第一页从0开始</param>
        /// <returns></returns>
        public async Task<ObservableCollection<T>> GetSearchListByPage(Expression<Func<T, bool>> where, int pageSize=0, int pageIndex=0) //where TKey:struct
        {
            if (0 == pageSize)
            {
                pageSize = Globals.PageSize;
            }
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            var apiParams = new { xmlPredicate,pageSize, pageIndex };
            return await WebRequestHelper.PostHttpAsync<ObservableCollection<T>>(GetApiUrl("GetSearchListByPage"), apiParams);
        }

        public async Task<bool> Update(Expression<Func<T, bool>> where, Dictionary<string, object> dic, bool isSave = true)
        {
            XElement xmlPredicate = SerializeHelper.SerializeExpression(where);
            var apiParams = new { xmlPredicate, dic, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Update"), apiParams);
        }

        public async Task<bool> Update(T model, bool isSave = true)
        {
            var apiParams = new { model, isSave };
            return await WebRequestHelper.PostHttpAsync<bool>(GetApiUrl("Update"), apiParams);
        }

    }
}
