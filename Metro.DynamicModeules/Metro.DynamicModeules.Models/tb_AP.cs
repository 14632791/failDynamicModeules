namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_AP")]
    public partial class tb_AP: INotifyPropertyChanged
    {
	
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
[Key]
        [StringLength(20)]
        public string APNO 
		{ 
		   get
           {
               return _APNO;
           }
           set
           {
               if (Equals(_APNO, value)) return;
               _APNO = value;
               RaisePropertyChanged("APNO");
           }
		} 
		private string _APNO;
[Column("ReceivedDate")]
        public Nullable<System.DateTime> ReceivedDate 
		{ 
		   get
           {
               return _ReceivedDate;
           }
           set
           {
               if (Equals(_ReceivedDate, value)) return;
               _ReceivedDate = value;
               RaisePropertyChanged("ReceivedDate");
           }
		} 
		private Nullable<System.DateTime> _ReceivedDate;
 [StringLength(20)]
        public string SupplierCode 
		{ 
		   get
           {
               return _SupplierCode;
           }
           set
           {
               if (Equals(_SupplierCode, value)) return;
               _SupplierCode = value;
               RaisePropertyChanged("SupplierCode");
           }
		} 
		private string _SupplierCode;
[StringLength(20)]
        public string ChequeNo 
		{ 
		   get
           {
               return _ChequeNo;
           }
           set
           {
               if (Equals(_ChequeNo, value)) return;
               _ChequeNo = value;
               RaisePropertyChanged("ChequeNo");
           }
		} 
		private string _ChequeNo;
[StringLength(20)]
        public string ChequeBank 
		{ 
		   get
           {
               return _ChequeBank;
           }
           set
           {
               if (Equals(_ChequeBank, value)) return;
               _ChequeBank = value;
               RaisePropertyChanged("ChequeBank");
           }
		} 
		private string _ChequeBank;
 [StringLength(20)]
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
[Column("Amount")]
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
 [StringLength(100)]
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
 [StringLength(20)]
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
