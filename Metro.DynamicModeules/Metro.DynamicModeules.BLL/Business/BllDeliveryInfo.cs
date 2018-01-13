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
using Metro.DynamicModeules.Interfaces.Sys;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;

/*==========================================
 *   程序说明: DeliveryInfo的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/07/15 09:01:39
 *   最后修改: 2015/07/15 09:01:39
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.Business
{
    /// <summary>
    /// BllDeliveryInfo 提货信息
    /// </summary>
    public class BllDeliveryInfo : BllBaseBusiness
    {
        private IBridgeDeliveryInfo _Bridge = null;
         /// <summary>
         /// 构造器
         /// </summary>
         public BllDeliveryInfo()
         {
             _KeyFieldName = TblDeliveryInfo.__KeyName; //主键字段
             _SummaryTableName = TblDeliveryInfo.__TableName;//表名
             _Bridge = CreateBridge();
         }
         private IBridgeDeliveryInfo CreateBridge()
         {
             if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                 return new ADODirectDeliveryInfo().GetInstance();

             if (BridgeFactory.BridgeType == BridgeType.WebService)
                 return new WebServiceDeliveryInfo();

             return null;
         }
          /// <summary>
          ///根据单据号码和版本号获取版本历史记录
          /// </summary>
          public  DataSet GetBusinessLog(string docNo, string verNo)
          {
           //  DataSet ds = _Bridge.GetBusinessLog(docNo, verNo);
             return null;
          }

          /// <summary>
          ///根据单据号码取业务数据
          /// </summary>
          public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
          {
              DataSet ds = _Bridge.GetBusinessByKey(keyValue); 
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
               //summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
               //summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
               //summaryRow[BusinessCommonFields.FlagApp] = "Y";
               //string key = ConvertEx.ToString(summaryRow[TblDeliveryInfo.__KeyName]);
               //_Bridge.ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
          }

          /// <summary>
          ///新增一张业务单据
          /// </summary>
          public override void NewBusiness()
          {
              DataTable summaryTable = _CurrentBusiness.Tables[TblDeliveryInfo.__TableName];
              DataRow row = summaryTable.Rows.Add();     
              //row[TblDeliveryInfo.__KeyName] = "*自动生成*";
              //row[TblDeliveryInfo.VerNo] = "01";
              //row[TblDeliveryInfo.CreatedBy] = Loginer.CurrentUser.Account;
              //row[TblDeliveryInfo.CreationDate] = DateTime.Now;
              //row[TblDeliveryInfo.LastUpdatedBy] = Loginer.CurrentUser.Account;
              //row[TblDeliveryInfo.LastUpdateDate] = DateTime.Now;
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

          //public string FuzzySearchName
          //{
          //    get { throw new NotImplementedException(); }
          //}

          public DataTable FuzzySearch(string content)
          {
             return _Bridge.FuzzySearch(content);
          }

    }
}
