using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using UpdateClient.Common;

namespace UpdateClient.BLL
{
    public class VersionCompare
    {
        public static VersionCompare Instance = new VersionCompare();
        //{
        //    get
        //    {
        //        return _instance ?? (_instance = new VersionCompare());
        //    }
        //}
        // private static VersionCompare _instance;
        private LocalOperation _localOpration = new LocalOperation();
        // bool _isLoadedLocalConfig = false;
        private VersionCompare()
        {
            Init();
        }
        private void Init()
        {
            try
            {
                string strOldUpdateFile = AppDomain.CurrentDomain.BaseDirectory + "UpdateClient.exe.del";//Application.ExecutablePath
                if (File.Exists(strOldUpdateFile))
                {
                    File.Delete(strOldUpdateFile);
                }
                _localOpration.GetAndSetLocalConfig();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 检查最新版本
        /// </summary>
        /// <returns>true=有最新版本，false=目前是最新版本</returns>
        public bool AsyncHasNewVersion()
        {
            Func<bool> hasNewVersionFunc = new Func<bool>(HasNewVersion);
            IAsyncResult iar = hasNewVersionFunc.BeginInvoke(null, null);
            bool bResult = false;
            if (iar.AsyncWaitHandle.WaitOne(30000))//最多30秒钟
            {
                bResult = hasNewVersionFunc.EndInvoke(iar);
            }
            return bResult;
        }
        public bool HasNewVersion()
        {
            try
            {
                ServerOperation.Instance.GetAndSetServerConfig();
                return !AppGlobalPool.UpdateInfo.Version.Equals(AppGlobalPool.SCurrentVersion);
            }
            catch (Exception ex)
            {
                LogHelper.Error("请检查网络是否正常", ex);
                return false;
            }
        }
        public void GetUpdateList()
        {
            Task.WaitAll(new Task[2] { Task.Factory.StartNew(_localOpration.GetLocalXmlList), Task.Factory.StartNew(ServerOperation.Instance.GetServerXmlList) });
            FiltrUpdateList();
            CheckUpdateSlef();
        }

        private void CheckUpdateSlef()
        {
            AppGlobalPool.IsUpdateSelf = AppGlobalPool.SFileDownloadList.Any(f => string.Compare(AppGlobalPool.SAppFileName, f.Name, true) == 0);
        }
        /// <summary>
        /// 筛选已存在的文件
        /// </summary>
        private void FiltrUpdateList()
        {
            try
            {
                if (AppGlobalPool.SServerXmlFileList == null || AppGlobalPool.SFileDownloadList == null)// AppConfigPool.sLocalXmlFileList == null
                {
                    throw new Exception("空值异常！");
                }
                XmlNodeList xnlLocalList = AppGlobalPool.SLocalXmlFileList.SelectNodes("FileList//File");
                foreach (XmlNode itemLocal in xnlLocalList)
                {
                    AppGlobalPool.SFileDownloadList.RemoveAll(f => string.Compare(f.HashMd5, itemLocal.Attributes["HashMD5"].Value, true) == 0 && string.Compare(f.Directory, itemLocal.Attributes["Directory"].Value, true) == 0);
                }
                //不下载.log文件并去重 2017.6.1 陈刚
                var templst = AppGlobalPool.SFileDownloadList.Where(f => !f.Name.Contains(".log")).Distinct().ToList();
                AppGlobalPool.SFileDownloadList = templst;
            }
            catch (Exception ex)
            {
                // throw ex;
                LogHelper.Error("FiltrUpdateList方法", ex);
            }
        }
    }
}
