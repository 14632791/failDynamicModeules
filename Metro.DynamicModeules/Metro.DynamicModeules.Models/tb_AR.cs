using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_AR")]
    public partial class tb_AR: INotifyPropertyChanged
    {
	
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
[Column("ARNO")]
        public string ARNO 
		{ 
		   get
           {
               return _ARNO;
           }
           set
           {
               if (Equals(_ARNO, value)) return;
               _ARNO = value;
               RaisePropertyChanged("ARNO");
           }
		} 
		private string _ARNO;
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
[Column("CustomerCode")]
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
[Column("ChequeNo")]
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
[Column("ChequeBank")]
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
[Column("Currency")]
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
[Column("Remark")]
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
