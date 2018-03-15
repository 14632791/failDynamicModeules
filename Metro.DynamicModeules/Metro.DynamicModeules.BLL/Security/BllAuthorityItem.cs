
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

namespace Metro.DynamicModeules.BLL.Security
{
    /// <summary>
    /// 用户管理的业务逻辑层
    /// </summary>
    public class BllAuthorityItem : BllBase<tb_MyAuthorityItem>
    {
        protected override string GetControllerName()
        {
            return "AuthorityItem";
        }

        /// <summary>
        /// 获取该窗体下的所有BUTTON
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<tb_MyAuthorityItem>> GetAuthorityItems(int menuId)
        {
            return await WebRequestHelper.PostHttpAsync<ObservableCollection<tb_MyAuthorityItem>>(GetApiUrl("GetAuthorityItems"), menuId);
        }

        /// <summary>
        /// 获取所有的自定义按钮tb_MyAuthorityItem与模块子项tb_MyMenu之间的关系表
        /// </summary>
        /// <returns></returns>
        public async Task<List<tb_MyAuthorityByItem>> GetAllAuthItems()
        {
            return await WebRequestHelper.PostHttpAsync<List<tb_MyAuthorityByItem>>(GetApiUrl("GetAllItems"));
        }
    }
}
