
using System;
using System.Drawing;
using System.IO;

namespace Metro.DynamicModeules.Common
{
    /// <summary>
    /// 公共单元
    /// </summary>
    public class Globals
    {
        public const string DEF_PROGRAM_NAME = "HTX-SCM";
        public const string DEF_DATE_FORMAT = "yyyy-MM-dd";// "dd/MM/yyyy";
        public const string DEF_LONE_DATE_FORMAT = "yyyy-MM-dd hh:mm:ss";//"dd/MM/yyyy hh:mm:ss";
        public const string DEF_YYYYMMDD = "yyyyMMdd";
        public const string DEF_YYYYMMDD_LONG = "yyyy-MM-dd";//"yyyy/MM/dd";
        public const string DEF_DATE_LONG_FORMAT = "yyyy-MM-dd hh:mm:ss";//"yyyy/MM/dd hh:mm:ss";                
        public const string DEF_NULL_DATETIME = "1900-1-1";
        public const string DEF_NULL_VALUE = "NULL";          
        public const string DEF_CURRENCY = "RMB";//预设货币
        public const string DEF_DECIMAL_FORMAT = "0.00"; //输出格式        
        public const string DEF_NO_TEXT = "*自动生成*";
        /// <summary>
        /// 系统数据库名。开发框架2.2版支持多帐套管理，帐套表定义在系统数据库。
        /// 打开登录窗体时加载帐套数据给用户选择。        
        /// 
        /// 帐套数据由系统管理员在后台配置，不提供配置窗体。
        /// </summary>
        public const string DEF_SYSTEM_DB = "Metro.DynamicModeules.System";
        public const string DEF_MASTER_DB = "master";

        public const int DEF_DECIMAL_ROUND = 2;//四舍五入小数位

        /// <summary>
        /// 配置文件
        /// </summary>
        public const string INI_CFG = @"\config\user.ini";
        static readonly IniFile _ini ;
        /// <summary>
        /// PMS web的根路径 2017.9.14
        /// </summary>
        public static readonly string WEBURL = ConfigHelper.GetConfigString("weburl");

        static Globals()
        {
            //存在用户配置文件，自动加载登录信息
            string cfgINI = AppDomain.CurrentDomain.BaseDirectory + INI_CFG;
            _ini = new IniFile(cfgINI);
            PageSize=Convert.ToInt32(_ini.IniReadValue("Page", "Size"));
        }

        /// <summary>
        /// 当前页的大小
        /// </summary>
        public static readonly int PageSize;
        /// <summary>
        /// 加载Debug\Images目录下的的图片
        /// </summary>
        /// <param name="imgFileName">文件名</param>
        /// <returns></returns>
        public static Image LoadImage(string imgFileName)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + @"\images\" + imgFileName;
            if (File.Exists(file))
                return Image.FromFile(file);
            else
                return null;
        }

        /// <summary>
        /// 加载Debug\Images目录下的的图片
        /// </summary>
        /// <param name="imgFileName">文件名</param>
        /// <returns></returns>
        public static Bitmap LoadBitmap(string imgFileName)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + @"\images\" + imgFileName;

            if (File.Exists(file))
                return new Bitmap(Image.FromFile(file));
            else
                return null;
        }

       
    }
}
