using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Server.DataAccess.DalBusiness;
using Metro.DynamicModeules.Models.SystemModels;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Models.BusinessModels;
using Metro.DynamicModeules.Common.Business;
using Metro.DynamicModeules.Interfaces.Sys;
using Metro.DynamicModeules.BLL.DataDict;

/*==========================================
 *   程序说明: Stowage的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/07/20 07:45:42
 *   最后修改: 2015/07/20 07:45:42
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.Business
{
    /// <summary>
    /// BllStowage
    /// </summary>
    public class BllStowage : BllBaseBusiness, IFuzzySearchSupportable
    {
        private IBridgeStowage _Bridge = null;
        private IBridgeStowage CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectStowage().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceStowage();

            return null;
        }
        /// <summary>
        /// 构造器
        /// </summary>
        public BllStowage()
        {
            _KeyFieldName = TblStowage.__KeyName; //主键字段
            _SummaryTableName = TblStowage.__TableName;//表名
            _Bridge = CreateBridge();
            // _SaveVersionLog = false;//是否启用版本控制
        }

        /// <summary>
        ///根据单据号码和版本号获取版本历史记录
        /// </summary>
        //public override DataSet GetBusinessLog(string docNo, string verNo)
        //{
        //    DataSet ds = new DalStowage(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);
        //    return ds;
        //}

        /// <summary>
        ///根据单据号码取业务数据
        /// </summary>
        public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
        {
            DataSet ds = _Bridge.GetBusinessByKey(keyValue); //new DalStowage(Loginer.CurrentUser).GetBusinessByKey(keyValue);
            this.SetNumericDefaultValue(ds); //设置预设值
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
            string key = ConvertEx.ToString(summaryRow[TblStowage.__KeyName]);
            _Bridge.ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
        }

        /// <summary>
        ///新增一张业务单据
        /// </summary>
        public override void NewBusiness()
        {
            DataTable summaryTable = _CurrentBusiness.Tables[TblStowage.__TableName];
            DataRow row = summaryTable.NewRow();
            row.BeginEdit();
            row[TblStowage.__KeyName] = "*自动生成*";
            //row[TblStowage.VerNo] = "01";
            //row[TblStowage.CreatedBy] = Loginer.CurrentUser.Account;
            //row[TblStowage.CreationDate] = DateTime.Now;
            //row[TblStowage.LastUpdatedBy] = Loginer.CurrentUser.Account;
            //row[TblStowage.LastUpdateDate] = DateTime.Now;
            row.EndEdit();
            summaryTable.Rows.Add(row);
        }

        /// <summary>
        ///创建用于保存的临时数据
        /// </summary>
        public override DataSet CreateSaveData(DataSet currentBusiness, UpdateType currentType)
        {
            this.UpdateDetailCommonValue(currentBusiness.Tables[TblInOrder.__TableName]); //更新明细表的公共字段数据
            this.UpdateDetailCommonValue(currentBusiness.Tables[TblDeliveryInfo.__TableName]); //更新明细表的公共字段数据
            return currentBusiness.Copy();
        }

        /// <summary>
        ///查询数据
        /// </summary>
        public DataTable GetSummaryByParam(string docNoFrom, string docNoTo, DateTime docDateFrom, DateTime docDateTo, int status = 2)
        {
            return _Bridge.GetSummaryByParam(docNoFrom, docNoTo, docDateFrom, docDateTo, status);
        }
        public DataTable GetSummaryByParam(string sqlStr,List<CustomSqlDbTypeModel> lstType)
        {
            return CommonData.GetSummaryByParam(sqlStr , lstType, "tb_Stowage").Tables[0];
        } 

        /// <summary>
        ///获取报表数据
        /// </summary>
        public DataSet GetReportData(string DocNoFrom, string DocNoTo, DateTime DateFrom, DateTime DateTo)
        {
            return null;
        }
        public DataSet GetReportData(string StNo, int reportEnum=1)
        {
            return _Bridge.GetReportData(StNo, reportEnum);
        }
        #region Business Log

      

        #endregion
        public bool Generate(string OrderNo, int iStatus = 2)
        {
            return _Bridge.Generate(OrderNo, iStatus);
        }

        public string FuzzySearchName
        {
            get { return "搜索产品资料"; }
        }

        /// <summary>
        /// 搜索主单号
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public DataTable FuzzySearch(string content)
        {
            return new BllInOrder().FuzzySearchInOrder(content);
        }
    }
}
