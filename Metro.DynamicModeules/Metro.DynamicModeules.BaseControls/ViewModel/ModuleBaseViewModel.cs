using GalaSoft.MvvmLight;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
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
    public abstract class ModuleBaseViewModel : CommonModuleBaseViewModel, IModuleBase
    {
        /// <summary>
        /// 对应的主窗体
        /// </summary>
        public IMdiMainWindow MdiMainWindow { get; set; }
        /// <summary>
        /// 子窗口插件
        /// </summary>
        [ImportMany(typeof(IMdiChildView), AllowRecomposition = true)]
        public ObservableCollection<IMdiChildView> SubModuleList
        {
            get
            {
                return _subModuleList;
            }
            set
            {
                if (Equals(_subModuleList, value)) return;
                _subModuleList = value;
                RaisePropertyChanged(() => SubModuleList);
            }
        }
        ObservableCollection<IMdiChildView> _subModuleList;
        /// <summary>
        /// 当前选中的子项
        /// </summary>
        public IMdiChildView FocusedChild { get; set; }
        /// <summary>
        /// 获取该模块的实体对象
        /// </summary>
        /// <returns></returns>
        protected abstract sys_Modules GetModule();


        /// <summary>
        /// 初始化该模块下的所有子项
        /// </summary>
        public virtual void InitMenu()
        {
            SubModuleList = new ObservableCollection<IMdiChildView>();
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(typeof(IMdiChildView).Assembly);
            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);
            foreach (var item in SubModuleList)
            {
                item.IModule = this;
                item.MdiMainWindow = MdiMainWindow;
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            Module = GetModule();
            InitMenu();
        }

    }

    /// <summary>
    /// 主模块与子模块通用的基类
    /// </summary>
    public abstract class CommonModuleBaseViewModel : ViewModelBase
    {
        public CommonModuleBaseViewModel()
        {
            Initialize();
        }
        public sys_Modules Module { get; set; }


        public Control Owner { get; set; }
        /// <summary>
        /// 获取窗体所有者
        /// </summary>
        /// <returns></returns>
        protected abstract Control GetOwner();


        /// <summary>
        /// 获取该模块的图标
        /// </summary>
        /// <returns></returns>
        protected abstract object GetIcon();

        object _icon;
        /// <summary>
        /// 图标
        /// </summary>
        public object Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                if (Equals(_icon, value)) return;
                _icon = value;
                RaisePropertyChanged("Icon");
            }
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
            Icon = GetIcon();
            Owner = GetOwner();
            Owner.DataContext = this;//指定数据源
        }

    }
}
