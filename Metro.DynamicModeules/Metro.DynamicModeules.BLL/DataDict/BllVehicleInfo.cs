using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Bridge.InventoryModule;
using Metro.DynamicModeules.Bridge.DataDictModule;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Server.DataAccess.DalSystem;
using System.Threading.Tasks;

/*==========================================
 *   程序说明: VehicleInfo的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/06/18 03:28:53
 *   最后修改: 2015/06/18 03:28:53
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class BllVehicleInfo : BllBaseDataDict
    {
          private IBridgeVehicleInfo _MyBridge; //桥接/策略接口
         public BllVehicleInfo()
         {
             _KeyFieldName = TblVehicleInfo.__KeyName; //主键字段
             _SummaryTableName = TblVehicleInfo.__TableName;//表名
             _WriteDataLog = true;//是否保存日志
             _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblVehicleInfo));
            _MyBridge = this.CreateBridge();
         }

        /// <summary>
        /// 创建桥接通信通道
        /// </summary>
        /// <returns></returns>
         private IBridgeVehicleInfo CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectVehicleInfo().GetInstance();
            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceVehicleInfo();
            return null;
        }
         public DataTable GetSummaryByParam(string strCarNo, int iHireType, int iVehicleType, string strCarByCompany)
         {
             return _MyBridge.GetSummaryByParam(
                 Globals.RemoveInjection(strCarNo, 16),
                 iHireType,iVehicleType, Globals.RemoveInjection(strCarByCompany, 20));
         }
         public override DataTable GetSummaryData(bool resetCurrent)
         {
             DataTable data = _MyBridge.GetSummaryByParam("", -1, -1, "");
                // DataDictCache.Cache.CommonDataVehicleInfo;
             this.SetDefault(data);
             if (resetCurrent) _SummaryTable = data;             
             return data;
         }
         protected override void SetDefault(DataTable data)
         {
             data.Columns[TblVehicleInfo.HireType].DefaultValue = 1;
             data.Columns[TblVehicleInfo.VehicleType].DefaultValue = 3;
             data.Columns[TblVehicleInfo.IsUse].DefaultValue = 1;
             data.Columns[TblVehicleInfo.IsHTX].DefaultValue = 0;
         }
     }
}
