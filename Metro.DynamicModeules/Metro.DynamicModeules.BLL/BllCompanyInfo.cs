
///*************************************************************************/
///*
///* 文件名    ：BllCompanyInfo.cs      
///
///* 程序说明  : 公司资料管理业务逻辑层
///               
///* 原创作者  ：陈刚
///* Copyright 2015 Metro.DynamicModeules software
///*
///**************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;


using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models.SystemModels;


namespace Metro.DynamicModeules.BLL
{
    /// <summary>
    /// 公司资料管理业务逻辑层
    /// </summary>
    public class BllCompanyInfo : BllBaseDataDict
    {
        public BllCompanyInfo()
        {
            _KeyFieldName = TblCompanyInfo.CompanyCode;
            _SummaryTableName = TblCompanyInfo.__TableName;
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblCompanyInfo));
        }

        private bool _IsAdd = false;

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="updateType">操作类型</param>
        /// <returns></returns>
        public override bool Update(UpdateType updateType)
        {
            _SummaryTable.Rows[0][TblCompanyInfo.LastUpdateDate] = DateTime.Now;
            _SummaryTable.Rows[0][TblCompanyInfo.LastUpdatedBy] = Loginer.CurrentUser.Account;

            _SummaryTable.AcceptChanges();

            if (_IsAdd)
                _SummaryTable.Rows[0].SetAdded();
            else
                _SummaryTable.Rows[0].SetModified();

            DataSet ds = new DataSet();
            ds.Tables.Add(_SummaryTable.Copy());
            bool ret = _DataDictBridge.Update(ds); //调用DAL层更新数据

            if (ret)
            {
                _SummaryTable.AcceptChanges();
                _IsAdd = false;
            }

            return ret;
        }

        /// <summary>
        /// 获取公司资料
        /// </summary>
        public override DataTable GetSummaryData(bool resetCurrent)
        {
            _SummaryTable = _DataDictBridge.GetSummaryData();

            if (_SummaryTable.Rows.Count == 0)
            {
                DataRow row = _SummaryTable.NewRow();
                row[TblCompanyInfo.ISID] = "1";
                row[TblCompanyInfo.CreatedBy] = Loginer.CurrentUser.Account;
                row[TblCompanyInfo.CreationDate] = DateTime.Now;
                _SummaryTable.Rows.Add(row);
                _IsAdd = true;
            }
            else _IsAdd = false;

            return _SummaryTable;
        }
    }
}
