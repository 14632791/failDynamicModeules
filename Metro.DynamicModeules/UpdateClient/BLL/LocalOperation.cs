using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using UpdateClient.Common;
using System.Linq;
using System.Threading;

namespace UpdateClient.BLL
{
    public class LocalOperation
    {

        public void GetAndSetLocalConfig()
        {
            try
            {
                XmlDocument xdXML = new XmlDocument();
                xdXML.Load(AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.SLocalUpdateConfigName);
                XmlElement xmlContent = xdXML.DocumentElement;
                //http://190.15.116.35:9045/api/version/{0}/{1}?version={2}
                string url = xmlContent.SelectSingleNode("UpdateURL").InnerText;// "http://{0}:{1}/api/version/{2}/{3}?version={4}";//
                string ucode = xmlContent.SelectSingleNode("code").InnerText;
                string utype = xmlContent.SelectSingleNode("type").InnerText;
                AppGlobalPool.SCurrentVersion = xmlContent.SelectSingleNode("CurrentVersion").InnerText; //获取当前版本号
                AppGlobalPool.SUpdateUrl = string.Format(url, ucode, utype, AppGlobalPool.SCurrentVersion);
                AppGlobalPool.SAppName = xmlContent.SelectSingleNode("AppName").InnerText; //获取主程序名字
                AppGlobalPool.STempDirectory = string.IsNullOrEmpty(xmlContent.SelectSingleNode("TempFile").InnerText)
                    ? AppGlobalPool.STempDirectory
                    : xmlContent.SelectSingleNode("TempFile").InnerText; //获取更新的文件临时保存路径
            }
            catch (Exception e)
            {
                LogHelper.Error("GetAndSetLocalConfig方法", e);
                throw e;// new Exception("客户端初始化错误，请检查文件是否损坏或重新下载客户端！"+e.Message);
            }
        }

        public void GetLocalXmlList()
        {
            AppGlobalPool.SLocalXmlFileList = new XmlDocument();
            XmlElement xeFileList = AppGlobalPool.SLocalXmlFileList.CreateElement("FileList");
            AppGlobalPool.SLocalXmlFileList.AppendChild(xeFileList);
            SearchDirectory("", xeFileList);
        }

        private List<string> _exclusion = new List<string>
        {
            AppDomain.CurrentDomain.BaseDirectory +"log",
            AppDomain.CurrentDomain.BaseDirectory +"_UpdateTempDirectory",
            AppDomain.CurrentDomain.BaseDirectory +"sdk_log",
            AppDomain.CurrentDomain.BaseDirectory +"SrvLog",
            AppDomain.CurrentDomain.BaseDirectory +"XhStreamSdkLog",
            AppDomain.CurrentDomain.BaseDirectory +"_BackupTempDirectory"
        };

        /// <summary>
        /// 获取本地的文件清单的MD5值清单
        /// </summary>
        /// <param name="strDirStructure"></param>
        /// <param name="xeFileList"></param>
        private void SearchDirectory(string strDirStructure, XmlElement xeFileList)
        {
            try
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory + strDirStructure;
                if (!Directory.Exists(strPath)) return;
                string[] strDirList = Directory.GetDirectories(strPath, "*", SearchOption.AllDirectories);
                //排除不需要的目录
                List<string> realDirList = strDirList.Where(d => !(_exclusion.Contains(d) || _exclusion.Any(ex => d.Contains(ex)))).ToList();
                List<string> strRootFileList = Directory.GetFiles(strPath).ToList();//.Where(f=>f.Contains(".log")).ToList();
                foreach (var dir in realDirList)
                {
                    string strDirName = dir.Substring(dir.LastIndexOf("\\"));
                    SearchDirectory(strDirStructure + strDirName + "\\", xeFileList); //文件夹递归
                }
                foreach (string strFilePath in strRootFileList)
                {
                    XmlElement xeFile = AppGlobalPool.SLocalXmlFileList.CreateElement("File");
                    xeFile.SetAttribute("HashMD5", HashHelper.ComputeMD5(strFilePath));
                    xeFile.SetAttribute("Directory", strDirStructure);
                    xeFile.SetAttribute("Name", Path.GetFileName(strFilePath));
                    xeFileList.AppendChild(xeFile);
                }
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
            }
        }

        /// <summary>
        /// 文件替换锁
        /// </summary>
        private static object _replaceLock = new object();
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public bool BackupFile(out string strMsg)
        {
            string strTempMoveDirectoryPath = AppGlobalPool.STempMoveDirectory;
            foreach (var model in AppGlobalPool.SFileDownloadList)
            {
                string strMoveDirectoryPath = AppGlobalPool.STempMoveDirectory + model.Directory;
                string strMoveFilePath = AppGlobalPool.STempMoveDirectory + model.Directory + model.Name;
                string strOldDirectoryPath = model.Directory;
                string strOldFilePath = strOldDirectoryPath + model.Name;
                if (File.Exists(strMoveFilePath))
                    File.Delete(strMoveFilePath);
                if (!Directory.Exists(strMoveDirectoryPath))
                    Directory.CreateDirectory(strMoveDirectoryPath);
                if (File.Exists(strOldFilePath))
                {
                    try
                    {
                        Monitor.Enter(_replaceLock);
                        File.Move(strOldFilePath, strMoveFilePath);
                    }
                    catch (Exception e)
                    {
                        strMsg = "文件： " + strOldFilePath + " 正在使用，请完全关闭客户端或重新启动电脑再更新！";
                        LogHelper.Error(" BackupFile(out string strMsg)方法", e);
                        return false;
                    }
                    finally
                    {
                        Monitor.Exit(_replaceLock);
                    }
                }
            }
            strMsg = "备份成功！";
            return true;
        }

        /// <summary>
        /// 恢复文件
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="strTarget"></param>
        public void RecoverFiles(string strSource, string strTarget)
        {
            if (!Directory.Exists(strTarget))
            {
                Directory.CreateDirectory(strTarget);
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(strSource);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(strTarget, file.Name), true);
            }
            DirectoryInfo[] directoryInfoArray = directoryInfo.GetDirectories();
            foreach (DirectoryInfo dir in directoryInfoArray)
            {
                RecoverFiles(Path.Combine(strSource, dir.Name), Path.Combine(strTarget, dir.Name));
            }
        }

        private const string _excludeLog = ".log";


        /// <summary>
        /// 替换文件
        /// </summary>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public bool ReplaceFile(out string strMsg)
        {
            try
            {
                foreach (var model in AppGlobalPool.SFileDownloadList)
                {
                    string strMovePath = AppDomain.CurrentDomain.BaseDirectory + model.Directory;
                    string strMoveFilePath = AppDomain.CurrentDomain.BaseDirectory + model.Directory + model.Name;
                    string strOldPath = AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.STempDirectory + model.Directory;
                    if (File.Exists(strMoveFilePath))
                        File.Delete(strMoveFilePath);
                    if (!Directory.Exists(strMovePath))
                        Directory.CreateDirectory(strMovePath);
                    //判断有没有替换到自己
                    //if (string.Compare(AppGlobalPool.SAppFileName, model.Name, true) == 0)
                    //{
                    //    strMoveFilePath += ".del";//
                    //}
                    File.Move(strOldPath + model.Name, strMoveFilePath);
                }
                strMsg = "替换成功！";
                return true;
            }
            catch (Exception ex)
            {
                strMsg = "替换失败：" + ex.Message;
                LogHelper.Error(" ReplaceFile方法", ex);
                return false;
            }
        }

        public void DeleteBackupTempDirectory()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.STempMoveDirectory;
            if (Directory.Exists(strPath))
            {
                try
                {
                    Directory.Delete(strPath, true);
                }
                catch (Exception e)
                {
                    LogHelper.Error(e.Message, e);
                }
            }
            string strTempDirectoryPath = AppDomain.CurrentDomain.BaseDirectory + AppGlobalPool.STempDirectory;
            if (Directory.Exists(strTempDirectoryPath))
            {
                try
                {
                    Directory.Delete(strTempDirectoryPath, true);
                }
                catch (Exception e)
                {
                    LogHelper.Error(e.Message, e);
                }
            }
        }
    }
}