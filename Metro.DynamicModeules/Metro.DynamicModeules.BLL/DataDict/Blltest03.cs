using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
//using Metro.DynamicModeules.Core.Interfaces;
//using Metro.DynamicModeules.Core.Log;
using Metro.DynamicModeules.Server.DataAccess;
//using Metro.DynamicModeules.Core;
//using Metro.DynamicModeules.Core.BLL_Base;

using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Bridge.DataDictModule;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Models.DataDictModels;

/*==========================================
 *   程序说明: test03的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2014/04/24 09:24:12
 *   最后修改: 2014/04/24 09:24:12
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class Blltest03 : BllBaseDataDict
    {
        private IBridgeCustomer _MyBridge; //桥接/策略接口
         public Blltest03()
         {
             _KeyFieldName = Tbltest01.__KeyName; //主键字段
             _SummaryTableName = Tbltest01.__TableName;//表名
             _WriteDataLog = true;//是否保存日志
             //_DAL = new daltest03(Loginer.CurrentUser);//数据层的实例
             _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(Tbltest01));
             _MyBridge = this.CreateBridge();
         }

         /// <summary>
         /// 创建桥接通信通道
         /// </summary>
         /// <returns></returns>
         private IBridgeCustomer CreateBridge()
         {
             if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                 return new ADODirectCustomer().GetInstance();

             if (BridgeFactory.BridgeType == BridgeType.WebService)
                 return new WebServiceCustomer();

             return null;
         }
     }
}
