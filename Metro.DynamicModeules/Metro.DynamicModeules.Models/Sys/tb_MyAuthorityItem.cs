namespace Metro.DynamicModeules.Models.Sys
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 功能点字典
    /// </summary>
    [Table("tb_MyAuthorityItem")]
    public partial class tb_MyAuthorityItem : INotifyPropertyChanged
    {
	   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       public tb_MyAuthorityItem()
        {
            tb_MyMenu = new ObservableCollection<tb_MyMenu>();
        }
        /// <summary>
        /// 主键id
        /// </summary>
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
        /// <summary>
        /// 按钮名称
        /// </summary>
        [Column("AuthorityName")]
        [StringLength(20)]
        public string AuthorityName
        {
            get
            {
                return _AuthorityName;
            }
            set
            {
                if (Equals(_AuthorityName, value)) return;
                _AuthorityName = value;
                RaisePropertyChanged("AuthorityName");
            }
        }
        private string _AuthorityName;

        /// <summary>
        /// 按钮的功能点权限值. 只能为2^次方, 1,2,4,8,16,….2^N
        /// </summary>
        [Column("AuthorityValue")]
        public int AuthorityValue
        {
            get
            {
                return _AuthorityValue;
            }
            set
            {
                if (Equals(_AuthorityValue, value)) return;
                _AuthorityValue = value;
                RaisePropertyChanged("AuthorityValue");
            }
        }
        private int _AuthorityValue;
		
	    public virtual ICollection<tb_MyMenu> tb_MyMenu { get; set; }
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
