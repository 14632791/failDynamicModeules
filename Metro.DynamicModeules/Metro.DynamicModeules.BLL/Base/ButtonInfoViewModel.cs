using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;

namespace Metro.DynamicModeules.BLL.Base
{
    /// <summary>
    /// ButtonInfo的viewModel
    /// </summary>
    public class ButtonInfoViewModel : ViewModelBase//, IButtonInfo
    {
        public ButtonInfoViewModel(object icon, tb_MyAuthorityItem item, Action action)
        {
            Icon = icon;
            AuthorityItem = item;
            this.action = action;
        }
        //public IDataOperatable DataOperatabler { get; set; }
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
        RelayCommand _clickCommand;
        public RelayCommand ClickCommand
        {
            // get; set;
            get
            {
                return _clickCommand ?? (_clickCommand = new RelayCommand(action));
            }
        }
        protected Action action;
    }
}
