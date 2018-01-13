using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Server.DataAccess;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Bridge;

/*==========================================
 *   程序说明: DriversVehicleRelation的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2015/07/06 08:54:57
 *   最后修改: 2015/07/06 08:54:57
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.Business
{
    public class BllDriversVehicleRelation : BllBaseDataDict
    {
       // private IBridgeDriversVehicleRelation _MyBridge; //桥接/策略接口
        public BllDriversVehicleRelation()
        {
            _KeyFieldName = TblDriversVehicleRelation.__KeyName; //主键字段
            _SummaryTableName = TblDriversVehicleRelation.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblDriversVehicleRelation));
        }
    }
}
