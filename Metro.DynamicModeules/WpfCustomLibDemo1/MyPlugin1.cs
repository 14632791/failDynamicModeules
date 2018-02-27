using Metro.DynamicModeules.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Metro.DynamicModeules.Models;
using System.Windows.Controls;
using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.Interface.Sys;

namespace WpfCustomLibDemo1
{
    [Export(typeof(IModuleBase))]
    public class MyPlugin1 : IModuleBase
    {
        public sys_Modules ModulesInfo { get; set; } = new sys_Modules { ModuleID = 1,
            ModuleName = "数据字典" };
        public PackIconModernKind Kind { get; set; }

        public sys_Modules Module => throw new NotImplementedException();

        public void Exec()
        {
            throw new NotImplementedException();
        }

        public Control GetContainer()
        {
            throw new NotImplementedException();
        }

        public MenuItem GetModuleMenu()
        {
            throw new NotImplementedException();
        }

        public void InitButton()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void InitMenu()
        {
            throw new NotImplementedException();
        }

        public void SetSecurity(object securityInfo)
        {
            throw new NotImplementedException();
        }
    }
}
