using MahApps.Metro.Controls.Dialogs;
using Metro.DynamicModeules.BLL;
using Metro.DynamicModeules.BLL.Security;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;

namespace Metro.DynamicModeules.Main
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : MahApps.Metro.Controls.MetroWindow
    {
        public LoginView()
        {
            InitializeComponent();
            GetDefaultUserInfo();
        }
        private BllUser _bllUser = new BllUser();
        string _userID = "";
        string _password = "";
        string _cfgINI = AppDomain.CurrentDomain.BaseDirectory + Globals.INI_CFG;
        // Using a DependencyProperty as the backing store for MetroDialogPotions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetroDialogPotionsProperty =
            DependencyProperty.Register("MetroDialogPotions", typeof(MetroDialogSettings), typeof(LoginView), new PropertyMetadata(null));

        private async void tbtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //pRingWaiting.Visibility = Visibility.Visible;
                this.ShowLoginInfo("正在验证用户名及密码");
                _userID = txtUser.Text;
                _password = CEncoder.Encode(txtPwd.Password);/*常规加密*/
                //需要系列化的linq表达表需要通过以下语句生成
                Expression<Func<tb_MyUser, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUser, bool>("Account=@0&&Password=@1", new object[] { _userID, _password });
                var user = await _bllUser.GetSearchList(predicate);
                if (null != user && user.Count > 0)
                {
                    if (chkSaveLoginInfo.IsChecked.Value)
                    {
                        SaveLoginInfo();//跟据选项保存登录信息  
                    }
                    DataDictCache.Instance.LoginUser = user[0];
                    await Task.Factory.StartNew(DataDictCache.Instance.DownloadBaseCacheData);
                    Window mainpage = PluginHandle.Instance.Host.Value as Window;
                    mainpage.Show();
                    this.Close(); 
                }
                else
                {
                    this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                    await this.ShowMessageAsync("登录失败", "请检查用户名和密码!");
                }
            }
            catch (CustomException ex)
            {
                this.ShowLoginInfo(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                await this.ShowMessageAsync("登录失败", ex.Message);
            }
            finally
            {
                //this.Cursor = Cursors.None;
                //pRingWaiting.Visibility = Visibility.Collapsed;
            }
        }
        private void ShowLoginInfo(string msg)
        {
            txtLoginInfo.Text += msg + "\n\r";
        }
        private void SaveLoginInfo()
        {
            //存在用户配置文件，自动加载登录信息
            IniFile ini = new IniFile(_cfgINI);
            ini.IniWriteValue("LoginWindow", "User", _userID);
            ini.IniWriteValue("LoginWindow", "Password", _password);
            ini.IniWriteValue("LoginWindow", "SaveLogin", chkSaveLoginInfo.IsChecked.Value ? "Y" : "N");
        }
        private void GetDefaultUserInfo()
        {
            IniFile ini = new IniFile(_cfgINI);
            txtUser.Text = ini.IniReadValue("LoginWindow", "User");
            txtPwd.Password = CEncoder.Decode(ini.IniReadValue("LoginWindow", "Password"));
            chkSaveLoginInfo.IsChecked = ini.IniReadValue("LoginWindow", "SaveLogin") == "Y";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
