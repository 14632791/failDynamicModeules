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
    /// 用户管理界面
    /// </summary>
    [Export(typeof(IMdiChildView))]
    public class DataChildUserViewModel : DataChildBaseViewModel<tb_MyUser>
    {
        BllUser _bllUser;
        protected override Control GetOwner()
        {
            return new FlipPanel
            {
                FrontContent = new UserFrontView(),
                BackContent = new UserBackView()
            };
        }


        protected override object GetIcon()
        {
            return new PackIconMaterial { Kind = PackIconMaterialKind.AccountSettingsVariant };
        }

        protected override BllBase<tb_MyUser> InitBll()
        {
            _bllUser = new BllUser();
            return _bllUser;
        }

        protected override async Task<tb_MyMenu> GetMenu()
        {
            tb_MyMenu myMenu = new tb_MyMenu
            {
                MenuName = "menuItemUserMgr",
                MenuCaption = "用户管理",
                MenuType = MenuType.DataForm.ToString(),
                //ModuleID = Module.ModuleID
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

        public override async void RefreshDataSource()
        {
            Expression<Func<tb_MyUser, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUser, bool>("Account!=@0", new object[] { "" });
            //获取所有用户数据
            DataSource = await _bllUser.GetSearchList(predicate);
        }

    }
}
