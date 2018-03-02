using System.Windows.Controls;

namespace Metro.DynamicModeules.Core
{
    /// <summary>
    /// 加载模块管理类(Load Module Manager)
    /// </summary>
    public class ModuleLoader
    {
        private ModuleLoader()
        {
           
        }
        static object _instanceLock = new object();
        ModuleLoader _instance;
        public ModuleLoader Instance
        {
            get
            {
                if(null== _instance)
                {
                    lock (_instanceLock)
                    {
                        if (null == _instance)
                        {
                            _instance = new ModuleLoader();
                        }
                    }
                }
                return _instance;
            }
        }
       

       
        /// <summary>
        /// 加载模块的菜单(支持一个模块内有多个顶级菜单)
        /// </summary>
        /// <param name="menuStrip">程序主窗体的菜单</param>
        public virtual void LoadMenu(Menu moduleMenus)
        {
            //Menu moduleMenu = _ModuleMainForm.GetModuleMenu();//当前模块的菜单
            //if ((moduleMenu == null) || (moduleMenu.Items.Count == 0)) return;

            //if (_ModuleMainForm != null)
            //{
            //    while (moduleMenu.Items.Count > 0)//加载所有顶级菜单
            //    {
            //        int startIndex = moduleMenus.Items.Count == 0 ? 0 : moduleMenus.Items.Count;
            //        moduleMenus.Items.Insert(startIndex, moduleMenu.Items[0]);
            //    }
            //}
        }

        /// <summary>
        /// 加载模块主方法
        /// </summary>
        /// <param name="moduleinfo">模块信息</param>
        /// <returns></returns>
        public virtual bool LoadModule()
        {           
            //_ModuleFileName = moduleinfo.ModuleFile;
            //_ModuleAssembly = moduleinfo.ModuleAssembly;
            //string entry = GetModuleEntryNameSpace(_ModuleAssembly);
            //if (string.Empty == entry) return false;

            //Form form = (Form)_ModuleAssembly.CreateInstance(entry);
            //_ModuleMainForm = null;

            //if (form is ModuleBase) _ModuleMainForm = (ModuleBase)form;

            //return _ModuleMainForm != null;
            return false;
        }

      

        /// <summary>
        /// 获取程序集自定义特性。
        /// </summary>
        /// <returns></returns>
        //public AssemblyModuleEntry GetModuleEntry()
        //{
        //    return ModuleLoaderBase.GetModuleEntry(_ModuleAssembly);
        //}

        /// <summary>
        /// 判断加载的文件是否模块文件，因目录下可能有不同类别的DLL文件。
        /// 判断DLL文件是否框架模块通过检查Assembly特性。
        /// </summary>
        //public bool IsModuleFile(string moduleFile)
        //{
        //    try
        //    {
        //        Assembly asm = Assembly.LoadFile(moduleFile);
        //        return (ModuleLoaderBase.GetModuleID(asm) != ModuleID.None);
        //    }
        //    catch { return false; }
        //}

        /// <summary>
        /// 每一个模块对应一个TabPage, 将模块主窗体的Panel容器放置在TabPage内。
        /// 因此，所有加载的模块主窗体的Panel容器都嵌套在主窗体的TabControl内。
        /// </summary>
        public virtual void LoadGUI(object mainTabControl) { }



        #region 类公共静态方法

        /// <summary>
        /// 查找子菜单，深度搜索
        /// </summary>
        //public static MenuItem GetMenuItem(ToolStrip mainMenu, string menuName)
        //{
        //    ToolStripItem[] items = mainMenu.Items.Find(menuName, true);
        //    if (items.Length > 0 && items[0] is ToolStripMenuItem)
        //        return (ToolStripMenuItem)items[0];
        //    else
        //        return null;
        //}

        /// <summary>
        /// 获取程序集自定义特性。是否用户自定义模块由AssemblyModuleEntry特性确定。
        /// </summary>
        //public static AssemblyModuleEntry GetModuleEntry(Assembly asm)
        //{
        //    AssemblyModuleEntry temp = new AssemblyModuleEntry(ModuleID.None, "", "");
        //    if (asm == null) return temp;
        //    object[] list = asm.GetCustomAttributes(typeof(AssemblyModuleEntry), false);
        //    if (list.Length > 0)
        //        return (AssemblyModuleEntry)list[0];
        //    else
        //        return temp;
        //}

        /// <summary>
        /// 获取模块主窗体名字空间
        /// </summary>
        //public static string GetModuleEntryNameSpace(Assembly asm)
        //{
        //    return GetModuleEntry(asm).ModuleEntryNameSpace;
        //}

        /// <summary>
        /// 获取模块编号
        /// </summary>
        //public static ModuleID GetModuleID(Assembly asm)
        //{
        //    return ModuleLoaderBase.GetModuleEntry(asm).ModuleID;
        //}

        #endregion

        /// <summary>
        /// 判断当前用户是否有该模块的权限
        /// </summary>
        /// <param name="userPermissions">用户权限</param>
        /// <returns></returns>
        //public bool CanAccessModule(DataTable userRights)
        //{
        //    if (Loginer.CurrentUser.IsAdmin()) return true;
        //    MenuStrip mainMenu = _ModuleMainForm.GetModuleMenu();
        //    DataRow[] rows = userRights.Select(string.Format("AuthorityID='{0}'", mainMenu.Items[0].Name));
        //    return rows != null && rows.Length > 0;
        //}

        /// <summary>
        /// 程序集对象引用置空，优化GC回收内存
        /// </summary>
        //public void ClearAssemble()
        //{
        //    _ModuleAssembly = null;
        //    _ModuleMainForm = null;
        //}
    }
}
