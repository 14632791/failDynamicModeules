using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using System.Data;
using System;



namespace Metro.DynamicModeules.BLL.DataDict
{
    /// <summary>
    /// 客户资料管理业务逻辑层
    /// </summary>
    public class BllCustomer : BllBase<tb_Customer>
    {
        protected override string GetControllerName()
        {
            throw new NotImplementedException();
        }
    }
}
