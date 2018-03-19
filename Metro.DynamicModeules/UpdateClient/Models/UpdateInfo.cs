/*----------------------------------------------------------------
* 
* 文件名：UpdateInfo.cs
* 功能描述：
*
* Author：陈刚 Time：2016-06-22 17:20:54 
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateClient.Models
{
    public class UpdateInfo
    {
        public bool NeedUpdate { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string FileDownloadURL { get; set; }
        public string XmlDownloadURL { get; set; }
        public bool Mandatory { get; set; }

        /// <summary>
        /// 下载的部分URL
        /// </summary>
        public string FileDownloadPartURL { get; set; }

        /// <summary>
        /// 下载XML的部分URL
        /// </summary>
        public string XmlDownloadPartURL { get; set; }

    }
}
