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
using Metro.DynamicModeules.Models.BusinessModels;
using Metro.DynamicModeules.Server.DataAccess.DalBusiness;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Server.DataAccess.DalSystem;

/*==========================================
 *   程序说明: Address的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/07/15 09:11:19
 *   最后修改: 2015/07/15 09:11:19
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.Business
{
    /// <summary>
    /// BllAddress
    /// </summary>
    public class BllAddress : BllBaseBusiness
    {
        private IBridgeAddress _Bridge = null;
        /// <summary>
        /// 构造器
        /// </summary>
        public BllAddress()
        {
            _KeyFieldName = TblAddress.__KeyName; //主键字段
            _SummaryTableName = TblAddress.__TableName;//表名
            _Bridge = this.CreateBridge();//实例化桥接功能
        }
        private IBridgeAddress CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADOAddress().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceAddress();
            return null;
        }

        /// <summary>
        ///根据单据号码和版本号获取版本历史记录
        /// </summary>
        //public override DataSet GetBusinessLog(string docNo, string verNo)
        //{
        //   DataSet ds = new DalAddress(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);
        //   return ds;
        //}

        /// <summary>
        ///根据单据号码取业务数据
        /// </summary>
        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataTable tbl = _Bridge.GetBusinessByKey(keyValue);
            this.SetNumericDefaultValue(tbl); //设置预设值
            DataSet data = ServerLibrary.TableToDataSet(tbl);
            if (resetCurrent) _CurrentBusiness = data;
            return data;
        }

        /// <summary>
        ///删除单据
        /// </summary>
        public override bool Delete(string keyValue)
        {
            return new DalAddress(Loginer.CurrentUser).Delete(keyValue);
        }

        /// <summary>
        ///检查单号是否存在
        /// </summary>
        public bool CheckNoExists(string keyValue)
        {
            return  _Bridge.CheckNoExists(keyValue);
        }

        /// <summary>
        ///保存数据
        /// </summary>
        public override SaveResult Save(DataSet saveData)
        {
           // DataSet data = saveData.GetChanges();
            return _Bridge.Update(saveData); //交给数据层处理
        }

        /// <summary>
        ///审核单据
        /// </summary>
        public override void ApprovalBusiness(DataRow summaryRow)
        {
            //summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
            //summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
            //summaryRow[BusinessCommonFields.FlagApp] = "Y";
            //string key = ConvertEx.ToString(summaryRow[TblAddress.__KeyName]);
            //new DalAddress(Loginer.CurrentUser).ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        /// <summary>
        ///新增一张业务单据
        /// </summary>
        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[TblAddress.__TableName];
            DataRow row = summaryTable.Rows.Add();
            //row[TblAddress.__KeyName] = "*自动生成*";
            //row[TblAddress.VerNo] = "01";
            //row[TblAddress.CreatedBy] = Loginer.CurrentUser.Account;
            //row[TblAddress.CreationDate] = DateTime.Now;
            //row[TblAddress.LastUpdatedBy] = Loginer.CurrentUser.Account;
            //row[TblAddress.LastUpdateDate] = DateTime.Now;
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
          return _Bridge.GetSummaryByParam(docNoFrom, docNoTo, docDateFrom, docDateTo);
        }

        /// <summary>
        ///获取报表数据
        /// </summary>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return null;
        }
        public DataTable FuzzySearch(string content)
        {
            return _Bridge.FuzzySearch(content).Tables[0];
        }
    }
}
