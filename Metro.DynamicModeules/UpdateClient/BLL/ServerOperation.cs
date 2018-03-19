using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Linq;
using UpdateClient.Common;
using UpdateClient.Models;

namespace UpdateClient.BLL
{
    public class ServerOperation
    {
        private static ServerOperation _instance;
        public static ServerOperation Instance
        {
            get
            {
                return _instance ?? (_instance = new ServerOperation());
            }
        }
        private ServerOperation()
        {

        }

        public void GetAndSetServerConfig()
        {
            try
            {
                XmlDocument xdXML = new XmlDocument();
                AppGlobalPool.SServerJson = GetServiceJson(AppGlobalPool.SUpdateUrl);
                if (!string.IsNullOrEmpty(AppGlobalPool.SServerJson))
                {
                    AppGlobalPool.UpdateInfo = JsonHelper.JsonDe<UpdateInfo>(AppGlobalPool.SServerJson);
                    LogHelper.Info(AppGlobalPool.UpdateInfo?.JsonSe());//记录日志
                    if (AppGlobalPool.UpdateInfo == null)
                    {
                        throw new Exception("获取服务器信息失败！");
                    }
                    //AppGlobalPool.Version = info.Version;//获取最新版本号
                    //AppGlobalPool.Description = info.Description;//获取更新日志信息
                    //AppGlobalPool.XmlDownloadURL = info.XmlDownloadURL;//下载XML地址
                    //AppGlobalPool.Mandatory = info.Mandatory;//是否强制更新
                    //AppGlobalPool.FileDownloadURL = info.FileDownloadURL;//下载地址
                }
                else
                {
                    throw new Exception("获取服务器配置失败！");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("GetAndSetServerConfig方法", ex);
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetServiceJson(string url)
        {
            try
            {
                WebClient client = new WebClient();
                byte[] bResult = client.DownloadData(url);
                return Encoding.UTF8.GetString(bResult);
            }
            catch (WebException webEx)
            {
                LogHelper.Error("GetServiceJson(string url)方法", webEx);
                throw webEx;
            }
            catch (Exception ex)
            {
                LogHelper.Error("GetServiceJson(string url)方法", ex);
                throw ex;
            }
        }

        public void GetServerXmlList()
        {
            try
            {
                string url = AppGlobalPool.UpdateInfo.XmlDownloadURL;
                //if (!string.IsNullOrEmpty(AppGlobalPool.UpdateInfo.XmlDownloadPartURL))
                //{
                //    url = string.Format("http://{0}:{1}/{2}", CacheData.UpdateUrl, CacheData.UpdatePort, AppGlobalPool.UpdateInfo.XmlDownloadPartURL);
                //}
                byte[] byteResult = new WebClient().DownloadData(url);// AppGlobalPool.UpdateInfo.XmlDownloadURL);
                var strResult = Encoding.UTF8.GetString(byteResult);
                XmlDocument xdServerXml = new XmlDocument();
                XmlDocument doc = new XmlDocument();
                xdServerXml.LoadXml(strResult);
                XmlNode xnFileList = xdServerXml.SelectSingleNode("FileList");
                doc.LoadXml(xnFileList.OuterXml);
                AppGlobalPool.SServerXmlFileList = doc;
                ConvertXmlListToList();
            }
            catch (Exception ex)
            {
                throw new Exception("服务器XML解析失败:" + ex.Message.ToString());
            }
        }

        private void ConvertXmlListToList()
        {
            if (AppGlobalPool.SServerXmlFileList == null)
            {
                return;
            }
            XmlNodeList xnlList = AppGlobalPool.SServerXmlFileList.SelectNodes("FileList//File");
            foreach (XmlNode item in xnlList)
            {
                //这里要作去重处理
                if (AppGlobalPool.SFileDownloadList.Any(f => string.Compare(f.Name, item.Attributes["Name"].Value, true) == 0 && string.Compare(f.Directory, item.Attributes["Directory"].Value, true) == 0))
                {
                    continue;
                }
                FileDownloadModel model = new FileDownloadModel();
                model.Name = item.Attributes["Name"].Value;
                model.HashMd5 = item.Attributes["HashMD5"].Value;
                model.Directory = item.Attributes["Directory"].Value;
                AppGlobalPool.SFileDownloadList.Add(model);
            }
        }
    }
}

