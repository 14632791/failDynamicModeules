using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;

using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Bridge.DataDictModule;
using Metro.DynamicModeules.Interfaces.Bridge;
using Metro.DynamicModeules.Models.DataDictModels;

/*==========================================
 *   程序说明: Customer的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-24 03:12:05
 *   最后修改: 2011-03-24 03:12:05
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    /// <summary>
    /// 客户资料管理业务逻辑层
    /// </summary>
    public class BllCustomer : BllBaseDataDict
    {
        private IBridgeCustomer _MyBridge; //桥接/策略接口

        public BllCustomer()
        {
            _KeyFieldName = TblCustomer.__KeyName; //主键字段
            _SummaryTableName = TblCustomer.__TableName;//表名
            _WriteDataLog = true;//是否保存日志
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblCustomer));
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

        public DataTable SearchBy(string CustomerFrom, string CustomerTo, string Name,
            string Attribute, bool resetCurrent)
        {
            DataTable data = _MyBridge.SearchBy(CustomerFrom, CustomerTo, Name, Attribute);
            if (resetCurrent) _SummaryTable = data;
            this.SetDefault(_SummaryTable);
            return data;
        }

        public DataTable GetCustomerByAttributeCodes(string attributeCodes, bool nameWithCode)
        {
            return _MyBridge.GetCustomerByAttributeCodes(attributeCodes, nameWithCode);
        }

        public DataTable FuzzySearch(string content)
        {
            return _MyBridge.FuzzySearch(content);
        }

        public DataTable FuzzySearch(string attributeCodes, string content)
        {
            return _MyBridge.FuzzySearch(attributeCodes, content);
        }
        public override bool Update(UpdateType updateType)
        {
            return base.Update(updateType);
        }
    }
}
