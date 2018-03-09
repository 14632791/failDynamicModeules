namespace Metro.DynamicModeules.Models.Sys
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_MyUserGroup")]
    public partial class tb_MyUserGroup : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MyUserGroup()
        {
            tb_MyUserGroupRole = new HashSet<tb_MyUserGroupRole>();
            tb_MyUser = new HashSet<tb_MyUser>();
        }


        [Key]
        [Column("GroupCode")]
        [StringLength(30)]
        public string GroupCode
        {
            get
            {
                return _GroupCode;
            }
            set
            {
                if (Equals(_GroupCode, value)) return;
                _GroupCode = value;
                RaisePropertyChanged("GroupCode");
            }
        }
        private string _GroupCode;
        [Column("GroupName")]
        [StringLength(100)]
        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                if (Equals(_GroupName, value)) return;
                _GroupName = value;
                RaisePropertyChanged("GroupName");
            }
        }
        private string _GroupName;

        [Column("CreatedBy")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column("CreatedTime")]
        public DateTime? CreatedTime { get; set; }

        [Column("LastUpdateTime")]
        public DateTime? LastUpdateTime { get; set; }

        [Column("LastUpdatedBy")]
        [StringLength(50)]
        public string LastUpdatedBy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyUserGroupRole> tb_MyUserGroupRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_MyUser> tb_MyUser { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
