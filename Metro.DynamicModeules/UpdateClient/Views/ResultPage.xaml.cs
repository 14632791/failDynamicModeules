using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UpdateClient.BLL;
using UpdateClient.Common;
using UpdateClient.ViewModels;

namespace UpdateClient.Views
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }
        public int Result { get; set; }
        /// <summary>
        /// 错误提示
        /// </summary>
        public static string ErrorMsg { get; set; }
        private string lblTitle;
        private void InitForm()
        {
            try
            {
                string MessageInfo = string.Empty;
                string strMessage = "旧版本：{0},已更新至新版本{1},更新详情：{2},结果：{3}";
                string imagePath;
                switch (Result)
                {
                    case 1:
                        imagePath = "imagefinish";
                        _txtContent.Text = string.Format("感谢您的支持，系统已更新至{0}版本！", AppGlobalPool.UpdateInfo.Version);
                        lblTitle = "成功";
                        break;
                    case 2:
                        _txtContent.Text = "您已取消本次系统更新！";
                        imagePath = "imagerenounce";
                        lblTitle = "取消";
                        break;
                    default:
                        _txtContent.Text = "网络连接已断开，请检查网络设置！";
                        if (!string.IsNullOrEmpty(ErrorMsg))
                        {
                            _txtContent.Text = ErrorMsg;
                        }
                        imagePath = "imagenoconnect";
                        lblTitle = "失败";
                        break;
                }
                imgFinish.Source = (ImageSource)this.FindResource(imagePath);
                MessageInfo = string.Format(strMessage, AppGlobalPool.OldVersion, AppGlobalPool.UpdateInfo.Version, _txtContent, lblTitle);
                //将最新的版本信息写入注册表 add by  2017-05-05
                int versionToInt = RegeditHelper.GetVersionNo();
                RegeditHelper.WriteRegeditConfig(versionToInt);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MainProcessOpreate.Instatnce.OpreateMainForm(false);
            //Environment.Exit(0);
           Application.Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                InitForm();
                ViewBaseViewModel.Instance.Title = "系统更新提示";
            }
            catch (Exception ex)
            {
                LogHelper.Error("ResultPage-Page_Loaded", ex);
            }
        }
    }

}
