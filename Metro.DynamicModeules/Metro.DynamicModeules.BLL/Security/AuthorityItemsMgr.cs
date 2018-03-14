using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.Security
{

    /// <summary>
    /// 功能点权限管理
    /// </summary>
    public class AuthorityItemsMgr
    {
        #region 按钮的权限变量
        /// <summary>
        /// 取消
        /// </summary>
        public static readonly int Cancel = 0;

        /// <summary>
        /// 系统关闭
        /// </summary>
        public static readonly int Close = 0;

        /// <summary>
        /// 关闭窗体
        /// </summary>
        public static readonly int CloseBox = 0;

        /// <summary>
        /// 查看修改历史
        /// </summary>
        public static readonly int History = 0;

        /// <summary>
        /// 显示帮助信息
        /// </summary>
        public static readonly int Question = 0;

        /// <summary>
        /// 添加
        /// </summary>
        public static readonly int Add = 1;

        /// <summary>
        /// 删除
        /// </summary>
        public static readonly int Delete = 2;

        /// <summary>
        /// 修改
        /// </summary>
        public static readonly int EditBox = 4;

        /// <summary>
        /// 批准
        /// </summary>
        public static readonly int Approve = 8;

        /// <summary>
        /// 变更
        /// </summary>
        public static readonly int Change = 16;

        /// <summary>
        /// 打印
        /// </summary>
        public static readonly int Print = 32;

        /// <summary>
        /// 打印预览
        /// </summary>
        public static readonly int Preview = 64;

        /// <summary>
        /// 作废
        /// </summary>
        public static readonly int TrashSolid = 128;

        /// <summary>
        /// 生成单据
        /// </summary>
        public static readonly int Receipt = 256;

        /// <summary>
        /// 复制单据
        /// </summary>
        public static readonly int CopySolid = 512;

        /// <summary>
        /// 导出单据
        /// </summary>
        public static readonly int Export = 1024;

        /// <summary>
        /// 锁定
        /// </summary>
        public static readonly int Lock = 2048;

        /// <summary>
        /// 保存
        /// </summary>
        public static readonly int Save = 4096;

        /// <summary>
        /// 附件管理
        /// </summary>
        public static readonly int Attachment = 8192;

        /// <summary>
        /// 查看版本历史
        /// </summary>
        public static readonly int Versions = 16384;

        /// <summary>
        /// 查询
        /// </summary>
        public static readonly int Search = 16384 * 2;

        #endregion

        public static ObservableCollection<tb_MyAuthorityItem> AuthorityItems { get; set; }
        = new ObservableCollection<tb_MyAuthorityItem>
        {

        };
    }
}
