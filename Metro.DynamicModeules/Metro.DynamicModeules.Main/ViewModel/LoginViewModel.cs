using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Main.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        string _passWord;
        public string PassWord
        {
            get
            {
                return _passWord;
            }
            set
            {
                _passWord = value;
                RaisePropertyChanged(() => PassWord);
            }
        }

        string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }
        private  RelayCommand _userLoginCommand;
        public RelayCommand UserLoginCommand
        {
            get
            {
                return _userLoginCommand ?? (_userLoginCommand = new RelayCommand(() =>
                {

                }));
            }
        }
    }
}
