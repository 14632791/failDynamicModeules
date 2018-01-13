using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using HTX.Models;
using HTX.Common;
using HTX.Core.Interfaces;
using HTX.Server.DataAccess;
using HTX.Core;

/*==========================================
 *   程序说明: CEB301MessageHead的业务逻辑层
 *   作者姓名: 鸿泰信 www.HTX.com
 *   创建日期: 2015/08/02 09:45:42
 *   最后修改: 2015/08/02 09:45:42
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.HTX.com
 *==========================================*/

namespace HTX.Business
{
    /// <summary>
    /// BllCEB301MessageHead
    /// </summary>
    public class BllCEB301MessageHead : bllBaseBusiness
    {
         /// <summary>
         /// 构造器
         /// </summary>
         public BllCEB301MessageHead()
         {
             _KeyFieldName = TblCEB301MessageHead.__KeyName; //主键字段
             _SummaryTableName = TblCEB301MessageHead.__TableName;//表名
             _SaveVersionLog = false;//是否启用版本控制
         }

          /// <summary>
          ///根据单据号码和版本号获取版本历史记录
          /// </summary>
          public override DataSet GetBusinessLog(string docNo, string verNo)
          {
             DataSet ds = new DalCEB301MessageHead(Loginer.CurrentUser).GetBusinessLog(docNo, verNo);
             return ds;
          }

          /// <summary>
          ///根据单据号码取业务数据
          /// </summary>
          public override DataSet GetBusinessByKey(string keyValue, bool resetCurrent)
          {
              DataSet ds = new DalCEB301MessageHead(Loginer.CurrentUser).GetBusinessByKey(keyValue); 
              this.SetNumericDefaultValue(ds); //设置预设值
              if (resetCurrent) _CurrentBusiness = ds; //保存当前业务数据的对象引用
              return ds;
           }

          /// <summary>
          ///删除单据
          /// </summary>
          public override bool Delete(string keyValue)
          {
              return new DalCEB301MessageHead(Loginer.CurrentUser).Delete(keyValue);
          }

          /// <summary>
          ///检查单号是否存在
          /// </summary>
          public bool CheckNoExists(string keyValue)
          {
              return new DalCEB301MessageHead(Loginer.CurrentUser).CheckNoExists(keyValue);
          }

          /// <summary>
          ///保存数据
          /// </summary>
          public override SaveResult Save(DataSet saveData)
          {
              return new DalCEB301MessageHead(Loginer.CurrentUser).Update(saveData, this.OnChangeVersion); //交给数据层处理
          }

          /// <summary>
          ///审核单据
          /// </summary>
          public override void ApprovalBusiness(DataRow summaryRow)
          {
               summaryRow[BusinessCommonFields.AppDate] = DateTime.Now;
               summaryRow[BusinessCommonFields.AppUser] = Loginer.CurrentUser.Account;
               summaryRow[BusinessCommonFields.FlagApp] = "Y";
               string key = ConvertEx.ToString(summaryRow[TblCEB301MessageHead.__KeyName]);
               new DalCEB301MessageHead(Loginer.CurrentUser).ApprovalBusiness(key, "Y", Loginer.CurrentUser.Account, DateTime.Now);
          }

          /// <summary>
          ///新增一张业务单据
          /// </summary>
          public override void NewBusiness()
          {
              DataTable summaryTable = _CurrentBusiness.Tables[TblCEB301MessageHead.__TableName];
              DataRow row = summaryTable.Rows.Add();     
              //row[TblCEB301MessageHead.__KeyName] = "*自动生成*";
              //row[TblCEB301MessageHead.VerNo] = "01";
              //row[TblCEB301MessageHead.CreatedBy] = Loginer.CurrentUser.Account;
              //row[TblCEB301MessageHead.CreationDate] = DateTime.Now;
              //row[TblCEB301MessageHead.LastUpdatedBy] = Loginer.CurrentUser.Account;
              //row[TblCEB301MessageHead.LastUpdateDate] = DateTime.Now;
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
          public override void WriteLog()
          {
              string key = this.DataBinder.Rows[0][TblCEB301MessageHead.__KeyName].ToString();//取单据号码
              DataSet dsOriginal = this.GetBusinessByKey(key, false); //取保存前的原始数据, 用于保存日志时匹配数据.
              DataSet dsTemplate = this.CreateSaveData(this.CurrentBusiness, UpdateType.Modify); //创建用于保存的临时数据
              this.WriteLog(dsOriginal, dsTemplate);//保存日志      
          }

          /// <summary>
          /// 写入日志
          /// </summary>
          /// <param name="original">原始数据</param>
          /// <param name="changes">修改后的数据</param>
          public override void WriteLog(DataTable original, DataTable changes) { }

          /// <summary>
          /// 写入日志
          /// </summary>
          /// <param name="original">原始数据</param>
          /// <param name="changes">修改后的数据</param>
          public override void WriteLog(DataSet original, DataSet changes)
          {  //单独处理,即使错误,不向外抛出异常
              if (_SaveVersionLog == false) return; //应用策略
              try
              {
                  string logID = Guid.NewGuid().ToString().Replace("-", ""); //本次日志ID
                  SystemLog.WriteLog(logID, original.Tables[0], changes.Tables[0], TblCEB301MessageHead.__TableName, TblCEB301MessageHead.__KeyName, true); //主表
                  //明细表的修改日志,系统不支持自动生成,请手工调整代码
                  //SystemLog.WriteLog(logID, original.Tables[1], changes.Tables[1], TblCEB301MessageHead.__TableName, TblCEB301MessageHead.__KeyName, false);
              }
              catch
              {
                  Msg.Warning("写入日志发生错误！");
              }
          }

          #endregion
     }
}
