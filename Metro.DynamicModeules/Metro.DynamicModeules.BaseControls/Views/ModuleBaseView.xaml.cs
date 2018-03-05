using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Metro.DynamicModeules.Models.ViewModel;
using System.Collections.ObjectModel;

namespace Metro.DynamicModeules.BaseControls.Views
{
    /// <summary>
    /// ModuleBaseView.xaml 的交互逻辑
    /// </summary>
    public partial class ModuleBaseView : UserControl, IModuleBase
    {
        public ModuleBaseView()
        {
            InitializeComponent();
        }

        public DynamicModeules.Models.sys_Modules Module { get; set; }
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
        /// <summary>
        /// 初始化子菜单
        /// </summary>
        public void Initialize()
        {
            throw new NotImplementedException();
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
