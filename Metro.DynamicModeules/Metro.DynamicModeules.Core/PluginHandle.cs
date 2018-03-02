using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Metro.DynamicModeules.Core
{
    
    /// <summary>
    /// 模块级插件管理
    /// </summary>
    public class PluginHandle : IDisposable
    {

        #region 单例模式
        private PluginHandle()
        {
            InitializePlugins();
        }
        private static object _lockobj = new object();
        private static PluginHandle _instance;
        public static PluginHandle Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockobj)
                    {
                        if (_instance == null)
                        {
                            _instance = new PluginHandle();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        /// <summary>
        /// 存储MEF导出分类
        /// </summary>
        AggregateCatalog catalog = new AggregateCatalog();

        /// <summary>
        /// 存储所有主模块的插件
        /// </summary>
        [ImportMany(typeof(IModuleBase), AllowRecomposition = true)]
        public List<Lazy<IModuleBase>> PluginList { get; set; }

        /// <summary>
        /// 存储插件容器
        /// </summary>
        [Import(typeof(IHost))]
        public Lazy<IHost> Host { get; set; }
        /// <summary>
        /// 初始化插件,在插件容器中初始化
        /// </summary>
        public void InitializePlugins()
        {
            try
            {
                PluginList = new List<Lazy<IModuleBase>>();
                catalog = new AggregateCatalog();
                //添加插件容器中的导出项目录
                catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetEntryAssembly()));
                //添加程序运行路径下的导出项目录
                //catalog.Catalogs.Add(new DirectoryCatalog(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location),"*.dll"));
                //添加插件目录下的导出项目录
                string pluginDir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "MODULES");
                if (System.IO.Directory.Exists(pluginDir))
                {
                    catalog.Catalogs.Add(new DirectoryCatalog(pluginDir, "*.dll"));
                }
                CompositionContainer cc = new CompositionContainer(catalog);
                cc.ComposeParts(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Exec(string name)
        {
            foreach (Lazy<IModuleBase> plugin in PluginList)
            {
                plugin.Value.Initialize();
            }
        }

        /// <summary>
        /// 清理工作、释放内存
        /// </summary>
        public void Dispose()
        {
            catalog.Dispose();
            PluginList.Clear();
            PluginList = null;
        }
    }
   
    /// <summary>
    /// 主界面的载体
    /// </summary>
    public interface IHost
    {
        /// <summary>
        /// 需要加载的模块
        /// </summary>
        /// <param name="info"></param>
        void Exec();

        /// <summary>
        /// 显示加载进度
        /// </summary>
        /// <param name="msg"></param>
        void ShowProgress(string msg);
    }
}
