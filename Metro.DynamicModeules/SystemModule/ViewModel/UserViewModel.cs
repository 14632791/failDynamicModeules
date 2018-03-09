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
    [Export(typeof(IMdiChildWindow))]
    public class UserViewModel : DataChildBaseViewModel<tb_MyUser>
    {
        public override Control GetOwner()
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
    }
}
