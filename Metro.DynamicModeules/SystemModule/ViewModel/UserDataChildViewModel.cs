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
    [Export(typeof(IMdiChildViewModel))]
    public class UserDataChildViewModel : DataChildBaseViewModel<tb_MyUser>
    {
        BllUser _bllUser;
        BllUserGroup _bllUserGroup = new BllUserGroup();
        protected override Control GetOwner()
        {
            base.GetOwner();
            _flipPanel.FrontContent = new FrontUserView();
            _flipPanel.BackContent = new BackUserView();
            return _flipPanel;
        }


        protected override object GetIcon()
        {
            return new PackIconMaterial { Kind = PackIconMaterialKind.Account };
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
                isid = 7001
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

        protected override Expression<Func<tb_MyUser, bool>> GetSearchExpression()
        {
            string expression;
            object[] values = null;
            if (string.IsNullOrEmpty(SearchText))
            {
                expression = "Account!=@0";
                SearchText = "";
            }
            else
            {
                expression = "Account=@0";
            }
            values = new object[] { SearchText };
            Expression<Func<tb_MyUser, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUser, bool>(expression, values);
            return predicate;
        }

        ObservableCollection<tb_MyUserGroup> _focusedGroups;
        /// <summary>
        /// 当前用户组集合
        /// </summary>
        public ObservableCollection<tb_MyUserGroup> FocusedGroups
        {
            get
            {
                return _focusedGroups;
            }
            set
            {
                _focusedGroups = value;
                RaisePropertyChanged(() => FocusedGroups);
            }
        }
        protected async override void View_CurrentChanged(object sender, EventArgs e)
        {
            base.View_CurrentChanged(sender, e);
            //获取该用户所在组
            FocusedGroups = await _bllUserGroup.GetGroupsByAccount(FocusedRow.Account);
        }
        public string this[string columnName]
        {
            get
            {
                if (null != FocusedRow && columnName == "FocusedRow" && string.IsNullOrEmpty(FocusedRow.Account))
                {
                    return "用户账号不能为空！";
                }
                return null;
            }
        }
    }
}
