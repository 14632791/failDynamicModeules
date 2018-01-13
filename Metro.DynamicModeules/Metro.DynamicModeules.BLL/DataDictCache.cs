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

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Models.SystemModels;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Interfaces.Bridge;


namespace Metro.DynamicModeules.BLL
{
    /*
     数据字典缓存数据
     */
    public class DataDictCache
    {

        private DataDictCache() { } /*私有构造器,不允许外部创建实例*/

        #region 缓存数据唯一实例

        private static DataDictCache _Cache = null;

        /// <summary>
        /// 缓存数据唯一实例
        /// </summary>
        public static DataDictCache Cache
        {
            get
            {
                if (_Cache == null)
                {
                    _Cache = new DataDictCache();
                    _Cache.DownloadBaseCacheData();//下载基本数据                    
                }
                return _Cache;
            }
        }
        #endregion

        #region 外部使用的静态方法

        /// <summary>
        /// 刷新缓存数据
        /// </summary>
        public static void RefreshCache()
        {
            DataDictCache.Cache.DownloadBaseCacheData();
        }

        /// <summary>
        /// 刷新单个数据字典
        /// </summary>
        /// <param name="tableName">字典表名</param>
        public static void RefreshCache(string tableName)
        {
            DataTable cache = DataDictCache.Cache.GetCacheTableData(tableName);

            if (cache != null) //有客户窗体引用缓存数据时才更新
            {
                IBridgeDataDict bridge = BridgeFactory.CreateDataDictBridge(tableName, "");
                DataTable data = bridge.GetDataDictByTableName(tableName);
                cache.Rows.Clear();
                foreach (DataRow row in data.Rows) cache.ImportRow(row);
                cache.AcceptChanges();
            }
        }

        #endregion

        #region 2.数据表缓存数据. 局域变易及属性定义

        private DataSet _AllDataDicts = null;

        private DataTable _BusinessTables = null;
        public DataTable BusinessTables { get { return _BusinessTables; } }

        private DataTable _StockType = null;
        public DataTable StockType { get { return _StockType; } }

        private DataTable _Currency = null;
        public DataTable Currency { get { return _Currency; } }

        private DataTable _PayType = null;
        public DataTable PayType { get { return _PayType; } }

        private DataTable _User = null; //用户表
        public DataTable User { get { return _User; } }

        private DataTable _Person = null; //营销员
        public DataTable Person { get { return _Person; } }

        private DataTable _Storage = null; //仓库
        public DataTable Storage { get { return _Storage; } }

        private DataTable _Unit = null;
        public DataTable Unit { get { return _Unit; } }

        private DataTable _DepartmentData = null;
        public DataTable DepartmentData { get { return _DepartmentData; } }

        private DataTable _CustomerAttributes = null;
        public DataTable CustomerAttributes { get { return _CustomerAttributes; } }

        private DataTable _Bank = null;
        public DataTable Bank { get { return _Bank; } }

        private DataTable _CommonDataDictType = null;
        public DataTable CommonDataDictType { get { return _CommonDataDictType; } }

        private DataTable _Location = null;
        public DataTable Location { get { return _Location; } }

        private DataTable commonHireType = null;
        /// <summary>
        /// 订车类型
        /// </summary>
        public DataTable CommonHireType
        {
            get
            {
                if (commonHireType == null)
                {
                    commonHireType = (from q in DataDictCache.Cache.CommonDataDictOther.AsEnumerable() where q.Field<int>("DataType") == 6 select q).CopyToDataTable();
                }
                return commonHireType;
            }
        }

        private DataTable commonVehicleType = null;
        /// <summary>
        /// 车辆性质
        /// </summary>
        public DataTable CommonVehicleType
        {
            get
            {
                if (commonVehicleType == null)
                {
                    commonVehicleType = (from q in DataDictCache.Cache.CommonDataDictOther.AsEnumerable() where q.Field<int>("DataType") == 7 select q).CopyToDataTable();
                }
                return commonVehicleType;
            }
        }

        private DataTable commonOrderStatus = null;
        /// <summary>
        /// 订单状态
        /// </summary>
        public DataTable CommonOrderStatus
        {
            get
            {
                if (commonOrderStatus == null)
                {
                    commonOrderStatus = (from q in DataDictCache.Cache.CommonDataDictOther.AsEnumerable() where q.Field<int>("DataType") == 9 select q).CopyToDataTable();
                }
                return commonOrderStatus;
            }
        }
        /// <summary>
        /// 除了银行、部门之外的所有数据字典信息 2015.6.24 陈刚 增加
        /// </summary>
        public DataTable CommonDataDictOther { get; set; }

        /// <summary>
        /// 司机信息
        /// </summary>
        public DataTable CommonDataDictDriversInfo { get; set; }

        /// <summary>
        /// 车辆信息
        /// </summary>
        public DataTable CommonDataVehicleInfo { get; set; }

        /// <summary>
        /// 客户资料
        /// </summary>
        public DataTable CommonDataCustomer { get; set; }

        /// <summary>
        /// 司机与负责车辆关系
        /// </summary>
        public DataTable CommonDataDriversVehicleRelation { get; set; }
        #endregion


        public void DownloadBaseCacheData()
        {
            IBridgeDataDict bridge = BridgeFactory.CreateDataDictBridge("");

            //下载小字典表数据
            _AllDataDicts = bridge.DownloadDicts();

            //跟据存储过程返回数据表的顺序取
            _BusinessTables = _AllDataDicts.Tables[1];
            _User = _AllDataDicts.Tables[2];
            _Person = _AllDataDicts.Tables[3];
            _CustomerAttributes = _AllDataDicts.Tables[4];
            _Bank = _AllDataDicts.Tables[5];
            _CommonDataDictType = _AllDataDicts.Tables[6];
            _PayType = _AllDataDicts.Tables[7];
            _Currency = _AllDataDicts.Tables[8];
            _Location = _AllDataDicts.Tables[9];
            _DepartmentData = _AllDataDicts.Tables[10];
            CommonDataDictOther = _AllDataDicts.Tables[11];
            CommonDataDictDriversInfo = _AllDataDicts.Tables[12];
            CommonDataVehicleInfo = _AllDataDicts.Tables[13];
            CommonDataDriversVehicleRelation = _AllDataDicts.Tables[14];
            CommonDataCustomer = _AllDataDicts.Tables[15];
            //调用数据表名
            _AllDataDicts.Tables[1].TableName = SysBusinessTables.__TableName;
            _AllDataDicts.Tables[1].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[1].Columns[SysBusinessTables.__KeyName] };

            _AllDataDicts.Tables[2].TableName = TUser.__TableName;
            _AllDataDicts.Tables[2].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[2].Columns[TUser.__KeyName] };

            _AllDataDicts.Tables[3].TableName = TblPerson.__TableName;
            _AllDataDicts.Tables[3].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[3].Columns[TblPerson.__KeyName] };

            _AllDataDicts.Tables[4].TableName = TblCustomerAttribute.__TableName;
            _AllDataDicts.Tables[4].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[4].Columns[TblCustomerAttribute.__KeyName] };

            _AllDataDicts.Tables[5].TableName = "#Bank"; //TblCommDataDictType表的银行类别的记录
            _AllDataDicts.Tables[6].TableName = TblCommDataDictType.__TableName;
            _AllDataDicts.Tables[6].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[6].Columns[TblCommDataDictType.__KeyName] };

            _AllDataDicts.Tables[7].TableName = TblPayType.__TableName;
            _AllDataDicts.Tables[7].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[7].Columns[TblPayType.__KeyName] };

            _AllDataDicts.Tables[8].TableName = TblCurrency.__TableName;
            _AllDataDicts.Tables[8].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[8].Columns[TblCurrency.__KeyName] };

            _AllDataDicts.Tables[9].TableName = TblLocation.__TableName;
            _AllDataDicts.Tables[9].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[9].Columns[TblLocation.__KeyName] };

            _AllDataDicts.Tables[10].TableName = "#Dept"; //TblCommDataDictType表的部门类别的记录
            _AllDataDicts.Tables[11].TableName = "tb_CommonDataDict"; //

            _AllDataDicts.Tables[12].TableName = "tb_DriversInfo"; //
            _AllDataDicts.Tables[12].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[12].Columns[TblDriversInfo.__KeyName] };

            _AllDataDicts.Tables[13].TableName = "tb_VehicleInfo"; //
            _AllDataDicts.Tables[13].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[13].Columns[TblVehicleInfo.__KeyName] };

            _AllDataDicts.Tables[14].TableName = "tb_DriversVehicleRelation"; //
            _AllDataDicts.Tables[14].PrimaryKey = new DataColumn[] {_AllDataDicts.Tables[14].Columns["Id"]};

            _AllDataDicts.Tables[15].TableName = "tb_Customer"; //
            _AllDataDicts.Tables[15].PrimaryKey = new DataColumn[] { _AllDataDicts.Tables[15].Columns[TblCustomer.__KeyName] };
        }

        /// <summary>
        /// 跟据表名取数据表实例
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <returns></returns>
        private DataTable GetCacheTableData(string tableName)
        {
            foreach (DataTable dt in _AllDataDicts.Tables)
            {
                if (dt.TableName.ToUpper() == tableName.ToUpper()) return dt;
            }

            DataTable cache = null;
            //if (tableName == TblCommDataDictType.__TableName) cache = _CommonDataDictType;            
            return cache;
        }

        /// <summary>
        ///删除字典数据某一行数据
        /// </summary>
        /// <param name="tableName">字典表名</param>
        /// <param name="keyField">主键</param>
        /// <param name="key">主键值</param>
        public void DeleteCacheRow(string tableName, string keyField, string key)
        {
            DataTable cach = this.GetCacheTableData(tableName);
            if (cach != null)
            {
                DataRow[] rows = cach.Select(keyField + "='" + key + "'");
                if (rows.Length > 0)
                    cach.Rows.Remove(rows[0]);
                cach.AcceptChanges();
            }
        }
    }
}
