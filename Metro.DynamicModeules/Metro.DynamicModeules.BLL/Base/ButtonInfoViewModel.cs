using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Windows.Input;

namespace Metro.DynamicModeules.BLL.Base
{
    /// <summary>
    /// ButtonInfo的viewModel
    /// </summary>
    public class ButtonInfoViewModel : ViewModelBase, IButtonInfo
    {
        public ButtonInfoViewModel(object icon, tb_MyAuthorityItem item, Action action)
        {
            Icon = icon;
            AuthorityItem = item;
            this._action = action;
            IsEnabled = true;
        }
        tb_MyAuthorityItem _authorityItem;
        public tb_MyAuthorityItem AuthorityItem
        {
            get
            {
                return _authorityItem;
            }
            set
            {
                _authorityItem = value;
                RaisePropertyChanged(() => AuthorityItem);
            }
        }
        bool _isEnabled=true;
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if (Equals(_isEnabled, value)) return;
                _icon = value;
                RaisePropertyChanged(()=> IsEnabled);
            }
        }

        object _icon=null;
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
                RaisePropertyChanged(()=> Icon);
            }
        }
        public int Index
        {
            get;
            set;
        }
        ICommand _clickCommand;
        public ICommand ClickCommand
        {
            // get; set;
            get
            {
                return _clickCommand ?? (_clickCommand = new RelayCommand(_action));
            }
        }
        private Action _action;
    }
}
