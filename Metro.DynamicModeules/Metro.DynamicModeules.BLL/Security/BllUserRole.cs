using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.Security
{
   public class BllUserRole : BllBase<tb_MyUserGroupRole>
    {
        protected override string GetControllerName()
        {
            return "UserGroupRole";
        }
    }
}
