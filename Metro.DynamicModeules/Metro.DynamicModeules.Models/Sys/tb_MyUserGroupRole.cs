namespace Metro.DynamicModeules.Models.Sys
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tb_MyUserGroupRole")]
    public partial class tb_MyUserGroupRole : INotifyPropertyChanged
    {

        [Key]
        [Column("GroupCode",Order = 0)]
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

        [Key]
        [Column("MenuId",Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId {
            get
            {
                return _menuId;
            }
            set
            {
                if (Equals(_menuId, value)) return;
                _menuId = value;
                RaisePropertyChanged("MenuId");
            }
        }
        int _menuId = 0;

        [Column("Authorities")]
        public int Authorities
        {
            get
            {
                return _Authorities;
            }
            set
            {
                if (Equals(_Authorities, value)) return;
                _Authorities = value;
                RaisePropertyChanged("Authorities");
            }
        }
        private int _Authorities;


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

        //[JsonIgnore]
        //public virtual tb_MyMenu tb_MyMenu { get; set; }

        //[JsonIgnore]
        //public virtual tb_MyUserGroup tb_MyUserGroup { get; set; }

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
