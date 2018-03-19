using MahApps.Metro.Controls.Dialogs;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using UpdateClient.BLL;
using UpdateClient.Common;
using UpdateClient.Views;

namespace UpdateClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SetSingleSelfApp();// MessageBox.Show("只允许运行一个升级实例！");
            this.DispatcherUnhandledException += Application_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            base.OnStartup(e);
            string paramstr = string.Empty;
            if (null != e.Args && e.Args.Count() > 0)
            {
                paramstr = e.Args[0];
            }
            CheckEntry(paramstr);
            ViewBase view = new ViewBase();
            view.Show();
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
        /// 入口检查
        /// </summary>
        /// <param name="strPara"></param>
        private static void CheckEntry(string strPara)
        {
            try
            {
                if (MainProcessOpreate.Instatnce.IsSingleMainForm())
                {
                    CloseCurrentProcess();
                    //Application.Current.Shutdown();
                    //Environment.Exit(0);
                }
                LogHelper.Info("当前传入的参数是：" + strPara);
                switch (strPara)
                {
                    case "-c":
                        AppGlobalPool.IsPara = true;
                        break;
                    case "-e":
                        AppGlobalPool.IsReturn = true;
                        break;
                    default:
                        break;
                }
                //如果是外部条件调用，就直接运行
                //if (AppGlobalPool.IsReturn)//外部调用
                //{
                //    return;
                //}
                if (VersionCompare.Instance.AsyncHasNewVersion())//HasNewVersion())//检测是否是最新版本
                {
                    if (AppGlobalPool.IsReturn)//外部调用
                    {
                        LogHelper.Info("当前是从主程序调用");
                        if (AppGlobalPool.UpdateInfo.Mandatory)//强制更新
                        {
                            Console.Write("2");
                        }
                        else
                        {
                            Console.Write("1");
                        }
                    }
                    else
                    {
                        if (AppGlobalPool.IsPara)// 返回参数试调用
                        {
                            if (MessageBox.Show("发现新版本，是否立即更新？", "升级", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.No)
                            {
                                MainProcessOpreate.Instatnce.OpreateMainForm(true);
                            }
                            else
                            {
                                CloseCurrentProcess();
                                // Environment.Exit(0);
                            }
                        }
                        else//直接调用
                        {
                            MainProcessOpreate.Instatnce.OpreateMainForm(true);
                        }
                    }
                }
                else//无最新版本
                {
                    if (AppGlobalPool.IsReturn)
                    {
                        Console.Write("0");
                    }
                    else
                    {
                        if (AppGlobalPool.IsPara)//返回参数试调用
                        {
                            MessageBox.Show("您现在使用的是最新版本！"); //提示没有最新版本...
                        }
                        else
                        {
                            MainProcessOpreate.Instatnce.OpreateMainForm(false);
                        }
                    }
                    CloseCurrentProcess();
                    //Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("错误：" + ex.Message.ToString(), ex);
                if (AppGlobalPool.IsReturn)//返回参数试调用
                {
                    Console.Write("-1");
                }
                else
                {
                    MessageBox.Show("错误：" + ex.Message.ToString());
                }
                CloseCurrentProcess();
                //Application.Current.Shutdown();
                //Environment.Exit(0);
            }
        }

        /// <summary>
        /// 程序单实例运行
        /// </summary>
        /// <returns></returns>
        private void SetSingleSelfApp()
        {
            // 单进程运行模式。
            // 获取当前进程
            Process thisProc = Process.GetCurrentProcess();
            Process[] thisProcesses = Process.GetProcessesByName(thisProc.ProcessName);
            // 检查是否有名称相同的进程
            if (thisProcesses.Length > 1)
            {
                CloseCurrentProcess();
            }
        }
        private static void CloseCurrentProcess()
        {
            // 如果有多个名称相同的进程，关闭当前进程
            Current.Shutdown();
            Process.GetCurrentProcess().Kill();
        }
    }
}
