using Metro.DynamicModeules.BaseControls.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SystemModule.ViewModel;

namespace SystemModule.Views
{
    /// <summary>
    /// ModuleBaseView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            DataContext = ViewModelLocator.Instance.Main;
        }
    }
}
