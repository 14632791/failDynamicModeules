using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.BLL.Business;
using Metro.DynamicModeules.Server.DataAccess.DalBusiness;
using Metro.DynamicModeules.Models.BusinessModels;
using Metro.DynamicModeules.Models.SystemModels;

/*==========================================
 *   程序说明: OrderDetail的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/06/17 03:05:07
 *   最后修改: 2015/06/17 03:05:07
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.Business
{
    /// <summary>
    /// BllOrderDetail
    /// </summary>
    public class BllOrderDetail : BllBaseBusiness
    {
        private IBridgeOrderDetail _Bridge = null;
        /// <summary>
        /// 构造器
        /// </summary>
        public BllOrderDetail()
        {
            _KeyFieldName = TblOrderDetail.__KeyName; //主键字段
            _SummaryTableName = TblOrderDetail.__TableName;//表名
           // _SaveVersionLog = false;//是否启用版本控制
            _Bridge = CreateBridge();
        }
        private IBridgeOrderDetail CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectOrderDetail().GetInstance();
            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceOrderDetail();
            return null;
        }
        /// <summary>
        ///根据单据号码和版本号获取版本历史记录
        /// </summary>
        //public override DataSet GetBusinessLog(string docNo, string verNo)
        //{
        //    DataSet ds = new dalOrderDetail(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);
        //    return ds;
        //}

        /// <summary>
        ///根据单据号码取业务数据
        /// </summary>
        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataSet ds = new DalOrderDetail(Loginer.CurrentUser).GetBusinessByKey(keyValue);
            this.SetNumericDefaultValue(ds); //设置预设值
            if (resetCurrent) _CurrentBusiness = ds; //保存当前业务数据的对象引用
            return ds;
        }

        /// <summary>
        ///删除单据
        /// </summary>
        public override bool Delete(string keyValue)
        {
            return new DalOrderDetail(Loginer.CurrentUser).Delete(keyValue);
        }

        /// <summary>
        ///检查单号是否存在
        /// </summary>
        public bool CheckNoExists(string keyValue)
        {
            return new DalOrderDetail(Loginer.CurrentUser).CheckNoExists(keyValue);
        }

        /// <summary>
        ///保存数据
        /// </summary>
        public override SaveResult Save(DataSet saveData)
        {
            return _Bridge.Update(saveData); //交给数据层处理     
           // return new dalOrderDetail(Loginer.CurrentUser).Update(saveData, this.OnChangeVersion); //交给数据层处理
        }

        /// <summary>
        ///审核单据
        /// </summary>
        public override void ApprovalBusiness(DataRow summaryRow)
        {
            summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
            summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
            summaryRow[BusinessCommonFields.FlagApp] = "Y";
            string key = ConvertEx.ToString(summaryRow[TblOrderDetail.__KeyName]);
            new DalOrderDetail(Loginer.CurrentUser).ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        /// <summary>
        ///新增一张业务单据
        /// </summary>
        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[TblOrderDetail.__TableName];
            DataRow row = summaryTable.Rows.Add();
            row[TblOrderDetail.__KeyName] = "*自动生成*";
            row[TblOrderDetail.CreatedBy] = Loginer.CurrentUser.Account;
            row[TblOrderDetail.CreationDate] = DateTime.Now;
            row[TblOrderDetail.LastUpdatedBy] = Loginer.CurrentUser.Account;
            row[TblOrderDetail.LastUpdateDate] = DateTime.Now;
        }

        /// <summary>
        ///创建用于保存的临时数据
        /// </summary>
        public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)
        {
            return null;
        }

        /// <summary>
        ///查询数据
        /// </summary>
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo)
        {
            return null;
        }

        /// <summary>
        ///获取报表数据
        /// </summary>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return null;
        }

        #region Business Log

        /// <summary>
        /// 写入日志
        /// </summary>
        //public override void WriteLog()
        //{
        //    string key = this.DataBinder.Rows[0][TblOrderDetail.__KeyName].ToString();//取单据号码
        //    DataSet dsOriginal = this.GetBusinessByKey(key, false); //取保存前的原始数据, 用于保存日志时匹配数据.
        //    DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //创建用于保存的临时数据
        //    this.WriteLog(dsOriginal, dsTemplate);//保存日志      
        //}

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="original">原始数据</param>
        /// <param name="changes">修改后的数据</param>
        //public override void WriteLog(DataTable original, DataTable changes) { }

        ///// <summary>
        ///// 写入日志
        ///// </summary>
        ///// <param name="original">原始数据</param>
        ///// <param name="changes">修改后的数据</param>
        //public override void WriteLog(DataSet original, DataSet changes)
        //{            
        //    try
        //    {
        //        string logID = Guid.NewGuid().ToString().Replace("-", ""); //本次日志ID
        //        IBridgeEditLogHistory logBridge = BllBusinessLog.CreateEditLogHistoryBridge();
        //        logBridge.WriteLog(logID, original.Tables[0], changes.Tables[0], TblOrderDetail.__TableName, TblOrderDetail.__KeyName, true); //主表
        //        //  logBridge.WriteLog(logID, original.Tables[1], changes.Tables[1], TblInOrder.__TableName, TblInOrder.__KeyName, false);//明细
        //    }
        //    catch
        //    {
        //        Msg.Warning("写入日志发生错误！");
        //    }
        //}

        #endregion
    }
}
