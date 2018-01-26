using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.DataDict
{
    public class BllPayType : BllBase<tb_PayType>
    {
        protected override string GetControllerName()
        {
            return "PayType";
        }
    }
}
