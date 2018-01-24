namespace Metro.DynamicModeules.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tb_PO")]
    public partial class tb_PO : INotifyPropertyChanged
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ISID")]
        public int ISID
        {
            get
            {
                return _ISID;
            }
            set
            {
                if (Equals(_ISID, value)) return;
                _ISID = value;
                RaisePropertyChanged("ISID");
            }
        }
        private int _ISID;
        [Column("PONO")]
        [Key]
        [StringLength(20)]
        public string PONO
        {
            get
            {
                return _PONO;
            }
            set
            {
                if (Equals(_PONO, value)) return;
                _PONO = value;
                RaisePropertyChanged("PONO");
            }
        }
        private string _PONO;
        [Column("PODate")]
        public Nullable<System.DateTime> PODate
        {
            get
            {
                return _PODate;
            }
            set
            {
                if (Equals(_PODate, value)) return;
                _PODate = value;
                RaisePropertyChanged("PODate");
            }
        }
        private Nullable<System.DateTime> _PODate;
        [Column("POUser")]
        [StringLength(20)]
        public string POUser
        {
            get
            {
                return _POUser;
            }
            set
            {
                if (Equals(_POUser, value)) return;
                _POUser = value;
                RaisePropertyChanged("POUser");
            }
        }
        private string _POUser;
        [Column("CustomerCode")]
        [StringLength(20)]
        public string CustomerCode
        {
            get
            {
                return _CustomerCode;
            }
            set
            {
                if (Equals(_CustomerCode, value)) return;
                _CustomerCode = value;
                RaisePropertyChanged("CustomerCode");
            }
        }
        private string _CustomerCode;
        [Column("CustomerContact")]
        [StringLength(20)]
        public string CustomerContact
        {
            get
            {
                return _CustomerContact;
            }
            set
            {
                if (Equals(_CustomerContact, value)) return;
                _CustomerContact = value;
                RaisePropertyChanged("CustomerContact");
            }
        }
        private string _CustomerContact;
        [Column("CustomerTel")]
        [StringLength(20)]
        public string CustomerTel
        {
            get
            {
                return _CustomerTel;
            }
            set
            {
                if (Equals(_CustomerTel, value)) return;
                _CustomerTel = value;
                RaisePropertyChanged("CustomerTel");
            }
        }
        private string _CustomerTel;
        [Column("PayType")]
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
        [Column("CustomerOrderNo")]
        [StringLength(20)]
        public string CustomerOrderNo
        {
            get
            {
                return _CustomerOrderNo;
            }
            set
            {
                if (Equals(_CustomerOrderNo, value)) return;
                _CustomerOrderNo = value;
                RaisePropertyChanged("CustomerOrderNo");
            }
        }
        private string _CustomerOrderNo;
        [Column("Currency")]
        [StringLength(4)]
        public string Currency
        {
            get
            {
                return _Currency;
            }
            set
            {
                if (Equals(_Currency, value)) return;
                _Currency = value;
                RaisePropertyChanged("Currency");
            }
        }
        private string _Currency;
        [Column("Amount", TypeName = "numeric")]
        public Nullable<decimal> Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (Equals(_Amount, value)) return;
                _Amount = value;
                RaisePropertyChanged("Amount");
            }
        }
        private Nullable<decimal> _Amount;
        [Column("Remark")]
        [StringLength(200)]
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                if (Equals(_Remark, value)) return;
                _Remark = value;
                RaisePropertyChanged("Remark");
            }
        }
        private string _Remark;
        [Column("CreationDate")]
        public Nullable<System.DateTime> CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                if (Equals(_CreationDate, value)) return;
                _CreationDate = value;
                RaisePropertyChanged("CreationDate");
            }
        }
        private Nullable<System.DateTime> _CreationDate;
        [Column("CreatedBy")]
        [StringLength(20)]
        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                if (Equals(_CreatedBy, value)) return;
                _CreatedBy = value;
                RaisePropertyChanged("CreatedBy");
            }
        }
        private string _CreatedBy;
        [Column("LastUpdateDate")]
        public Nullable<System.DateTime> LastUpdateDate
        {
            get
            {
                return _LastUpdateDate;
            }
            set
            {
                if (Equals(_LastUpdateDate, value)) return;
                _LastUpdateDate = value;
                RaisePropertyChanged("LastUpdateDate");
            }
        }
        private Nullable<System.DateTime> _LastUpdateDate;
        [Column("LastUpdatedBy")]
        [StringLength(50)]
        public string LastUpdatedBy
        {
            get
            {
                return _LastUpdatedBy;
            }
            set
            {
                if (Equals(_LastUpdatedBy, value)) return;
                _LastUpdatedBy = value;
                RaisePropertyChanged("LastUpdatedBy");
            }
        }
        private string _LastUpdatedBy;
        [Column("FlagApp")]
        [StringLength(1)]
        public string FlagApp
        {
            get
            {
                return _FlagApp;
            }
            set
            {
                if (Equals(_FlagApp, value)) return;
                _FlagApp = value;
                RaisePropertyChanged("FlagApp");
            }
        }
        private string _FlagApp;
        [Column("AppUser")]
        [StringLength(20)]
        public string AppUser
        {
            get
            {
                return _AppUser;
            }
            set
            {
                if (Equals(_AppUser, value)) return;
                _AppUser = value;
                RaisePropertyChanged("AppUser");
            }
        }
        private string _AppUser;
        [Column("AppDate")]
        public Nullable<System.DateTime> AppDate
        {
            get
            {
                return _AppDate;
            }
            set
            {
                if (Equals(_AppDate, value)) return;
                _AppDate = value;
                RaisePropertyChanged("AppDate");
            }
        }
        private Nullable<System.DateTime> _AppDate;
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
