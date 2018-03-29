using Metro.DynamicModeules.BLL.Base;
using Metro.DynamicModeules.Models;
using Metro.DynamicModeules.Models.Sys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.BLL.Security
{
   public class BllUserGroup:BllBase<tb_MyUserGroup>
    {
        protected override string GetControllerName()
        {
            return "UserGroup";
        }
        public async  Task<ObservableCollection<tb_MyUserGroup>> GetGroupsByAccount(string userAccount)
        {
            return await WebRequestHelper.PostHttpAsync<ObservableCollection<tb_MyUserGroup>>(GetApiUrl("GetGroupsByAccount"), userAccount);
        }

        public async Task<ObservableCollection<tb_MyUserGroupRe>> GetUserRelationByGroup(string groupCode)
        {
            return await WebRequestHelper.PostHttpAsync<ObservableCollection<tb_MyUserGroupRe>>(GetApiUrl("GetUserRelationByGroup"), groupCode);
        }
        
    }
}
