
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
    }
}
