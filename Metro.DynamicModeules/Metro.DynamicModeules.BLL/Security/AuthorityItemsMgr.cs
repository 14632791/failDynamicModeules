using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.Security
{
    public enum AuthorityItemType
    {
        /// <summary>
        /// 取消 = 0
        /// </summary>
        Cancel,

        /// <summary>
        /// 系统关闭 = 0
        /// </summary>
        Close,

        /// <summary>
        /// 关闭窗体 = 0
        /// </summary>
        CloseBox,

        /// <summary>
        /// 查看修改历史 = 0
        /// </summary>
        History,

        /// <summary>
        /// 显示帮助信息 = 0
        /// </summary>
        Question,

        /// <summary>
        /// 添加= 1
        /// </summary>
        Add,

        /// <summary>
        /// 删除 = 2
        /// </summary>
        Delete,

        /// <summary>
        /// 修改 = 4
        /// </summary>
        EditBox,

        /// <summary>
        /// 批准 = 8
        /// </summary>
        Approve,

        /// <summary>
        /// 变更 = 16
        /// </summary>
        Change,

        /// <summary>
        /// 打印 = 32
        /// </summary>
        Print,

        /// <summary>
        /// 打印预览 = 64
        /// </summary>
        Preview,

        /// <summary>
        /// 作废 = 128
        /// </summary>
        TrashSolid,

        /// <summary>
        /// 生成单据 = 256
        /// </summary>
        Receipt,

        /// <summary>
        /// 复制单据 = 512
        /// </summary>
        CopySolid,

        /// <summary>
        /// 导出单据 = 1024
        /// </summary>
        Export,

        /// <summary>
        /// 锁定 = 2048
        /// </summary>
        Lock,

        /// <summary>
        /// 保存 = 4096
        /// </summary>
        Save,

        /// <summary>
        /// 附件管理 = 8192
        /// </summary>
        Attachment,

        /// <summary>
        /// 查看版本历史 = 16384
        /// </summary>
        Versions,

        /// <summary>
        /// 查询 = 16384 * 2,
        /// </summary>
        Search
    }
    /// <summary>
    /// 功能点权限管理
    /// </summary>
    public class AuthorityItemsMgr
    { 
        /// <summary>
        /// 这里是本地的所有按钮对象
        /// </summary>
        public static ObservableCollection<tb_MyAuthorityItem> AllAuthorityItems { get; set; }

        = new ObservableCollection<tb_MyAuthorityItem>
        {
        new tb_MyAuthorityItem{
            Code = AuthorityItemType.Cancel .ToString(),AuthorityValue= 0},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Close .ToString(),AuthorityValue= 0},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.CloseBox .ToString(),AuthorityValue= 0},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.History .ToString(),AuthorityValue= 0},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Question .ToString(),AuthorityValue= 0},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Add .ToString(),AuthorityValue= 1},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Delete .ToString(),AuthorityValue= 2},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.EditBox .ToString(),AuthorityValue= 4},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Approve .ToString(),AuthorityValue= 8},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Change .ToString(),AuthorityValue= 16},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Print .ToString(),AuthorityValue= 32},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Preview .ToString(),AuthorityValue= 64},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.TrashSolid .ToString(),AuthorityValue= 128},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Receipt .ToString(),AuthorityValue= 256},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.CopySolid .ToString(),AuthorityValue= 512},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Export .ToString(),AuthorityValue= 1024},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Lock .ToString(),AuthorityValue= 2048},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Save .ToString(),AuthorityValue= 4096},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Attachment .ToString(),AuthorityValue= 8192},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Versions .ToString(),AuthorityValue= 16384},
        new tb_MyAuthorityItem{
            Code =AuthorityItemType.Search .ToString(),AuthorityValue= 16384 * 2},
        };
    }
}
