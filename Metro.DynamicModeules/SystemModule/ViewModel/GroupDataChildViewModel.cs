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
using System.Data;

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
        BllUser _bllUser = new BllUser();

        protected override object GetIcon()
        {
            return new PackIconModern { Kind = PackIconModernKind.Group };
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
        public async override void Initialize()
        {
            base.Initialize();
            //获取所有用户信息
            AllUsers = await _bllUser.GetAllUsers();
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

        #region 用户选择操作
        ObservableCollection<tb_MyUser> _allUsers;
        /// <summary>
        /// 所有用户信息
        /// </summary>
        public ObservableCollection<tb_MyUser> AllUsers
        {
            get
            {
                return _allUsers;
            }
            set
            {
                _allUsers = value;
                RaisePropertyChanged(() => AllUsers);
            }
        }
        /// <summary>
        /// 当前组关系
        /// </summary>
        ObservableCollection<tb_MyUserGroupRe> _currentRelations;
        tb_MyUserGroupRe[] _currentRelationsBak=null;
        protected async override void View_CurrentChanged(object sender, EventArgs e)
        {
            base.View_CurrentChanged(sender, e);
            //获取该组用户集合
            _currentRelations = await _bllGroup.GetUserRelationByGroup(FocusedRow.GroupCode);
            if (null != _currentRelations)
            {
                _currentRelationsBak = new tb_MyUserGroupRe[_currentRelations.Count];
                _currentRelations?.CopyTo(_currentRelationsBak, 0);
            }
            foreach (var item in AllUsers)
            {
                item.DataState = DataRowState.Unchanged;
            }
            DistributionUsers();
        }

        /// <summary>
        /// 分配用户,是否第一次
        /// </summary>
        private void DistributionUsers(bool isFirst=true)
        {
            SelectedUsers = new ObservableCollection<tb_MyUser>();
            EnabledUsers = new ObservableCollection<tb_MyUser>();
            if ( (null== _currentRelations||_currentRelations?.Count < 1)&& isFirst)
            {
                EnabledUsers = AllUsers;
                return;
            }
            IEnumerable<string> userkeys = _currentRelations?.Select(r => r.Account);
            foreach (var user in AllUsers)
            {
                if (null!= userkeys&&userkeys.Contains(user.Account)&& user.DataState == DataRowState.Unchanged || user.DataState == DataRowState.Added)
                {
                    if(user.DataState != DataRowState.Added)
                    {
                        user.DataState = DataRowState.Added;
                    }
                    SelectedUsers.Add(user);
                }
                else
                {
                    EnabledUsers.Add(user);
                }
            }           
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
                return _selectedUserCmd ?? (_selectedUserCmd = new RelayCommand<SelectedUserType>(OnSelectedUser, (userType) =>
                     (userType == SelectedUserType.Selected && null != FocusedEnabledUser || userType == SelectedUserType.SelectedAll) && EnabledUsers?.Count > 0 ||
                     (userType == SelectedUserType.UnSelected && null != FocusedSelectedUser || userType == SelectedUserType.UnSelectedAll) && SelectedUsers?.Count > 0));
            }
        }
        private void OnSelectedUser(SelectedUserType userType)
        {
            switch (userType)
            {    //只做Logic操作，并不是真的add or remove
                case SelectedUserType.Selected:
                    FocusedEnabledUser.DataState = DataRowState.Added;
                    break;
                case SelectedUserType.SelectedAll:
                    foreach (var item in EnabledUsers)
                    {
                        item.DataState = DataRowState.Added;
                    }
                    break;
                case SelectedUserType.UnSelected:
                    FocusedSelectedUser.DataState = DataRowState.Deleted;
                    break;
                case SelectedUserType.UnSelectedAll:
                    foreach (var item in SelectedUsers)
                    {
                        item.DataState = DataRowState.Deleted;
                    }
                    break;
                default:
                    break;
            }
            DistributionUsers(false);
        }

        #endregion
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
