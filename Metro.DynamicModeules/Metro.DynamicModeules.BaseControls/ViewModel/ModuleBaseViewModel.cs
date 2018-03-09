using GalaSoft.MvvmLight;
using Metro.DynamicModeules.BaseControls.Models;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    ///每个模块中唯一的主窗体类
    /// </summary>
    [Export(typeof(IModuleBase))]
    public class ModuleBaseViewModel : ViewModelBase, IModuleBase
    {
        public ModuleBaseViewModel()
        {
            InitMenu();
            InitButton();
        }
        public sys_Modules Module { get; set; }

        /// <summary>
        /// 子窗口插件
        /// </summary>
        [ImportMany(typeof(IMdiChildWindow), AllowRecomposition = true)]
        public ObservableCollection<Lazy<IMdiChildWindow>> SubModuleList { get; private set; }
        public ObservableCollection<MenuModel> Menus
        {
            get; set;
        }
        public Control Owner { get; set; }
        public object Icon
        {
            get; set;
        }       

        public void InitButton()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 初始化子菜单
        /// </summary>
        public void Initialize()
        {
            SubModuleList = new ObservableCollection<Lazy<IMdiChildWindow>>();
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(IMdiChildWindow).Assembly);
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);
        }

        public void InitMenu()
        {
            throw new NotImplementedException();
        }
      
    }
}
