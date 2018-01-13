using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;

using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Bridge.DataDictModule;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Interfaces.Bridge;

/*==========================================
 *   程序说明: AccountIDs的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-23 10:58:32
 *   最后修改: 2011-03-23 10:58:32
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class BllAccountIDs : BllBaseDataDict
    {
        private IBridgeProduct _MyBridge = null;

        public BllAccountIDs()
        {
            _KeyFieldName = TblAccountIDs.__KeyName; //主键字段
            _SummaryTableName = TblAccountIDs.__TableName;//表名
            _WriteDataLog = false;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblAccountIDs));
            _MyBridge = this.CreateBridge();
        }

        private IBridgeProduct CreateBridge()
        {
            if (BridgeFactory.BridgeType == BridgeType.ADODirect)
                return new ADODirectProduct().GetInstance();

            if (BridgeFactory.BridgeType == BridgeType.WebService)
                return new WebServiceProduct();

            return null;
        }

    }
}
