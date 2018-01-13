///*************************************************************************/
///*
///* 文件名    ：BllNullObjectDataDict.cs    
///*
///* 程序说明  : 数据字典的空业务逻辑类．仅用于初始化实例．
///* 原创作者  ：陈刚
///* 
///* Copyright 2015 Metro.DynamicModeules software
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.BLL.Base;


namespace Metro.DynamicModeules.BLL.DataDict
{
    /// <summary>
    /// 数据字典的空业务逻辑类．仅用于初始化实例．
    /// </summary>
    public class BllNullObjectDataDict : BllBaseDataDict
    {
        public override bool CheckNoExists(string keyValue)
        {
            return false;
        }

        public override void CreateDataBinder(System.Data.DataRow sourceRow)
        {
            //
        }

        public override bool Delete(string keyValue)
        {
            return true;
        }

        public override System.Data.DataTable GetDataByKey(string keyValue)
        {
            return new DataTable();
        }

        public override DataTable GetSummaryData(bool resetCurrent)
        {
            return new DataTable();
        }

        public override bool Update(Metro.DynamicModeules.Common.UpdateType updateType)
        {
            return true;
        }
    }
}
