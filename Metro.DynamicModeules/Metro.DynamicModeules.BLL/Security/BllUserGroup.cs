using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.Security
{
   public class BllUserGroup:BllBase<tb_MyUserGroup>
    {
        protected override string GetControllerName()
        {
            return "UserGroup";
        }
    }
}
