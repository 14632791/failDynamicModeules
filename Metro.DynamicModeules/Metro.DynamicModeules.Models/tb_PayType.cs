namespace Metro.DynamicModeules.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tb_PayType")]
    public partial class tb_PayType : INotifyPropertyChanged
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        [Column("PayType")]
        [Key]
        [StringLength(10)]
        public string PayType
        {
            get
            {
                return _PayType;
            }
            set
            {
                if (Equals(_PayType, value)) return;
                _PayType = value;
                RaisePropertyChanged("PayType");
            }
        }
        private string _PayType;
        [Column("TypeName")]
        [StringLength(20)]
        public string TypeName
        {
            get
            {
                return _TypeName;
            }
            set
            {
                if (Equals(_TypeName, value)) return;
                _TypeName = value;
                RaisePropertyChanged("TypeName");
            }
        }
        private string _TypeName;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
