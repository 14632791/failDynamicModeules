using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Metro.DynamicModeules.Models;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Metro.DynamicModeules.Models.Mvvm;
using System.Collections.ObjectModel;

namespace Metro.DynamicModeules.Core
{
    /// <summary>
    /// 模块主窗体
    /// </summary>
    public class ModuleBase : IModuleBase
    {
        public ModuleBase()
        {
            Initialize();
        }
        public sys_Modules Module { get; set; }

        /// <summary>
        /// 子窗口插件
        /// </summary>
        [ImportMany(typeof(SubModuleBase), AllowRecomposition = true)]
        public List<Lazy<SubModuleBase>> SubModuleList { get; private set; }
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

        public void InitButton()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            SubModuleList = new List<Lazy<SubModuleBase>>();
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(SubModuleBase).Assembly);
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
