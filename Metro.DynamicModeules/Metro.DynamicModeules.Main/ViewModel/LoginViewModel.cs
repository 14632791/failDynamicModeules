using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Metro.DynamicModeules.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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

        bool _isSave;
        public bool IsSave
        {
            get
            {
                return _isSave;
            }
            set
            {
                _isSave = value;
                RaisePropertyChanged(() => IsSave);
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
        private void SaveLoginInfo()
        {            
            //存在用户配置文件，自动加载登录信息
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + Globals.INI_CFG;
            IniFile ini = new IniFile(cfgINI);
            ini.IniWriteValue("LoginWindow", "User", UserName);
            ini.IniWriteValue("LoginWindow", "Password", CEncoder.Encode(PassWord));
            ini.IniWriteValue("LoginWindow", "SaveLogin", IsSave ? "Y" : "N");
        }
    }
}
