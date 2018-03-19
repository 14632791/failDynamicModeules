/*----------------------------------------------------------------
*
* 文件名：CacheData.cs
* 功能描述：
*
* Author：陈刚 Time：2015-10-19 12:50:10 
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
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace UpdateClient.Common
{
    /// <summary>
    /// 通用缓存操作类
    /// </summary>
    internal static class CacheData
    {
        static CacheData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogHelper.Error("CacheData初始化", ex);
            }
        }
        /// <summary>
        /// Service层命名空间的公共路径
        /// </summary>
        public static readonly string AssemblyCommonPath = "Southernfund";
        public static readonly string DefaultConfigPath = @"exe.config";

        private static INIFile _iniSetting = new INIFile(AppDomain.CurrentDomain.BaseDirectory + "Setting.ini");
        private static readonly string SettingSection = "BaseSetting";//by hsz

       
        //public static bool IsAutoEditBmp
        //{
        //    get
        //    {
        //        return Convert.ToBoolean(_iniSetting.IniReadValue(SettingSection, "IsAutoEditBmp"));
        //    }
        //    set
        //    {
        //        _iniSetting.IniWriteValue(SettingSection, "IsAutoEditBmp", value.ToString());
        //    }
        //}


      
        /// <summary>
        /// 读取版本号
        /// </summary>
        /// <returns></returns>
        public static string GetVersionNo()
        {
            string version = "";
            string strConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + "UpdateConfig.xml";
            if (File.Exists(strConfigFilePath))
            {
                XmlDocument xdConfig = new XmlDocument();
                try
                {
                    xdConfig.Load(strConfigFilePath);
                    XmlNode xnVersion = xdConfig.SelectSingleNode("UpdateInfo/CurrentVersion");
                    if (xnVersion != null)
                    {
                        version = xnVersion.InnerText;
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error("GetVersionNo", ex);
                }

            }
            return "V" + version;
        }

      
    }
}
