using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Core;
using Metro.DynamicModeules.Models;
using System.ComponentModel.Composition;

namespace WpfCustomLibDemo1
{
    [Export(typeof(ModuleBaseViewModel))]
    public class MyPlugin1 : ModuleBaseViewModel
    {
        public sys_Modules ModulesInfo { get; set; } = new sys_Modules
        {
            ModuleID = 1,
            ModuleName = "数据字典"
        };
    }
}
