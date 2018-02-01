using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Metro.DynamicModeules.BLL.Security;
using Metro.DynamicModeules.Common;
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
using System.Windows.Shapes;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.BLL.DataDict;
using Metro.DynamicModeules.BLL;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using Metro.DynamicModeules.Core.Interfaces;

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

        }
        private BllUser _bllUser = new BllUser();
        String _userID = "";
        String _password = "";

        // Using a DependencyProperty as the backing store for MetroDialogPotions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetroDialogPotionsProperty =
            DependencyProperty.Register("MetroDialogPotions", typeof(MetroDialogSettings), typeof(LoginView), new PropertyMetadata(null));

        private async void tbtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pRingWaiting.Visibility = Visibility.Visible;
                this.ShowLoginInfo("正在验证用户名及密码");
                //BllUser.ValidateLogin(txtUser.Text, txtPwd.Text);//检查登录信息
                _userID = txtUser.Text;
                _password = CEncoder.Encode(txtPwd.Password);/*常规加密*/
                //需要系列化的linq表达表需要通过以下语句生成
                Expression<Func<tb_MyUser, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUser, bool>("Account=@0&&Password=@1", new object[] { _userID, _password });
                var user = await _bllUser.GetSearchList(predicate);
                if (null != user && user.Count > 0)
                //if (_CurrentAuthorization.Login(loginUser)) //调用登录策略
                {
                    // if (chkSaveLoginInfo.IsChecked.Value) this.SaveLoginInfo();//跟据选项保存登录信息  
                    //SystemAuthentication.Current = _CurrentAuthorization; //授权成功, 保存当前授权模式
                    //Dispatcher.Invoke(new Action(() =>
                    //{
                        DataDictCache.Instance.User = user[0];
                    //new MainWindow().Show();                                           //Program.MainForm.InitUserInterface(new LoadStatus(form1.lblLoadingInfo, form1.progressBarControl1));
                    Window mainpage = PluginHandle.Instance.Host.Value as Window;
                    mainpage.Show();
                    this.Hide();
                        this.Close(); //关闭登陆窗体
                   // }));
                }
                else
                {
                    this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                    await this.ShowMessageAsync("登录失败", "请检查用户名和密码!");
                }
            }
            catch (CustomException ex)
            {
                //this.SetButtonEnable(true);
                this.ShowLoginInfo(ex.Message);
                //Msg.Warning(ex.Message);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                //this.SetButtonEnable(true);
                this.ShowLoginInfo("登录失败，请检查用户名和密码!");
                await this.ShowMessageAsync("登录失败", "请检查用户名和密码!");
            }
            finally
            {
                //this.Cursor = Cursors.None;
                pRingWaiting.Visibility = Visibility.Collapsed;
            }
        }
        private void ShowLoginInfo(string msg)
        {
            txtLoginInfo.Text += msg;
        }
    }
}
