using System;
using System.IO;
using System.Threading;

namespace Metro.DynamicModeules.Common
{
    public enum LogType
    {
        Overall,
        Info,
        Error
    }

    public class LogHelper
    {
        public static string LogPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"log";
            }
        }

        public static void Info(string message, LogType logType = LogType.Info)
        {
            if (string.IsNullOrEmpty(message))
                return;
            var path = string.Format(@"\{0}\", logType.ToString());
            WriteLog(path, "", message);
        }

        public static void Error(string message, LogType logType = LogType.Error)
        {
            if (string.IsNullOrEmpty(message))
                return;
            var path = string.Format(@"\{0}\", logType.ToString());
            WriteLog(path, "Error ", message);
        }

        public static void Error(Exception e, LogType logType = LogType.Error)
        {
            Error("Error ", e);
        }
        public static void Error(string info, Exception ex)
        {
            if (ex == null)
                return;
            Error(string.Format("{0}:{1}\r\n;{2}\r\n", info, ex.Message, ex.StackTrace));
        }
        private static void WriteLog(string path, string prefix, string message)
        {
            ThreadPool.QueueUserWorkItem(callBack =>
            {
                path = LogPath + path;
                var fileName = string.Format("{0}{1}.log", prefix, DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using (FileStream fs = new FileStream(path + fileName, FileMode.Append, FileAccess.Write,
                                                      FileShare.Write, 1024, FileOptions.Asynchronous))
                {
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.ToString("HH:mm:ss fff") + " " + message + "\r\n");
                    IAsyncResult writeResult = fs.BeginWrite(buffer, 0, buffer.Length,
                        (asyncResult) =>
                        {
                            var fStream = (FileStream)asyncResult.AsyncState;
                            fStream.EndWrite(asyncResult);
                        }, fs);
                    fs.Close();
                }
            });
        }
    }
}
