/*----------------------------------------------------------------
* Copyright (C) 2015 特友O2O科技 版权所有。
*
* 文件名：DownloadModel.cs
* 功能描述：
*
* Author：陈刚 Time：2016-06-22 17:18:48 
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
    public class DownloadModel
    {
        //public string Url { get; set; }
        public string Directory { get; set; }
        public string Name { get; set; }

    }
    public class FileDownloadModel : DownloadModel
    {
        public string HashMd5 { get; set; }
    }

    public class ScriptDownloadModel : DownloadModel
    {
        public string DataBaseName { get; set; }
        public bool IsUserDataBase { get; set; }

    }
}
