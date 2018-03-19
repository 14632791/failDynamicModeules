using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace UpdateClient.Common
{
    internal static class RegeditHelper
    {
        /// <summary>
        /// 从UpdateConfig.xml读取最新的版本号
        /// </summary>
        /// <returns></returns>
        public static int GetVersionNo()
        {
            string version = string.Empty;
            int versionToInt = 0;
            string strConfigFilePath = AppDomain.CurrentDomain.BaseDirectory + "UpdateConfig.xml";
            if (File.Exists(strConfigFilePath))
            {
                XmlDocument xdConfig = new XmlDocument();
                try
                {
                    xdConfig.Load(strConfigFilePath);
                    XmlNode xnVersion = xdConfig.SelectSingleNode("UpdateInfo/CurrentVersion");
                    if (!string.IsNullOrEmpty(xnVersion.InnerText))
                    {
                        version = xnVersion.InnerText.Replace(".", "");
                    }
                    versionToInt = Convert.ToInt32(version);
                }
                catch (Exception ex)
                {
                    LogHelper.Error("GetVersionNo", ex);
                    return 0;
                }
            }
            return versionToInt;
        }

        /// <summary>
        /// 将版本信息写入注册表
        /// </summary>
        /// <returns></returns>
        public static void WriteRegeditConfig(int VersionNo)
        {
            try
            {
                string versionStr = "Version";
                RegistryKey hkml = Registry.CurrentUser;
                RegistryKey software = hkml.CreateSubKey("SOFTWARE\\Southernfund");
                if (software != null)
                {
                    software.SetValue(versionStr, VersionNo);
                }
                hkml.Close();
                return;
            }
            catch (Exception ex)
            {
                LogHelper.Error("WriteRegeditConfig", ex);
                return;
            }
        }
    }
}
