using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UpdateClient.BLL;
using UpdateClient.Common;
using UpdateClient.ViewModels;

namespace UpdateClient.Views
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class DownloadPage : Page
    {
        public DownloadPage()
        {
            InitializeComponent();
        }

        #region 变量
        private int _result;
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private bool _isSucceed = true;
        private bool _isBackup = false;
        private ResultPage _resultPage = new ResultPage();
        private LocalOperation _localOperation = new LocalOperation();//备份
        #endregion


        private void DownloadFile()
        {
            try
            {
                if (AppGlobalPool.IsUpdateSelf)//判断有没有更新自己
                {
                    string strOldUpdateFile = AppDomain.CurrentDomain.BaseDirectory + "UpdateClient.exe.del";
                    if (File.Exists(strOldUpdateFile))
                    {
                        File.Delete(strOldUpdateFile);
                    }
                }
                string strMsg = "";
                if (!_localOperation.BackupFile(out strMsg))
                {
                    MessageBox.Show(strMsg);
                    _isSucceed = false;
                    NextForm();
                    return;
                }
                _isBackup = true;

                if (!_localOperation.ReplaceFile(out strMsg))//替换新版本
                {
                    MessageBox.Show(strMsg);
                    _isSucceed = false;
                    NextForm();
                    return;
                }
                NextForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DownloadFile异常：" + ex.Message.ToString());
                _isSucceed = false;
                NextForm();
            }
        }

        private void NextForm()
        {
            if (!_isSucceed && _isBackup)
            {
                _localOperation.RecoverFiles(AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.STempMoveDirectory, AppDomain.CurrentDomain.BaseDirectory);//替换失败还原目录
            }
            _localOperation.DeleteBackupTempDirectory();
            _resultPage.Result = _isSucceed ? 1 : 3;
            ViewBase.AddDictInfoAction("3", _resultPage);
            ViewBase.ExecuteStepAction("3");

        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_result > 1)
            {
                _resultPage.Result = _result;
                ViewBase.AddDictInfoAction("3", _resultPage);
                ViewBase.ExecuteStepAction("3");
            }
            else
            {
                DownloadFile();
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var model in AppGlobalPool.SFileDownloadList)
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    _result = 3;
                    return;
                }
            }
            _result = DownloadOperation.Instance.DownloadFiles(AppGlobalPool.SFileDownloadList);
        }

        private void ChangeTitelMsg(string step)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (!_worker.IsBusy) return;
                txtMsg.Text = step;
            }));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewBaseViewModel.Instance.Title = "系统更新";
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += worker_DoWork;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            _worker.RunWorkerAsync();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (_worker.IsBusy)
            {
                _resultPage.Result = 2;
                ViewBase.AddDictInfoAction("3", _resultPage);
                ViewBase.ExecuteStepAction("3");
            }
        }
    }
}
