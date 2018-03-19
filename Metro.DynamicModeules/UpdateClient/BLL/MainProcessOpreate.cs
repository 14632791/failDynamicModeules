
using UpdateClient.Common;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace UpdateClient.BLL
{
    public class MainProcessOpreate
    {
        public static readonly MainProcessOpreate Instatnce = new MainProcessOpreate();
       
        private MainProcessOpreate() { }
        /// <summary>
        /// true关闭 或 false 运行 主程序
        /// </summary>
        /// <param name="isClose">true关闭 false 运行</param>
        public bool OpreateMainForm(bool isClose)
        {
            Process mainProcess = Process.GetProcesses().Where(p => p.ProcessName.ToUpper() == AppGlobalPool.SAppName.ToUpper()).SingleOrDefault();
            if (isClose)
            {
                if (null != mainProcess)
                {
                    mainProcess.Kill();
                }
            }
            else
            {
                try
                {
                    if (null == mainProcess)
                    {
                        Process.Start(AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.SAppName + ".exe");
                    }
                    return true;
                }
                catch (Exception)
                {
                    MessageBox.Show("找不到指定运行的主程序！");
                }
            }
            return false;
        }

        /// <summary>
        /// 是否有主程序在运行
        /// </summary>
        /// <returns></returns>
        public bool HasMainForm()
        {
            Process[] ps = Process.GetProcesses();
            return ps.Any(p => p.ProcessName.ToUpper() == AppGlobalPool.SAppName.ToUpper());
        }

        /// <summary>
        /// 检查主程序是不是只有一个
        /// </summary>
        /// <returns></returns>
        public bool IsSingleMainForm()
        {
            string strCurProcessName = AppGlobalPool.SAppName.ToUpper();
            Process[] pro = Process.GetProcessesByName(strCurProcessName);
            bool isExist = pro.Length > 0;
            return isExist;
        }

    }
}
