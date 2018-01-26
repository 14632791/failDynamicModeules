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


        // Using a DependencyProperty as the backing store for MetroDialogPotions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MetroDialogPotionsProperty =
            DependencyProperty.Register("MetroDialogPotions", typeof(MetroDialogSettings), typeof(LoginView), new PropertyMetadata(null));

        private async void tbtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // this.Cursor = Cursors.Wait;
                pRingWaiting.Visibility = Visibility.Visible;
                //this.SetButtonEnable(false);
                this.ShowLoginInfo("正在验证用户名及密码");
                //BllUser.ValidateLogin(txtUser.Text, txtPwd.Text);//检查登录信息
                string userID = txtUser.Text;
                string password = CEncoder.Encode(txtPwd.Password);/*常规加密*/
                                                                   //string dataSetID = txtDataset.EditValue.ToString();//帐套编号
                                                                   //string dataSetDB = GetDataSetDBName();
                                                                   //BllPayType bllPayType = new BllPayType();
                                                                   //var paytypes = bllPayType.GetSearchList(p => p.PayType == "VIA");
                Expression<Func<tb_MyUser, bool>> predicate = u => u.Account == userID;
                var user = await _bllUser.GetSearchList(predicate);
                //LoginUser loginUser = new LoginUser(userID, password, dataSetID, dataSetDB);
                if (null != user && user.Count > 0)
                //if (_CurrentAuthorization.Login(loginUser)) //调用登录策略
                {
                    // if (chkSaveLoginInfo.IsChecked.Value) this.SaveLoginInfo();//跟据选项保存登录信息  
                    //SystemAuthentication.Current = _CurrentAuthorization; //授权成功, 保存当前授权模式

                    MainWindow MainForm = new MainWindow();//登录成功创建主窗体                    
                    //Program.MainForm.InitUserInterface(new LoadStatus(form1.lblLoadingInfo, form1.progressBarControl1));
                    this.DialogResult = true; //成功
                    MainForm.Show();
                    this.Hide();
                    this.Close(); //关闭登陆窗体
                    //while (form1.Opacity > 0)
                    //{
                    //    form1.Opacity = form1.Opacity - 0.05;
                    //    Application.DoEvents();
                    //    Thread.Sleep(100);
                    //}
                    //form1.Close();
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
