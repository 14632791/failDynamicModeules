using GalaSoft.MvvmLight;
using MahApps.Metro.IconPacks;
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
    //[Export(typeof(IModuleBase))]
    public abstract class ModuleBaseViewModel : ViewModelBase, IModuleBase
    {
        public ModuleBaseViewModel()
        {
            Initialize();
        }
        public sys_Modules Module { get; set; }
        /// <summary>
        /// 子窗口插件
        /// </summary>
        [ImportMany(typeof(IMdiChildWindow), AllowRecomposition = true)]
        public ObservableCollection<Lazy<IMdiChildWindow>> SubModuleList { get; set; }
        public ObservableCollection<MenuModel> Menus
        {
            get; set;
        }
        public  Control Owner { get; set; }
        /// <summary>
        /// 获取窗体所有者
        /// </summary>
        /// <returns></returns>
        protected abstract Control GetOwner();

        /// <summary>
        /// 获取该模块的实体对象
        /// </summary>
        /// <returns></returns>
        protected abstract sys_Modules GetModule();

        /// <summary>
        /// 获取该模块的图标
        /// </summary>
        /// <returns></returns>
        protected abstract object GetIcon(); 

        public object Icon { get; set; }

        /// <summary>
        /// 初始化该模块下的所有子项
        /// </summary>
        public virtual void InitMenu()
        {
            SubModuleList = new ObservableCollection<Lazy<IMdiChildWindow>>();
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(IMdiChildWindow).Assembly);
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
            Icon = GetIcon();
            Module = GetModule();
            Owner = GetOwner();
            InitMenu();
            Owner.DataContext = this;//指定数据源
        }

    }
}
