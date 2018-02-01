using Metro.DynamicModeules.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Metro.DynamicModeules.Models;

namespace WpfCustomLibDemo1
{
    [Export(typeof(IPlugin))]
    public class MyPlugin1 : IPlugin
    {
        public sys_Modules ModulesInfo { get; set; } = new sys_Modules { ModuleID = 1, ModuleName = "数据字典" };

        public void Exec()
        {
            throw new NotImplementedException();
        }
    }
}
