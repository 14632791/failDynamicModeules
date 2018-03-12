///*************************************************************************/
///*
///* 文件名    ：MenuType.cs                                 
///* 程序说明  : 菜单类型定义
///* 原创作者  ：陈刚
///* 
///* 
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Metro.DynamicModeules.Models.Sys;

namespace Metro.DynamicModeules.Common
{
    

    /// <summary>
    /// 菜单标记(Tag)
    /// </summary>
    public class MenuItemTag
    {
        private MenuType _type;
        private int _formAuthorities;
        private int _moduleID;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="type">菜单类型</param>
        /// <param name="moduleID">模块编号</param>
        /// <param name="formAuthorities">窗体的可用权限</param>
        public MenuItemTag(MenuType type, int moduleID, int formAuthorities)
        {
            _type = type;
            _moduleID = moduleID;
            _formAuthorities = formAuthorities;
        }

        /// <summary>
        /// 菜单类型
        /// </summary>
        public MenuType MenuType { get { return _type; } }

        /// <summary>
        /// 模块编号
        /// </summary>
        public int ModuleID { get { return _moduleID; } }

        /// <summary>
        /// 窗体的可用权限
        /// </summary>
        public int FormAuthorities { get { return _formAuthorities; } }
    }

}

