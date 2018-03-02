using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Core
{
    /// <summary>
    /// 模块主窗体
    /// </summary>
    [Export(typeof(IModuleBase))]
    public abstract class ModuleBase : IModuleBase
    {
        public ModuleBase()
        {
            Initialize();
            InitMenu();
            InitButton();
        }
        public sys_Modules Module { get; set; }

        /// <summary>
        /// 子窗口插件
        /// </summary>
        [ImportMany(typeof(IMdiChildWindow), AllowRecomposition = true)]
        public List<Lazy<IMdiChildWindow>> SubModuleList { get; private set; }
        public ObservableCollection<MenuModel> Menus { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Control Container { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object Icon { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Control GetContainer()
        {
            throw new NotImplementedException();
        }

        public MenuItem GetModuleMenu()
        {
            throw new NotImplementedException();
        }

        public  void InitButton()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            SubModuleList = new List<Lazy<IMdiChildWindow>>();
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

        public void SetSecurity(object securityInfo)
        {
            throw new NotImplementedException();
        }
    }
    
    
}
