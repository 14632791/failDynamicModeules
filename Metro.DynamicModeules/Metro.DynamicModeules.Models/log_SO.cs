using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro.DynamicModeules.Models.Models
{
    [Table("log_SO")]
    public  class log_SO: INotifyPropertyChanged
    {
        public string C_TmpKey 
		{ 
		   get
           {
               return _C_TmpKey;
           }
           set
           {
               if (Equals(_C_TmpKey, value)) return;
               _C_TmpKey = value;
               RaisePropertyChanged("C_TmpKey");
           }
		} 
		private string _C_TmpKey;
        public string C_CreateBy 
		{ 
		   get
           {
               return _C_CreateBy;
           }
           set
           {
               if (Equals(_C_CreateBy, value)) return;
               _C_CreateBy = value;
               RaisePropertyChanged("C_CreateBy");
           }
		} 
		private string _C_CreateBy;
        public Nullable<System.DateTime> C_CreateDate 
		{ 
		   get
           {
               return _C_CreateDate;
           }
           set
           {
               if (Equals(_C_CreateDate, value)) return;
               _C_CreateDate = value;
               RaisePropertyChanged("C_CreateDate");
           }
		} 
		private Nullable<System.DateTime> _C_CreateDate;
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
        public string SONO 
		{ 
		   get
           {
               return _SONO;
           }
           set
           {
               if (Equals(_SONO, value)) return;
               _SONO = value;
               RaisePropertyChanged("SONO");
           }
		} 
		private string _SONO;
        public string VerNo 
		{ 
		   get
           {
               return _VerNo;
           }
           set
           {
               if (Equals(_VerNo, value)) return;
               _VerNo = value;
               RaisePropertyChanged("VerNo");
           }
		} 
		private string _VerNo;
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
        public Nullable<System.DateTime> ReceiveDay 
		{ 
		   get
           {
               return _ReceiveDay;
           }
           set
           {
               if (Equals(_ReceiveDay, value)) return;
               _ReceiveDay = value;
               RaisePropertyChanged("ReceiveDay");
           }
		} 
		private Nullable<System.DateTime> _ReceiveDay;
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
        public string Salesman 
		{ 
		   get
           {
               return _Salesman;
           }
           set
           {
               if (Equals(_Salesman, value)) return;
               _Salesman = value;
               RaisePropertyChanged("Salesman");
           }
		} 
		private string _Salesman;
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
        public string FinishingStatus 
		{ 
		   get
           {
               return _FinishingStatus;
           }
           set
           {
               if (Equals(_FinishingStatus, value)) return;
               _FinishingStatus = value;
               RaisePropertyChanged("FinishingStatus");
           }
		} 
		private string _FinishingStatus;
        public Nullable<System.DateTime> OrderFinishDay 
		{ 
		   get
           {
               return _OrderFinishDay;
           }
           set
           {
               if (Equals(_OrderFinishDay, value)) return;
               _OrderFinishDay = value;
               RaisePropertyChanged("OrderFinishDay");
           }
		} 
		private Nullable<System.DateTime> _OrderFinishDay;
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
