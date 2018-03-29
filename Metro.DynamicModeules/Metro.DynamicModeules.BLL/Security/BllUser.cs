
///*************************************************************************/
///*
///* 文件名    ：BllUser.cs        
///
///* 程序说明  : 用户管理的业务逻辑层
///               
///* 原创作者  ：陈刚
///* Copyright 2015 Metro.DynamicModeules software
///*
///**************************************************************************/
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Metro.DynamicModeules.Models.Sys;
using System.Collections.ObjectModel;
using Metro.DynamicModeules.Common.ExpressionSerialization;

namespace Metro.DynamicModeules.BLL.Security
{
    /// <summary>
    /// 用户管理的业务逻辑层
    /// </summary>
    public class BllUser : BllBase<tb_MyUser>
    {
        protected override string GetControllerName()
        {
            return "MyUser";
        }

        /// <summary>
        /// 获取当前所有用户信息
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<tb_MyUser>> GetAllUsers()
        {
            string expression = "Account!=@0";
            object[] values = new object[] { "" };
            Expression<Func<tb_MyUser, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUser, bool>(expression, values);
            return await GetSearchList(predicate);
        }
    }
}
