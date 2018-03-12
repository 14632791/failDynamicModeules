using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Metro.DynamicModeules.Common.DEncrypt;
using Metro.DynamicModeules.Common;

namespace Metro.DynamicModeules.BLL.Base
{
    internal class WebRequestHelper
    {
        public static string Token { get; set; }
        public static string WebApiUrl { get; set; }

        /// <summary>
        /// 创建GET方式的HTTP同步请求  
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="parameters">参数</param>
        public static T GetHttp<T>(string url, IDictionary<string, string> parameters, string id = "", string name = "", int timeout = 6000)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }
            parameters.Add("t", DateTime.Now.Millisecond.ToString());
            if (parameters != null && parameters.Count != 0)
            {
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        url += string.Format("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        url += string.Format("?{0}={1}", key, parameters[key]);
                        i++;
                    }
                }
            }
            string resultStr = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //APIcontroller的加密 2015.10.22
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
                {
                    HttpHeadEncryption(request, id, name);
                }
                request.Timeout = timeout;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                resultStr = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
            }
            T rslt = default(T);//new T();
            if (resultStr == "")//请求失败
            {
                rslt = default(T);
            }
            else
            {
                try
                {
                    rslt = resultStr.JsonDe<T>();
                }
                catch (Exception e)
                {
                    rslt = default(T);
                    LogHelper.Error(e);//WriteLog(new LogMessage { UserId = 0, UserName = "sys", Info = "JsonDe<" + typeof(T) + ">" }, e);
                }
            }
            return rslt;
        }

        /// <summary>
        /// 创建POST方式的HTTP同步请求  
        /// </summary>
        /// <param name="url">请求的url</param>
        /// <param name="parameters">参数</param>
        /// <param name="id">ID 加密要用到</param>
        /// <param name="name">姓名 加密要用到</param>
        /// <returns></returns>
        public static T PostHttp<T>(string url, object parameters, string id = "", string name = "", int timeout = 10000)
        {
            string resultStr = "";
            string jsonstr = "";
            if (parameters != null)
            {
                jsonstr = parameters.JsonSe();
            }
            byte[] encodeddata = Encoding.UTF8.GetBytes(jsonstr);
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //APIcontroller的加密 2015.10.22
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
                {
                    HttpHeadEncryption(request, id, name);
                }
                request.Timeout = timeout;
                request.Method = "Post";
                request.ContentType = "text/json; charset=utf-8";
                request.ContentLength = encodeddata.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(encodeddata, 0, encodeddata.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                resultStr = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                LogHelper.Error(e);
            }

            T rslt = default(T);
            if (resultStr == "")//请求失败
            {
                rslt = default(T);
            }
            else
            {
                try
                {
                    rslt = resultStr.JsonDe<T>();
                }
                catch (Exception e)
                {
                    rslt = default(T);
                    LogHelper.Error(e);
                }
            }
            return rslt;
        }

        public static async Task<T> PostHttpAsync<T>(string url, object parameters, string id = "", string name = "")
        {
            return await Task.Factory.StartNew(() =>
            {
                return PostHttp<T>(url, parameters, id, name);
            });
        }

        
        /// <summary>
        /// 对HttpWebRequest的head进行加密 2015.10.02
        /// </summary>
        /// <param name="request">HttpWebRequest对象</param>
        /// <param name="id"> ID</param>
        /// <param name="name">名称，没有名称则使用手机号码</param>
        /// <param name="Sign">签名值</param>
        private static void HttpHeadEncryption(HttpWebRequest request, string id, string name)
        {
            name = HttpUtility.UrlEncode(name);
            request.Headers.Add("id", id);
            request.Headers.Add("name", name);
            string sign = SignRequest(id, name);
            request.Headers.Add("sign", sign);
        }

        /// <summary>
        /// 生成签名字符串 2015.10.02
        /// </summary>
        /// <param name="id">商家ID</param>
        /// <param name="name">商家名称，没有名称则使用手机号码</param>
        /// <returns></returns>
        private static string SignRequest(string id, string name)
        {
            string unSign = Token + id + name + Token;
            return DEncrypts.Get32Md5Str(unSign).ToUpper();
        }
    }
}
