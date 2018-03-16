using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Models.Sys;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using SystemModule.Views;

namespace SystemModule.ViewModel
{
    [Export(typeof(ModuleBaseViewModel))]
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
