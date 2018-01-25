
///*************************************************************************/
///*
///* 文件名    ：BllMenuMgr.cs        
///
///* 程序说明  : 系统菜单数据管理类
///               
///* 原创作者  ：陈刚
///* Copyright 2015 Metro.DynamicModeules software
///*
///**************************************************************************/
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Common;
using Metro.DynamicModeules.Models;
using System.Data;
using System.Windows.Forms;

namespace Metro.DynamicModeules.BLL.Security
{
    /// <summary>
    /// 系统菜单数据管理类
    /// </summary>
    public class BllMenuMgr : BllBase<tb_MyMenu>
    {
        private int _LastUpdated = 0;//最后一次导入菜单更新的记录数
        private int _LastInserted = 0;//最后一次导入菜单数
        private DataTable _AuthorityItem = null; //功能点数据
        private DataTable _FormTagCustomName = null; //功能点自定义名称

    

        /// <summary>
        /// 功能点数据
        /// </summary>
        public DataTable AuthorityItem { get { return _AuthorityItem; } }

        /// <summary>
        /// 功能点自定义名称数据
        /// </summary>
        public DataTable FormTagCustomName { get { return _FormTagCustomName; } }

        /// <summary>
        /// 最后一次导入菜单更新的记录数
        /// </summary>
        public int LastUpdated { get { return _LastUpdated; } }

        /// <summary>
        /// 最后一次导入菜单数
        /// </summary>
        public int LastInserted { get { return _LastInserted; } }

        /// <summary>
        /// 导入菜单数据
        /// </summary>
        /// <param name="mainMenu">系统主菜单</param>
        /// <param name="clearOldData">是否清除旧的菜单数据</param>
        /// <returns></returns>
        public bool ImportMenu(MenuStrip mainMenu, bool clearOldData)
        {
            try
            {
                _LastInserted = 0;
                _LastUpdated = 0;

                if (clearOldData) this.MakeDeletedAll();//清除旧的菜单数据

                foreach (ToolStripItem item in mainMenu.Items)
                {
                    if (item is ToolStripSeparator) continue; //菜单分隔符不处理
                    if (ConvertEx.ToString(item.Tag).ToUpper() == "IsSystemMenu".ToUpper()) continue; //系统菜单不处理

                    if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    {
                        ImportMenuChild(item as ToolStripMenuItem);
                    }
                }

              
                 return true;
            }
            catch
            {               
                return false;
            }
        }

        /// <summary>
        /// 打开删除标记
        /// </summary>
        private void MakeDeletedAll()
        {
            //while (_SummaryTable.Rows.Count > 0)
            //    _SummaryTable.Rows[0].Delete();
        }

        /// <summary>
        /// 剃归导入子菜单
        /// </summary>
        /// <param name="parent">父级菜单</param>
        private void ImportMenuChild(ToolStripMenuItem parent)
        {
            foreach (ToolStripItem item in parent.DropDownItems)
            {
                if (item is ToolStripSeparator) continue; //不导入分隔符

                if ((item.Tag != null) && (item.Tag is MenuItemTag))
                    this.UpdateMenu(item);

                //剃归导入子菜单
                if (item is ToolStripMenuItem && (item as ToolStripMenuItem).DropDownItems.Count > 0)
                    ImportMenuChild(item as ToolStripMenuItem);
            }
        }

        /// <summary>
        /// 更新菜单标题
        /// </summary>
        /// <param name="item"></param>
        private void UpdateMenu(ToolStripItem item)
        {
            MenuItemTag tag = item.Tag as MenuItemTag;
            string filter = string.Format("MenuName='{0}' and ModuleID={1}", item.Name, tag.ModuleID);
            //DataRow[] exists = _SummaryTable.Select(filter);
            //if (exists.Length > 0)
            //{
            //    string caption = ConvertEx.ToString(exists[0][TMenu.MenuCaption]);
            //    if (caption != item.Text)
            //    {
            //        _LastUpdated += 1;
            //        exists[0][TMenu.MenuCaption] = item.Text; //更新菜单标题.
            //    }
            //}
            //else
            //{
            //    DataRow append = _SummaryTable.NewRow();
            //    append[TMenu.Auths] = tag.FormAuthorities;
            //    append[TMenu.MenuCaption] = item.Text;
            //    append[TMenu.MenuName] = item.Name;
            //    append[TMenu.MenuType] = tag.MenuType.ToString();
            //    append[TMenu.ModuleID] = tag.ModuleID;
            //    _SummaryTable.Rows.Add(append);

            //    _LastInserted += 1;
            //}
        }
        
    }
}
