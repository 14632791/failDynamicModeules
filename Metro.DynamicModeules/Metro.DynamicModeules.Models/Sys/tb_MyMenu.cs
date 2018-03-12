namespace Metro.DynamicModeules.Models.Sys
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    [Table("tb_MyMenu")]
    public partial class tb_MyMenu : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_MyMenu()
        {
            //tb_MyUserGroupRole = new ObservableCollection<tb_MyUserGroupRole>();
            //tb_MyAuthorityItem = new ObservableCollection<tb_MyAuthorityItem>();
        }

        [Key]
        [Column("isid")]
        public int isid
        {
            get
            {
                return _isid;
            }
            set
            {
                if (Equals(_isid, value)) return;
                _isid = value;
                RaisePropertyChanged("isid");
            }
        }
        private int _isid;
        [Column("MenuName")]
        [Required]
        [StringLength(50)]
        public string MenuName
        {
            get
            {
                return _MenuName;
            }
            set
            {
                if (Equals(_MenuName, value)) return;
                _MenuName = value;
                RaisePropertyChanged("MenuName");
            }
        }
        private string _MenuName;
        [Column("MenuCaption")]
        [StringLength(50)]
        public string MenuCaption
        {
            get
            {
                return _MenuCaption;
            }
            set
            {
                if (Equals(_MenuCaption, value)) return;
                _MenuCaption = value;
                RaisePropertyChanged("MenuCaption");
            }
        }
        private string _MenuCaption;
        [Column("Authorities")]
        public int Authorities
        {
            get
            {
                return _Auths;
            }
            set
            {
                if (Equals(_Auths, value)) return;
                _Auths = value;
                RaisePropertyChanged("Authorities");
            }
        }
        private int _Auths;
        [Column("ModuleID")]
        public Nullable<int> ModuleID
        {
            get
            {
                return _ModuleID;
            }
            set
            {
                if (Equals(_ModuleID, value)) return;
                _ModuleID = value;
                RaisePropertyChanged("ModuleID");
            }
        }

        private Nullable<int> _ModuleID;

        [Column("MenuType")]
        [Required]
        [StringLength(20)]
        public string MenuType
        {
            get
            {
                return _menuType;
            }
            set
            {
                if (Equals(_menuType, value)) return;
                _menuType = value;
                RaisePropertyChanged("MenuType");
            }
        }
        private string _menuType;

        //[JsonIgnore]
        //public virtual sys_Modules sys_Modules { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tb_MyUserGroupRole> tb_MyUserGroupRole { get; set; }

        //[JsonIgnore]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<tb_MyAuthorityItem> tb_MyAuthorityItem { get; set; }

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

    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        Unknow = 0,

        /// <summary>
        /// 模块主菜单(一级菜单)
        /// </summary>
        Module = 1, //

        /// <summary>
        /// 数据窗体菜单
        /// </summary>
        DataForm = 2,

        /// <summary>
        /// 父级菜单(下面有子菜单)
        /// </summary>
        ItemOwner = 3,

        /// <summary>
        /// 报表菜单
        /// </summary>
        Report = 4,

        /// <summary>
        /// 独立功能(用于扩展)
        /// </summary>
        Action = 5,

        /// <summary>
        /// 对话框
        /// </summary>
        Dialog = 6
    }
}
