using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Metro.DynamicModeules.Common
{
    public class Security
    {
        public static string GetMd5(FileStream fs)
        {
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            var md5Byte = md5.ComputeHash(fs);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Byte.Length; i++)
            {
                sb.Append(md5Byte[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}