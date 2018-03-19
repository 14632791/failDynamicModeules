/*----------------------------------------------------------------
* Copyright (C) 2017 星火 版权所有。
*
* 文件名：AppGlobalPool.cs
* 功能描述：
*
* Author：陈刚 Time：2016-06-22 17:17:43 
*
* 修改标识：
* 修改描述：
*
* 修改标识：
* 修改描述：
*
*----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Xml;
using UpdateClient.Models;

namespace UpdateClient.Common
{
    public class AppGlobalPool
    {

        #region 私有成员
        private static readonly XmlNode _node;
        static AppGlobalPool()
        {
            STempMoveDirectory = "_BackupTempDirectory\\";
            SAppFileName = "UpdateClient.exe";
            STempDirectory = "_UpdateTempDirectory\\";//默认
            SFileDownloadList = new List<FileDownloadModel>();
            SScriptDownloadList = new List<ScriptDownloadModel>();
            _node = XMLHelper.GetXmlNodeByXpath(AppDomain.CurrentDomain.BaseDirectory + "UpdateConfig.xml", "//UpdateInfo//CurrentVersion");
            OldVersion = null == _node ? "" : _node.InnerText;
        }
        #endregion

        #region 公有成员

        public static readonly string OldVersion;
        public const string SLocalUpdateConfigName = "UpdateConfig.xml";
        public static readonly string SAppFileName;
        public static readonly string STempMoveDirectory;

        /// <summary>
        /// 地址
        /// </summary>
        public static string Url { get; set; }
        public static string STempDirectory
        {
            get;
            set;
        }
        /// <summary>
        /// 服务端的文件清单
        /// </summary>
        public static List<FileDownloadModel> SFileDownloadList
        {
            get;
            set;
        }
        public static List<ScriptDownloadModel> SScriptDownloadList
        {
            get;
            set;
        }

        
        public static string SUpdateUrl
        {
            get;
            set;
        }

        public static string SCurrentVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 运行的主程序
        /// </summary>
        public static string SAppName
        {
            get;
            set;
        }

        /// <summary>
        /// 本地XML结构
        /// </summary>
        public static XmlDocument SLocalXmlFileList
        {
            get;
            set;
        }

        /// <summary>
        /// 服务器更新XML
        /// </summary>
        public static string SServerJson
        {
            get;
            set;
        }

        /// <summary>
        /// 服务器文件下载列表
        /// </summary>
        public static XmlDocument SServerXmlFileList
        {
            get;
            set;
        }

        /// <summary>
        /// 服务器脚本文件下载列表
        /// </summary>
        public static XmlNode SServerXmlScriptFileList
        {
            get;
            set;
        }
     

        /// <summary>
        /// 是否为返回参数试调用 
        /// </summary>
        public static bool IsPara
        {
            get;
            set;
        } = false;

        /// <summary>
        ///  是否为外部程序调用
        /// </summary>
        public static bool IsReturn
        {
            get;
            set;
        } = false;
       

        public static bool IsUpdateSelf
        {
            get;
            set;
        }
        
        public static UpdateInfo UpdateInfo { get; set; }
       
        #endregion
    }
}
