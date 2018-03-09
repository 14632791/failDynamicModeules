using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Interface.Sys;
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
        

        public override Control GetOwner()
        {
            return new SystemMainView();
        }

       

        public override void InitMenu()
        {
            SubModuleList = new ObservableCollection<Lazy<IMdiChildWindow>>();
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(IMdiChildWindow).Assembly);
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);
        }
    }
}
