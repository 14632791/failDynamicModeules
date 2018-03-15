using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Metro.DynamicModeules.BLL.Security
{
    /// <summary>
    /// 按钮字典主键枚举
    /// </summary>
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
        /// 根据窗体、及其关系表返回对应的button
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="autyItems"></param>
        /// <returns></returns>
        public ObservableCollection<ButtonInfoViewModel> GetButtonsByMeun(tb_MyMenu menu, IDataOperatable operatabler)
        {
            var items = DataDictCache.Instance.AuthorityByItems.Where(i => i.MenuId == menu.isid);
            if (null == items)
            {
                return null;
            }
            var codes = items.Select(i => i.AuthorityCode).Distinct();
            var auths = DataDictCache.Instance.AuthorityItems.Where(i => codes.Contains(i.Code));
            if (null == auths)
            {
                return null;
            }
            ObservableCollection<ButtonInfoViewModel> models = new ObservableCollection<ButtonInfoViewModel>();
            foreach (var item in auths)
            {
                models.Add(GenerateButton(item, operatabler));
            }
            return models;
        }

        public static ButtonInfoViewModel GenerateButton(tb_MyAuthorityItem item, IDataOperatable operatabler)
        {
            AuthorityItemType autyType;
            Enum.TryParse(item.Code, out autyType);
            return GenerateButton(autyType, operatabler);
        }
        /// <summary>
        /// 生成按钮对象
        /// </summary>
        /// <param name="authType"></param>
        /// <param name="operatabler"></param>
        /// <returns></returns>
        public static ButtonInfoViewModel GenerateButton(AuthorityItemType authType, IDataOperatable operatabler)
        {
            ButtonInfoViewModel button = null;
            switch (authType)
            {
                case AuthorityItemType.Add:
                    button = new ButtonInfoViewModel(new PackIconModern { Kind = PackIconModernKind.EditAdd },
                    new tb_MyAuthorityItem
                    {
                        Code = AuthorityItemType.Add.ToString(),
                        AuthorityValue = 1,
                        AuthorityName = "添加"
                    }, operatabler.DoAdd);
                    break;
                case AuthorityItemType.Approve:
                    button = new ButtonInfoViewModel(new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.SmileRegular },
       new tb_MyAuthorityItem
       {
           Code = AuthorityItemType.Approve.ToString(),
           AuthorityValue = 8,
           AuthorityName = "批准"
       }, operatabler.DoAdd);
                    break;
                case AuthorityItemType.Attachment:
                    button = new ButtonInfoViewModel(new PackIconEntypo { Kind = PackIconEntypoKind.Attachment },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Attachment.ToString(),
            AuthorityValue = 8192,
            AuthorityName = "附件管理"
        }, operatabler.DoAttachment);
                    break;
                case AuthorityItemType.Cancel:
                    button = new ButtonInfoViewModel(new PackIconModern { Kind = PackIconModernKind.Cancel },
               new tb_MyAuthorityItem
               {
                   Code = AuthorityItemType.Cancel.ToString(),
                   AuthorityValue = 0,
                   AuthorityName = "取消"
               }, operatabler.DoCancel);
                    break;
                case AuthorityItemType.Change:
                    button = new ButtonInfoViewModel(new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.ExchangeAltSolid },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Change.ToString(),
            AuthorityValue = 16,
            AuthorityName = "变更"
        }, operatabler.DoChange);
                    break;
                case AuthorityItemType.Close:
                    button = new ButtonInfoViewModel(new PackIconMaterial { Kind = PackIconMaterialKind.Close },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Close.ToString(),
            AuthorityValue = 0,
            AuthorityName = "系统关闭"
        }, operatabler.DoClose);
                    break;
                case AuthorityItemType.CloseBox:
                    button = new ButtonInfoViewModel(new PackIconMaterial { Kind = PackIconMaterialKind.CloseBox },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.CloseBox.ToString(),
            AuthorityValue = 0,
            AuthorityName = "关闭窗体"
        }, operatabler.DoCloseBox);
                    break;
                case AuthorityItemType.CopySolid:
                    button = new ButtonInfoViewModel(new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.CopySolid },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.CopySolid.ToString(),
            AuthorityValue = 512,
            AuthorityName = "复制单据"
        }, operatabler.DoCopySolid);
                    break;
                case AuthorityItemType.Delete:
                    button = new ButtonInfoViewModel(new PackIconMaterialLight { Kind = PackIconMaterialLightKind.Delete },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Delete.ToString(),
            AuthorityValue = 2,
            AuthorityName = "删除"
        }, operatabler.DoDelete);
                    break;
                case AuthorityItemType.EditBox:
                    button = new ButtonInfoViewModel(new PackIconModern { Kind = PackIconModernKind.EditBox },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.EditBox.ToString(),
            AuthorityValue = 4,
            AuthorityName = "修改"
        }, operatabler.DoEdit);
                    break;
                case AuthorityItemType.Export:
                    button = new ButtonInfoViewModel(new PackIconEntypo { Kind = PackIconEntypoKind.Export },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Export.ToString(),
            AuthorityValue = 1024,
            AuthorityName = "导出单据"
        }, operatabler.DoExport);
                    break;
                case AuthorityItemType.History:
                    button = new ButtonInfoViewModel(new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.HistorySolid },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.History.ToString(),
            AuthorityValue = 0,
            AuthorityName = "查看修改历史"
        }, operatabler.DoHistory);
                    break;
                case AuthorityItemType.Lock:
                    button = new ButtonInfoViewModel(new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.LockSolid },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Lock.ToString(),
            AuthorityValue = 2048,
            AuthorityName = "锁定"
        }, operatabler.DoLock);
                    break;
                case AuthorityItemType.Preview:
                    button = new ButtonInfoViewModel(new PackIconMaterial { Kind = PackIconMaterialKind.FileFind },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Preview.ToString(),
            AuthorityValue = 64,
            AuthorityName = "打印预览"
        }, operatabler.DoPreview);
                    break;
                case AuthorityItemType.Print:
                    button = new ButtonInfoViewModel(new PackIconEntypo { Kind = PackIconEntypoKind.Print },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Print.ToString(),
            AuthorityValue = 32,
            AuthorityName = "打印"
        }, operatabler.DoPrint);
                    break;
                case AuthorityItemType.Question:
                    button = new ButtonInfoViewModel(new PackIconOcticons { Kind = PackIconOcticonsKind.Question },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Question.ToString(),
            AuthorityValue = 0,
            AuthorityName = "显示帮助信息"
        }, operatabler.DoHelp);
                    break;
                case AuthorityItemType.Receipt:
                    button = new ButtonInfoViewModel(new PackIconMaterial { Kind = PackIconMaterialKind.Receipt },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Receipt.ToString(),
            AuthorityValue = 256,
            AuthorityName = "生成单据"
        }, operatabler.DoReceipt);
                    break;
                case AuthorityItemType.Save:
                    button = new ButtonInfoViewModel(new PackIconEntypo { Kind = PackIconEntypoKind.Save },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Save.ToString(),
            AuthorityValue = 4096,
            AuthorityName = "保存"
        }, operatabler.DoSave);
                    break;
                case AuthorityItemType.Search:
                    button = new ButtonInfoViewModel(new PackIconOcticons { Kind = PackIconOcticonsKind.Search },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Search.ToString(),
            AuthorityValue = 16384 * 2,
            AuthorityName = "查询"
        }, operatabler.DoSearch);
                    break;
                case AuthorityItemType.TrashSolid:
                    button = new ButtonInfoViewModel(new PackIconFontAwesome { Kind = PackIconFontAwesomeKind.TrashSolid },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.TrashSolid.ToString(),
            AuthorityValue = 128,
            AuthorityName = "作废"
        }, operatabler.DoTrashSolid);
                    break;
                case AuthorityItemType.Versions:
                    button = new ButtonInfoViewModel(new PackIconOcticons { Kind = PackIconOcticonsKind.Versions },
        new tb_MyAuthorityItem
        {
            Code = AuthorityItemType.Versions.ToString(),
            AuthorityValue = 16384,
            AuthorityName = "历史版本"
        }, operatabler.DoVersions);
                    break;
                default:
                    break;
            }
            return button;
        }
    }
}
