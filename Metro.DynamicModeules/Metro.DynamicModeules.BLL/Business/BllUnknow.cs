using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models;

namespace Metro.DynamicModeules.BLL.Business
{
    public class BllUnknow : BllBaseBusiness
    {
        public override void ApprovalBusiness(System.Data.DataRow summaryRow)
        {
            Msg.Warning("请实现功能！");
        }

        public override void ClearAppInfo(System.Data.DataRow summaryRow)
        {
            Msg.Warning("请实现功能！");
        }

        public override System.Data.DataSet CreateSaveData(System.Data.DataSet sourceData, Metro.DynamicModeules.Common.UpdateType currentType)
        {
            Msg.Warning("请实现功能！");
            return sourceData;
        }

        public override bool Delete(string keyValue)
        {
            Msg.Warning("请实现功能！");
            return true;
        }

        protected override System.Data.DataSet DoCreateTempData(System.Data.DataSet currentBusiness, string summaryTableName)
        {
            Msg.Warning("请实现功能！");
            return currentBusiness;
        }

        public override System.Data.DataTable GetAttachedFiles(string docNo)
        {
            Msg.Warning("请实现功能！");
            return new DataTable();
        }

        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            Msg.Warning("请实现功能！");
            return new DataSet();
        }

        public override bool IsApproved(DataRow summaryRow)
        {
            Msg.Warning("请实现功能！");
            return false;
        }

        public override void NewBusiness()
        {
            Msg.Warning("请实现功能！");
        }

        public override void NotifyUser()
        {
            Msg.Warning("请实现功能！");
        }

        public override SaveResult Save(DataSet saveData)
        {
            Msg.Warning("请实现功能！");
            return SaveResult.CreateDefault();
        }

        protected override void UpdateDetailCommonValue(DataTable detail)
        {
            Msg.Warning("请实现功能！");
        }

        //public override void WriteLog()
        //{
        //    Msg.Warning("请实现功能！");
        //}

        //public override void WriteLog(DataSet original, DataSet changes)
        //{
        //    Msg.Warning("请实现功能！");
        //}

        //public override void WriteLog(DataTable original, DataTable changes)
        //{
        //    Msg.Warning("请实现功能！");
        //}
        
    }
}
