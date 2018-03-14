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

namespace SystemModule.ViewModel
{
    /// <summary>
    /// 用户管理界面
    /// </summary>
    [Export(typeof(IMdiChildWindow))]
    public class DataChildUserViewModel : DataChildBaseViewModel<tb_MyUser>
    {
        BllUser _bllUser;
        protected override Control GetOwner()
        {
            return new DataChildBaseView
            {
                Content = new UserFrontView(),
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

        public override ObservableCollection<tb_MyAuthorityItem> GetAuthoritys()
        {
            throw new NotImplementedException();
        }
    }
}
