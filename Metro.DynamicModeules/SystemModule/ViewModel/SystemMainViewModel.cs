using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SystemModule.Views;

namespace SystemModule.ViewModel
{
    [Export(typeof(IModuleBase))]
    public class SystemMainViewModel : ModuleBaseViewModel
    {
        protected override Control GetOwner()
        {
            return new SystemMainView();
        }
        protected override object GetIcon()
        {
            return new PackIconMaterial { Kind = PackIconMaterialKind.AccountSettingsVariant };
        }
        protected override sys_Modules GetModule()
        {
            return new sys_Modules
            {
                ModuleID = 7,
                ModuleName = "系统管理"
            };
        }
    }
}
