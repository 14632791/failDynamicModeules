using Metro.DynamicModeules.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using UpdateClient.BLL;
using UpdateClient.Common;
using System.Linq;

namespace Metro.DynamicModeules.Main
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //CheckUpdate(); //检查是否需要升级
            this.DispatcherUnhandledException += Application_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.Error((Exception)e.ExceptionObject);
            //Msg.DevShowError("非UI线程异常，请联系开发人员");
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            //Msg.ShowException(e.Exception);
            LogHelper.Error(e.Exception);
            e.Handled = true;
        }
      
        
        /// <summary>
        /// 登录时判断如果已有实例运行，则退出
        /// </summary>
        private void KillCurrentProcess()
        {
            Process currentProcess = Process.GetCurrentProcess();
            IEnumerable<Process> mainProcess = Process.GetProcesses().Where(p => string.Compare(p.ProcessName, "WPFTradeClient", true) == 0 && p.Id != currentProcess.Id);
            if (mainProcess != null && mainProcess.Count() > 0)
            {
                //Msg.DevShowError("投资管理平台已运行，点击确定后将退出本次操作！");
                Current.Shutdown();
                Process.GetCurrentProcess().Kill();
            }
        }

        #region 检测并启动更新程序 2017.6.13 陈刚


        /// <summary>
        /// 是否可以运行更新程序,
        /// </summary>
        private bool _isRunUpdate = true;
        private const string _processUpdateName = "/UpgradeClient/UpdateClient.exe";
        private static readonly string _updateFilePath = AppDomain.CurrentDomain.BaseDirectory + _processUpdateName;
        private bool HasMainForm()
        {
            Process[] ps = Process.GetProcesses();
            return ps.Any(p => string.Compare(p.ProcessName, _processUpdateName, true) == 0);
        }

        public static Process GetUpdateProcess()
        {
            Process pro = new Process();
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.FileName = _updateFilePath;
            pro.StartInfo.CreateNoWindow = true;
            pro.StartInfo.Arguments = "-e";
            return pro;
        }
        public static void RunUpdateProcess(Process pro)
        {
            if (pro.Start())
            {
                Current.Shutdown();
                Process.GetCurrentProcess().Kill();
            }
        }
        /// <summary>
        /// 新加的更新程序
        /// </summary>
        private void CheckUpdate()
        {
            try
            {
                if (HasMainForm())
                {
                    return;
                }
                if (!File.Exists(_updateFilePath))
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        MessageBox.Show("更新程序不存在或被损坏！");
                    }));
                    _isRunUpdate = false;
                    return;
                }
                if (VersionCompare.Instance.AsyncHasNewVersion())//检测是否是最新版本
                {
                    Process pro = GetUpdateProcess();
                    if (AppGlobalPool.UpdateInfo.Mandatory)//强制更新
                    {
                        LogHelper.Info("在主程序中调用UpdateClient.exe程序！");
                        RunUpdateProcess(pro);
                    }
                    else
                    {
                        this.Dispatcher.Invoke(new Action(() =>
                        {
                            //MessageDialog messageView = new MessageDialog();
                            //if (messageView.ShowDialog() == true)
                            //{
                            //    LogHelper.Info("在主程序中调用XHClient.UpdateClient.exe程序！");
                            //    RunUpdateProcess(pro);
                            //}
                            //else
                            //{
                            //    messageView.Close();
                            //}
                        }));
                    }
                    _isRunUpdate = true;
                }
                _isRunUpdate = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新异常：" + ex.Message);
                LogHelper.Error("CheckUpdate", ex);
            };
        }

        #endregion
    }
}
