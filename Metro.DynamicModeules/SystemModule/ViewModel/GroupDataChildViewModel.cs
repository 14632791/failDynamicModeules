using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.BaseControls.ControlEx;
using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.BLL.Security;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SystemModule.Views;
using System.Collections.ObjectModel;
using Metro.DynamicModeules.Common.ExpressionSerialization;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SystemModule.ViewModel
{
    /// <summary>
    /// 用户组管理界面
    /// </summary>
    [Export(typeof(IMdiChildViewModel))]
    public class GroupDataChildViewModel : DataChildBaseViewModel<tb_MyUserGroup>
    {
        BllUserGroup _bllGroup;
        protected override Control GetOwner()
        {
            FlipPanel flip = new FlipPanel();
            flip.IsFlipped = false;
            flip.FrontContent = new FrontGroupView();
            flip.BackContent = new BackGroupView();
            return flip;
        }


        protected override object GetIcon()
        {
            return new PackIconMaterial { Kind = PackIconMaterialKind.AccountSettingsVariant };
        }

        protected override BllBase<tb_MyUserGroup> InitBll()
        {
            _bllGroup = new BllUserGroup();
            return _bllGroup;
        }

        protected override async Task<tb_MyMenu> GetMenu()
        {
            tb_MyMenu myMenu = new tb_MyMenu
            {
                MenuName = "menuItemUserGroupMgr",
                MenuCaption = "用户组管理",
                MenuType = MenuType.DataForm.ToString(),
                isid=7002
            };
            Expression<Func<tb_MyMenu, bool>> predicate = SerializeHelper.CreateExpression<tb_MyMenu, bool>("MenuName=@0", new object[] { myMenu.MenuName });
            BllMenu _bllMenu = new BllMenu();
            var menus = await _bllMenu.GetSearchList(predicate);
            if (null != menus && menus.Count > 0)
            {
                var menu = menus.First();
                myMenu.isid = menu.isid;
                myMenu.Authorities = menu.Authorities;
            }
            return myMenu;
        }
        
        protected override Expression<Func<tb_MyUserGroup, bool>> GetSearchExpression()
        {
            string expression;
            object[] values = null;
            if (string.IsNullOrEmpty(SearchText))
            {
                expression = "GroupName!=''";
            }
            else
            {
                expression = "GroupName=@0";
                values = new object[] { SearchText };
            }
            Expression<Func<tb_MyUserGroup, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUserGroup, bool>(expression,values);
            return predicate;
        }                
    }
}
