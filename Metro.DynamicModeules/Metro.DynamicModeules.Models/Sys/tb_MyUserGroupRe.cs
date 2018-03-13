namespace Metro.DynamicModeules.Models.Sys
{
    using Metro.DynamicModeules.Models.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_MyUserGroupRe")]
    public partial class tb_MyUserGroupRe: NotifyPropertyChanged
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string GroupCode
        {
            get
            {
                return _groupCode;
            }
            set
            {
                if (Equals(_groupCode, value)) return;
                _groupCode = value;
                RaisePropertyChanged("GroupCode");
            }
        }
        string _groupCode;

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Account
        {
            get
            {
                return _account;
            }
            set
            {
                if (Equals(_account, value)) return;
                _account = value;
                RaisePropertyChanged("Account");
            }
        }
        string _account;
    }
}
