using Metro.DynamicModeules.BaseControls.ViewModel;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SystemModule.Views;

namespace SystemModule.ViewModel
{
    public class UserViewModel : DataChildBaseViewModel<tb_MyUser>
    {
        public override Control GetOwner()
        {
            return new UserView();
        }

        public override void SetButtonAuthority()
        {
            throw new NotImplementedException();
        }
    }
}
