﻿using GalaSoft.MvvmLight;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Interface.Sys;
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
    public abstract class ModuleBaseViewModel : CommonModuleBaseViewModel, IModuleBase
    {
        public sys_Modules Module { get; set; }

        /// <summary>
        /// 子窗口插件
        /// </summary>
        [ImportMany(typeof(IMdiChildViewModel), AllowRecomposition = true)]
        public ObservableCollection<IMdiChildViewModel> SubModuleList
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
        ObservableCollection<IMdiChildViewModel> _subModuleList;
        /// <summary>
        /// 当前选中的子项
        /// </summary>
        public IMdiChildViewModel FocusedChild { get; set; }
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
            //SubModuleList = new ObservableCollection<IMdiChildView>();
            AggregateCatalog catalog = new AggregateCatalog();
            //添加插件容器中的导出项目录
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetEntryAssembly()));
            //添加程序运行路径下的导出项目录
            //catalog.Catalogs.Add(new DirectoryCatalog(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),"*.dll"));
            CompositionContainer cc = new CompositionContainer(catalog);
            cc.ComposeParts(this);
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            Icon = GetIcon();
            Owner = GetOwner(); //指定窗体
            Owner.DataContext = this;
            Module = GetModule();
            InitMenu();
        }


        /// <summary>
        /// 当被选中时的方法
        /// </summary>
        protected override void OnChecked()
        {
            try
            {
                base.OnChecked();
                if (!Checked.HasValue)
                {
                    return;
                }
                //向下兼容
                foreach (var item in SubModuleList)
                {
                    item.Checked = Checked.Value;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }
    }


    /// <summary>
    /// 主模块与子模块通用的基类
    /// </summary>
    public abstract class CommonModuleBaseViewModel : ViewModelBase, ICommonModuleBase
    {
        public CommonModuleBaseViewModel()
        {
            Initialize();//这里就开始初始化
        }

        /// <summary>
        /// 对应的主窗体
        /// </summary>
        public IMdiMainViewModel MdiMainWindow { get; set; }

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
        bool? _checked;
        public bool? Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    RaisePropertyChanged(() => Checked);
                    OnChecked();
                }
            }
        }

        /// <summary>
        /// 当被选中时的方法
        /// </summary>
        protected virtual void OnChecked()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
        }
    }
}

