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
        public tb_MyUser User { get; set; }
        /// <summary>
        /// 所有字典
        /// </summary>
        public ObservableCollection<tb_CommonDataDict> AllDataDicts { get; set; }

        /// <summary>
        /// 营业咒
        /// </summary>
        public ObservableCollection<tb_Person> Person
        {
            get; set;
        }



        /// <summary>
        /// 所有的字典类型
        /// </summary>
        private ObservableCollection<tb_CommDataDictType> CommonDataDictType { get; set; }


        /// <summary>
        /// 所有的按钮
        /// </summary>
        public ObservableCollection<tb_MyAuthorityItem> AuthorityItems { get; set; }
        #endregion

        //下载刷新缓存
        public void DownloadBaseCacheData()
        {
        }

    }
}
