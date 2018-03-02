using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.Security
{
   public class BllUserRole : BllBase<tb_MyUserRole>
    {
        protected override string GetControllerName()
        {
            return "UserGroup";
        }
    }
}
