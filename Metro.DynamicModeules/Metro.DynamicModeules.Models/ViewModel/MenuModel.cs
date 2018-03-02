using Metro.DynamicModeules.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Metro.DynamicModeules.Models.ViewModel
{
    /// <summary>
    /// 菜单要binding的实体
    /// </summary>
    public class MenuModel : NotifyPropertyChanged
    {
        string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (Equals(_name, value)) return;
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

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
        /// 要执行的操作
        /// </summary>
        public ICommand ClickCommand { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public ObservableCollection<MenuModel> SubMenus { get; set; }
    }
}
