using MahApps.Metro.IconPacks;
using Metro.DynamicModeules.BaseControls.ControlEx;
using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Interface.Sys;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SystemModule.Views;

namespace SystemModule.ViewModel
{
    /// <summary>
    /// 用户管理界面
    /// </summary>
    [Export(typeof(IMdiChildWindow))]
    public class DataChildUserViewModel : DataChildBaseViewModel<tb_MyUser>
    {
        protected override Control GetOwner()
        {
            return new DataChildBaseView
            {
                Content = new UserFrontView(),
                BackContent = new UserBackView()
            };
        }

        public override void SetButtonAuthority()
        {
            throw new NotImplementedException();
        }

        protected override object GetIcon()
        {
            return new PackIconMaterial { Kind = PackIconMaterialKind.AccountSettingsVariant };
        }      
    }
}
