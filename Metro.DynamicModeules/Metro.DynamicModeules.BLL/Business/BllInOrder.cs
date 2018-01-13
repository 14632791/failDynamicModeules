using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Core.Log;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Server.DataAccess.DalBusiness;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.BLL.Business;
using Metro.DynamicModeules.BLL.DataDict;
using Metro.DynamicModeules.Models.SystemModels;
using Metro.DynamicModeules.Interfaces.Sys;
using Metro.DynamicModeules.Models.BusinessModels;
using System.Linq;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Common.Business;

/*==========================================
 *   程序说明: InOrder的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/06/16 01:41:11
 *   最后修改: 2015/06/16 01:41:11
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.Business
{
    /// <summary>
    /// BllInOrder
    /// </summary>
    public class BllInOrder : BllBaseBusiness, IFuzzySearchSupportable
    {
        private IBridgeInOrder _Bridge = null;
        /// <summary>
        /// 构造器
        /// </summary>
        public BllInOrder()
        {
            _KeyFieldName = TblInOrder.__KeyName; //主键字段
            _SummaryTableName = TblInOrder.__TableName;//表名
            // _SaveVersionLog = false;//是否启用版本控制
            _Bridge = CreateBridge();
            //实例化桥接功能
        }
        private IBridgeInOrder CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectIN().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebService_IN();

            return null;
        }
        /// <summary>
        ///根据单据号码和版本号获取版本历史记录
        /// </summary>
        public  DataSet GetBusinessLog(string docNo, string verNo)
        {
            //_Bridge.getb
            //DataSet ds = new dalInOrder(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);
            return null;
        }

        /// <summary>
        ///根据单据号码取业务数据
        /// </summary>
        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataSet ds = _Bridge.GetBusinessByKey(keyValue);
            this.SetNumericDefaultValue(ds); //设置预设值
            //DataTable tblDetail=ds.Tables[TblOrderDetail.__TableName].Copy();
            //var query = (from t1 in tblDetail.AsEnumerable()
            //             join t2 in DataDictCache.Cache.CommonDataCustomer.AsEnumerable()
            //                                                  on t1.Field<string>(TblOrderDetail.WarehouseCode) equals t2.Field<string>(TblCustomer.CustomerCode)
            //             select new { t1, Tel = t2.Field<string>(TblCustomer.Tel) });
            if (resetCurrent) _CurrentBusiness = ds; //保存当前业务数据的对象引用
            return ds;
        }

        /// <summary>
        ///删除单据
        /// </summary>
        public override bool Delete(string keyValue)
        {
            return _Bridge.Delete(keyValue);
        }

        /// <summary>
        ///检查单号是否存在
        /// </summary>
        public bool CheckNoExists(string keyValue)
        {
            return _Bridge.CheckNoExists(keyValue);
        }

        /// <summary>
        ///保存数据
        /// </summary>
        public override SaveResult Save(DataSet saveData)
        {
            return _Bridge.Update(saveData); //交给数据层处理     
        }

        /// <summary>
        ///审核单据
        /// </summary>
        public override void ApprovalBusiness(DataRow summaryRow)
        {
            summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
            summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
            summaryRow[BusinessCommonFields.FlagApp] = "Y";
            string key = ConvertEx.ToString(summaryRow[TblInOrder.__KeyName]);
            _Bridge.ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        /// <summary>
        ///新增一张业务单据
        /// </summary>
        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[TblInOrder.__TableName];
            DataRow row = summaryTable.NewRow();
            row.BeginEdit();
            row[TblInOrder.__KeyName] = "*自动生成*";
            // row[TblInOrder.VerNo] = "01";
            //row[TblInOrder.CreatedBy] = Loginer.CurrentUser.Account;
            //row[TblInOrder.CreationDate] = DateTime.Now;
            //row[TblInOrder.LastUpdatedBy] = Loginer.CurrentUser.Account;
            //row[TblInOrder.LastUpdateDate] = DateTime.Now;
            row.EndEdit();
            summaryTable.Rows.Add(row);
        }

        /// <summary>
        ///创建用于保存的临时数据,同时更新明细表的公共字段数据
        /// </summary>
        public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)
        {
            //if (DataBindRow.RowState != DataRowState.Unchanged)
            //{
            //    this.UpdateSummaryRowState(this.DataBindRow, currentType);
            //}
            ////创建用于保存的临时数据,里面包含主表数据
            //DataSet save = this.DoCreateTempData(currentBusiness, TblInOrder.__TableName);
            //if (save.Tables.Count > 0)
            //{
            //    DataTable summary = save.Tables[0];
            //    summary.Rows[0][BusinessCommonFields.LastUpdateDate] = DateTime.Now;
            //    summary.Rows[0][BusinessCommonFields.LastUpdatedBy] = Loginer.CurrentUser.Account;
            //}
           // DataTable detail = currentBusiness.Tables[TblOrderDetail.__TableName].Copy();
            this.UpdateDetailCommonValue(currentBusiness.Tables[TblOrderDetail.__TableName]); //更新明细表的公共字段数据
            this.UpdateDetailCommonValue(currentBusiness.Tables[TblDeliveryInfo.__TableName]);
            //save.Tables.Add(detail); //加入明细数据 
            return currentBusiness.Copy();
        }

        /// <summary>
        ///查询数据
        /// </summary>
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo,OrderStatus status=0)
        {
            return _Bridge.GetSummaryByParam(docNoFrom, docNoTo, docDateFrom, docDateTo, (int)status);
        }

        //protected override void SetDefault(DataTable data)
        //{
        //    //司机的设置默认值
        //    data.Columns[TblInOrder.IsDelete].DefaultValue = 0;
        //}

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
        //    base.WriteLog();
        //    //string key = this.DataBinder.Rows[0][TblInOrder.__KeyName].ToString();//取单据号码
        //    //DataSet dsOriginal = this.GetBusinessByKey(key, false); //取保存前的原始数据, 用于保存日志时匹配数据.
        //    //DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //创建用于保存的临时数据
        //    //this.WriteLog(dsOriginal, dsTemplate);//保存日志      
        //}

        ///// <summary>
        ///// 写入日志
        ///// </summary>
        ///// <param name="original">原始数据</param>
        ///// <param name="changes">修改后的数据</param>
        //public override void WriteLog(DataTable original, DataTable changes)
        //{
        //    try
        //    {
        //        string logID = Guid.NewGuid().ToString().Replace("-", ""); //本次日志ID
        //        IBridgeEditLogHistory logBridge = BllBusinessLog.CreateEditLogHistoryBridge();
        //        logBridge.WriteLog(logID, original, changes, TblInOrder.__TableName, TblInOrder.__KeyName, true); //主表
        //        //  logBridge.WriteLog(logID, original.Tables[1], changes.Tables[1], TblInOrder.__TableName, TblInOrder.__KeyName, false);//明细
        //    }
        //    catch
        //    {
        //        Msg.Warning("写入日志发生错误！");
        //    }
        //}

        ///// <summary>
        ///// 写入日志
        ///// </summary>
        ///// <param name="original">原始数据</param>
        ///// <param name="changes">修改后的数据</param>
        //public override void WriteLog(DataSet original, DataSet changes)
        //{
        //    WriteLog(original.Tables[0], changes.Tables[0]);
        //}

        /// <summary>
        /// 下单，就是改变订单状态为1 2015.7.10
        /// </summary>
        /// <param name="OrderNo">定车单号</param>
        /// <returns></returns>
        public bool Generate(string OrderNo,int iStatus=1)
        {
          return  _Bridge.Generate(OrderNo, iStatus);
        }

        #endregion

        #region IFuzzySearchSupportable Members

        public string FuzzySearchName
        {
            get { return "搜索产品资料"; }
        }

        public DataTable FuzzySearch(string content)
        {
            BllProduct Bll = new BllProduct();
            return Bll.FuzzySearch(content);
        }

        public DataTable FuzzySearchInOrder(string content)
        {
            return _Bridge.FuzzySearch(content);
        }
        #endregion
    }
}
