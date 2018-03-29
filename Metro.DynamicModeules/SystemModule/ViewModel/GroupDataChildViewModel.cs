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
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

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
            base.GetOwner();
            _flipPanel.FrontContent = new FrontGroupView();
            _flipPanel.BackContent = new BackGroupView();
            return _flipPanel;
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
                isid = 7002
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
                expression = "GroupName!=@0";
                SearchText = "";
            }
            else
            {
                expression = "GroupName=@0";
            }
            values = new object[] { SearchText };
            Expression<Func<tb_MyUserGroup, bool>> predicate = SerializeHelper.CreateExpression<tb_MyUserGroup, bool>(expression, values);
            return predicate;
        }

        ObservableCollection<tb_MyUser> _enabledUsers;
        /// <summary>
        /// 可选用户
        /// </summary>
        public ObservableCollection<tb_MyUser> EnabledUsers
        {
            get
            {
                return _enabledUsers;
            }
            set
            {
                _enabledUsers = value;
                RaisePropertyChanged(() => EnabledUsers);
            }
        }
        /// <summary>
        /// 当前选中的可用用户
        /// </summary>
        public tb_MyUser FocusedEnabledUser { get; set; }
        ObservableCollection<tb_MyUser> _selectedUsers;
        /// <summary>
        /// 已选用户
        /// </summary>
        public ObservableCollection<tb_MyUser> SelectedUsers
        {
            get
            {
                return _selectedUsers;
            }
            set
            {
                _selectedUsers = value;
                RaisePropertyChanged(() => SelectedUsers);
            }
        }

        /// <summary>
        /// 当前已选的有焦点的用户
        /// </summary>
        public tb_MyUser FocusedSelectedUser { get; set; }

        ICommand _selectedUserCmd;
        public ICommand SelectedUserCmd
        {
            get
            {
                return _selectedUserCmd ?? (_selectedUserCmd = new RelayCommand<SelectedUserType>(OnSelectedUser));
            }
        }
        private void OnSelectedUser(SelectedUserType userType)
        {
            switch (userType)
            {
                case SelectedUserType.Selected:
                    EnabledUsers.Remove(FocusedEnabledUser);
                    SelectedUsers.Add(FocusedEnabledUser);
                    break;
                case SelectedUserType.SelectedAll:
                    break;
                case SelectedUserType.UnSelected:
                    break;
                case SelectedUserType.UnSelectedAll:
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 用户操作类型
    /// </summary>
    public enum SelectedUserType
    {
        /// <summary>
        /// 选中一个
        /// </summary>
        Selected,

        /// <summary>
        /// 选中所有
        /// </summary>
        SelectedAll,

        /// <summary>
        /// 反选其中一人
        /// </summary>
        UnSelected,

        /// <summary>
        /// 全反选所有
        /// </summary>
        UnSelectedAll
    }
}
