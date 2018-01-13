using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interfaces;
using Metro.DynamicModeules.Core.Log;
using Metro.DynamicModeules.Core;

using Metro.DynamicModeules.Bridge;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models.DataDictModels;

/*==========================================
 *   程序说明: Person的业务逻辑层
 *   作者姓名: 鸿泰信 www.Metro.DynamicModeules.com
 *   创建日期: 2011-04-05 01:18:30
 *   最后修改: 2011-04-05 01:18:30
 *   
 *   注: 本代码由ClassGenerator自动生成
 *   版权所有 鸿泰信 www.Metro.DynamicModeules.com
 *==========================================*/

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class BllPerson : BllBaseDataDict
    {
        public BllPerson()
        {
            _KeyFieldName = TblPerson.__KeyName; //主键字段
            _SummaryTableName = TblPerson.__TableName;//表名
            _WriteDataLog = true;//是否保存日志

            //方式一：由ORM自动查询DAL类
            _DataDictBridge = BridgeFactory.CreateDataDictBridge(typeof(TblPerson));
        }
    }
}
