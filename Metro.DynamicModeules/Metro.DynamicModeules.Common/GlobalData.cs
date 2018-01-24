using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.Common
{
    public class GlobalData
    {

        /// <summary>
        /// PMS web的根路径 2017.9.14
        /// </summary>
        public static readonly string WEBURL = ConfigHelper.GetConfigString("weburl");

    }
}
