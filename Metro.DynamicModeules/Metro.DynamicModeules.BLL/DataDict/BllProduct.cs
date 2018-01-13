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
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Models.DataDictModels;

/*==========================================
 *   程序说明: Product的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-23 10:58:32
 *   最后修改: 2011-03-23 10:58:32
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class BllProduct : BllBaseDataDict
    {
        private IBridgeProduct _MyBridge = null;

        public BllProduct()
        {
            _KeyFieldName = TblProduct.__KeyName; //主键字段
            _SummaryTableName = TblProduct.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblProduct));
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

        public DataTable FuzzySearch(string content)
        {
            return _MyBridge.FuzzySearch(content);
        }
    }
}
