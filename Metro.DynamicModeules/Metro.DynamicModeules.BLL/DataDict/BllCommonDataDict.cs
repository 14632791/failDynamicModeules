using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;

using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models.DataDictModels;
using Metro.DynamicModeules.Interfaces.Bridge;

/*==========================================
 *   程序说明: CommonDataDict的业务逻辑层
 *   作者姓名: Your Name
 *   创建日期: 2011-03-22 05:57:50
 *   最后修改: 2011-03-22 05:57:50
 *   
 *   注: 本代码由ClassGenerator自动生成
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    /// <summary>
    /// 公共字典数据业务逻辑层
    /// </summary>
    public class BllCommonDataDict : BllBaseDataDict
    {
        private IBridgeCommonDataDict _SelfBridge;

        public BllCommonDataDict()
        {
            _KeyFieldName = TblCommonDataDict.__KeyName; //主键字段
            _SummaryTableName = TblCommonDataDict.__TableName;//表名
            _WriteDataLog = false;//是否保存日志            
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblCommonDataDict));
            _SelfBridge = BridgeFactory.CreateCommonDataDictBridge();
        }

        /// <summary>
        /// 搜索数据
        /// </summary>
        /// <param name="dataType">字典类型</param>
        /// <param name="resetCurrent">重置当前处理的数据</param>
        /// <returns></returns>
        public DataTable SearchBy(int dataType, bool resetCurrent)
        {
            DataTable data = _SelfBridge.SearchBy(dataType);
            if (resetCurrent) _SummaryTable = data;
            this.SetDefault(_SummaryTable);
            return data;
        }

        /// <summary>
        /// 增加一个字典类型
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public bool AddCommonType(int code, string name)
        {
            return _SelfBridge.AddCommonType(code, name);
        }

        /// <summary>
        /// 删除字典类型
        /// </summary>
        /// <param name="code">编号</param>
        /// <returns></returns>
        public bool DeleteCommonType(int code)
        {
            return _SelfBridge.DeleteCommonType(code);
        }

        /// <summary>
        /// 检查字典类型是否存在
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool IsExistsCommonType(int id)
        {
            return _SelfBridge.IsExistsCommonType(id);
        }

    }
}
