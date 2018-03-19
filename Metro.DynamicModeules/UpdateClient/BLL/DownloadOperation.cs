using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using UpdateClient.Models;
using UpdateClient.ViewModels;
using UpdateClient.Views;
using UpdateClient.Common;

namespace UpdateClient.BLL
{
    /// <summary>
    /// 下载文件类
    /// </summary>
    public class DownloadOperation
    {
        private int _count;
        private int _rCount = -1;
        private WebClient _webDown;
        private string _dlName;
        private static readonly object _obj = new object();
        private int _isError;
        private static DownloadOperation _instance;
        public static DownloadOperation Instance
        {
            get
            {
                return _instance ?? (_instance = new DownloadOperation());
            }
        }
        private DownloadOperation()
        {
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int DownloadFiles(List<FileDownloadModel> models)
        {
            _count = models.Count;
            foreach (var model in models)
            {
                _rCount++;
                _dlName = model.Name;
                int result = DownLoadFile(model);
                switch (result)
                {
                    case 2:
                        return result;
                    case 3:
                        for (var i = 0; i < 3; i++)
                        {
                            LogHelper.Info("有文件无法下载：");
                            LogHelper.Info(model.JsonSe());
                            result = DownLoadFile(model);
                            if (result == 1 || result == 2) break;
                            if (i == 2 && result == 3) return result;
                        }
                        break;
                }
            }
            return 1;
        }

        private string GetFileDownloadUrl()
        {
            string url = AppGlobalPool.UpdateInfo.FileDownloadURL;
            //if (!string.IsNullOrEmpty(AppGlobalPool.UpdateInfo.FileDownloadPartURL))
            //{
            //    url = string.Format("http://{0}:{1}/{2}", CacheData.UpdateUrl, CacheData.UpdatePort, AppGlobalPool.UpdateInfo.FileDownloadPartURL);
            //}
            return url;
        }
        public int DownLoadFile(DownloadModel model)
        {
            string strSavePath = AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.STempDirectory + model.Directory;
            if (!Directory.Exists(strSavePath))
            {
                Directory.CreateDirectory(strSavePath);
            }
            _webDown = new WebClient();
            try
            {
                _webDown.DownloadProgressChanged += wcDown_DownloadProgressChanged;
                _webDown.DownloadFileCompleted += WcDown_DownloadFileCompleted;
                string remotingUri = AppGlobalPool.UpdateInfo.FileDownloadURL + model.Directory + model.Name;
                LogHelper.Info(string.Format("通过{0}下载文件", remotingUri));
                _dlName = strSavePath + model.Name;
                if (File.Exists(_dlName))
                {
                    File.Delete(_dlName);//如果存在则先删除
                }
                _webDown.DownloadFileAsync(new Uri(remotingUri), _dlName);
                Monitor.Enter(_obj);
                Monitor.Wait(_obj);//终止当前进程，直到脉冲通知
                switch (_isError)
                {
                    case 2:
                    case 3:
                        return _isError;
                    default:
                        return 1;
                }
            }
            catch (Exception e)
            {
                Monitor.PulseAll(_obj);
                Monitor.Exit(_obj);
                LogHelper.Error("下载文件出错：" + JsonHelper.JsonSe(model), e);
                return e.InnerException.Message.Equals(_aboutMsg) ? 2 : 3;
            }
        }
        private const string _aboutMsg = "请求被中止: 请求已被取消。";
        private void WcDown_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    _isError = e.Error.Message.Equals(_aboutMsg) ? 2 : 3;
                    ResultPage.ErrorMsg = e.Error.Message;
                }
                if (Monitor.TryEnter(_obj))
                {
                    Monitor.PulseAll(_obj);//通知所有等待队列进入到就绪队列中
                    Monitor.Exit(_obj);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("下载文件后出错：", ex);
            }
        }
        private double _progressValue;
        private string _progressMsg;
        private static object _lock = new object();
        void wcDown_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                _progressValue = _rCount * 100 / _count; //(100 / _count) * _rCount + e.ProgressPercentage / _count;
                _progressMsg = string.Format("...正在更新 {0}  {1}%", _dlName, e.ProgressPercentage);// _progressValue);// ;
                lock (_lock)
                {
                    DownloadPageViewModels.Instance.PropgressValue = _progressValue;
                    DownloadPageViewModels.Instance.DownloadMsg = _progressMsg;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("wcDown_DownloadProgressChanged下载文件时出错：", ex);
            }
        }
    }
}
