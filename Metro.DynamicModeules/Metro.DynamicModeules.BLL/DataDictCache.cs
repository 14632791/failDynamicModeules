///*************************************************************************/
///*
///* 文件名    ：DataDictCache.cs      
///
///* 程序说明  : 数据字典缓存数据
///               
///* 原创作者  ：陈刚
///* Copyright 2015 Metro.DynamicModeules software
///*
///**************************************************************************/

using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;


namespace Metro.DynamicModeules.BLL
{
    /*
     数据字典缓存数据
     */
    public class DataDictCache
    {

        private DataDictCache() { } /*私有构造器,不允许外部创建实例*/

        #region 单例模式

        private static DataDictCache _instance = null;

        /// <summary>
        /// 缓存数据唯一实例
        /// </summary>
        public static DataDictCache Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataDictCache();
                }
                return _instance;
            }
        }
        #endregion


        #region 2.数据表缓存数据. 局域变易及属性定义

        /// <summary>
        /// 当前用户
        /// </summary>
        public tb_MyUser LoginUser { get; set; }

        /// <summary>
        /// 所有字典
        /// </summary>
        public ObservableCollection<tb_CommonDataDict> AllDataDicts { get; set; }

        
        /// <summary>
        /// 所有的字典类型
        /// </summary>
        private ObservableCollection<tb_CommDataDictType> AllCommonDataDictTypes { get; set; }


        #endregion

        #region 权限相关的数据

        /// <summary>
        /// 按钮字典表 定义功能点, 每个功能点必须唯一，为2^N 次方
        /// </summary>
        public ObservableCollection<tb_MyAuthorityItem> AuthorityItems { get; set; }


        /// <summary>
        /// 当前用户的组权限
        /// </summary>
        public ObservableCollection<tb_MyUserGroupRole> LoginGroupRoles { get; set; }

        /// <summary>
        /// 本系统的菜单及分配菜单的权限值
        /// </summary>
        public ObservableCollection<tb_MyMenu> Menus { get; set; }
              

        /// <summary>
        /// 所有模块
        /// </summary>
        public ObservableCollection<sys_Modules> Modules { get; set; }

        /// <summary>
        /// 所有用户组，一般不加载，只有在用户权限管理中才加载数据
        /// </summary>
        public ObservableCollection<tb_MyUserGroup> UserGroups { get; set; }

        /// <summary>
        /// 所有的用户信息，一般不加载，只有在用户权限管理中才加载数据
        /// </summary>
        public ObservableCollection<tb_MyUser> Users { get; set; }

        #endregion

        //下载刷新缓存
        public void DownloadBaseCacheData()
        {
        }

    }
}
