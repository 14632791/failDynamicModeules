using GalaSoft.MvvmLight;
using Metro.DynamicModeules.Interface.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Metro.DynamicModeules.Models.Sys;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Metro.DynamicModeules.BaseControls.ViewModel
{
    /// <summary>
    /// ButtonInfo的viewModel
    /// </summary>
    public class ButtonInfoViewModel : ViewModelBase, IButtonInfo
    {
        public ButtonInfoViewModel()
        {
            Icon = GetIcon();
            AuthorityItem = GetAuthorityItem();
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

        protected virtual tb_MyAuthorityItem GetAuthorityItem()
        {
            return null;
        }

        /// <summary>
        /// 获取该模块的图标
        /// </summary>
        /// <returns></returns>
        protected virtual  object GetIcon()
        {
            return null;
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
        public int Index
        {
            get;
            set;
        }
        ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new RelayCommand(OnClick));
            }
        }
        protected virtual void OnClick()
        {
        }
    }
}
