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

using Metro.DynamicModeules.BLL.Security;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Base;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq.Expressions;

namespace Metro.DynamicModeules.BLL
{
    /*
     数据字典缓存数据
     */
    public class DataDictCache : NotifyPropertyChanged
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

        #region 私有变量
        BllAuthorityItem _bllAuthItem = new BllAuthorityItem();
        BllMenu _bllMenu = new BllMenu();
        BllModules _bllModules = new BllModules();
        BllUser _bllUser = new BllUser();
        BllUserGroup _bllUserGroup = new BllUserGroup();
        BllUserGroupRole _bllGrpRole = new BllUserGroupRole();

        #endregion

        #region 2.数据表缓存数据属性定义

        /// <summary>
        /// 当前用户
        /// </summary>
        public tb_MyUser LoginUser
        {
            get
            {
                return _loginUser;
            }
            set
            {
                _loginUser = value;
                RaisePropertyChanged("LoginUser");
                DownloadBaseCacheData();
            }
        }
        private tb_MyUser _loginUser;
        /// <summary>
        /// 所有字典
        /// </summary>
        public ObservableCollection<tb_CommonDataDict> AllDataDicts
        {
            get
            {
                return _dataDicts;
            }
            set
            {
                _dataDicts = value;
                RaisePropertyChanged("AllDataDicts");
            }
        }
        ObservableCollection<tb_CommonDataDict> _dataDicts;

        ObservableCollection<tb_CommDataDictType> _commonDataDictTypes;
        /// <summary>
        /// 所有的字典类型
        /// </summary>
        private ObservableCollection<tb_CommDataDictType> AllCommonDataDictTypes
        {
            get
            {
                return _commonDataDictTypes;
            }
            set
            {
                _commonDataDictTypes = value;
                RaisePropertyChanged("AllCommonDataDictTypes");
            }
        }

        /// <summary>
        /// 公司资料
        /// </summary>
        public tb_CompanyInfo CompanyInfo
        {
            get
            {
                return _companyInfo;
            }
            set
            {
                _companyInfo = value;
                RaisePropertyChanged("CompanyInfo");
            }
        }
        tb_CompanyInfo _companyInfo;

        #endregion

        #region 权限相关的数据

        /// <summary>
        /// 所有按钮字典表 定义功能点, 每个功能点必须唯一，为2^N 次方
        /// </summary>
        public ObservableCollection<tb_MyAuthorityItem> AuthorityItems
        {
            get
            {
                return _authorityItems;
            }
            set
            {
                _authorityItems = value;
                RaisePropertyChanged("AuthorityItems");
            }
        }
        ObservableCollection<tb_MyAuthorityItem> _authorityItems;

        /// <summary>
        /// 当前用户的组权限
        /// </summary>
        public ObservableCollection<tb_MyUserGroupRole> LoginGroupRoles
        {
            get
            {
                return _loginGroupRoles;
            }
            set
            {
                _loginGroupRoles = value;
                RaisePropertyChanged("LoginGroupRoles");
            }
        }
        ObservableCollection<tb_MyUserGroupRole> _loginGroupRoles;


        /// <summary>
        /// 本系统的菜单及分配菜单的权限值
        /// </summary>
        public ObservableCollection<tb_MyMenu> LoginMenus
        {
            get
            {
                return _loginMenus;
            }
            set
            {
                _loginMenus = value;
                RaisePropertyChanged("LoginMenus");
            }
        }
        ObservableCollection<tb_MyMenu> _loginMenus;

        /// <summary>
        /// 要加载的所有用户模块
        /// </summary>
        public ObservableCollection<sys_Modules> Modules
        {
            get
            {
                return _modules;
            }
            set
            {
                _modules = value;
                RaisePropertyChanged("Modules");
            }
        }
        ObservableCollection<sys_Modules> _modules;

        /// <summary>
        /// 当前用户组
        /// </summary>
        public ObservableCollection<tb_MyUserGroup> LoginUserGroups
        {
            get
            {
                return _loginUserGroups;
            }
            set
            {
                _loginUserGroups = value;
                RaisePropertyChanged("LoginUserGroups");
            }
        }
        ObservableCollection<tb_MyUserGroup> _loginUserGroups;
        public List<tb_MyAuthorityByItem> AuthorityByItems { get; set; }

        #endregion

        /// <summary>
        /// 下载刷新该用户相关的缓存
        /// </summary>
        /// <param name="account"></param>
        public async void DownloadBaseCacheData()
        {   //获取当前用户组
            LoginUserGroups = await _bllUserGroup.GetGroupsByAccount(LoginUser.Account);
            //所有模块
            Expression<Func<sys_Modules, bool>> predicate = SerializeHelper.CreateExpression<sys_Modules, bool>("ModuleID>@0", new object[] { -1 });
            Modules = await _bllModules.GetSearchList(predicate);
            //所有子项
            //所有按钮
            Expression<Func<tb_MyAuthorityItem, bool>> predAuthorityItem = SerializeHelper.CreateExpression<tb_MyAuthorityItem, bool>("isid>@0", new object[] { -1 });
            AuthorityItems = await _bllAuthItem.GetSearchList(predAuthorityItem);
            AuthorityByItems = await _bllAuthItem.GetAllAuthItems();
        }

    }
}
