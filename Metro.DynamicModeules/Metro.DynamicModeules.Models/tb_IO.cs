using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_IO")]
    public partial class tb_IO: INotifyPropertyChanged
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
[Column("IONO")]
        public string IONO 
		{ 
		   get
           {
               return _IONO;
           }
           set
           {
               if (Equals(_IONO, value)) return;
               _IONO = value;
               RaisePropertyChanged("IONO");
           }
		} 
		private string _IONO;
[Column("DocDate")]
        public Nullable<System.DateTime> DocDate 
		{ 
		   get
           {
               return _DocDate;
           }
           set
           {
               if (Equals(_DocDate, value)) return;
               _DocDate = value;
               RaisePropertyChanged("DocDate");
           }
		} 
		private Nullable<System.DateTime> _DocDate;
[Column("DocUser")]
        public string DocUser 
		{ 
		   get
           {
               return _DocUser;
           }
           set
           {
               if (Equals(_DocUser, value)) return;
               _DocUser = value;
               RaisePropertyChanged("DocUser");
           }
		} 
		private string _DocUser;
[Column("RefNo")]
        public string RefNo 
		{ 
		   get
           {
               return _RefNo;
           }
           set
           {
               if (Equals(_RefNo, value)) return;
               _RefNo = value;
               RaisePropertyChanged("RefNo");
           }
		} 
		private string _RefNo;
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
[Column("Department")]
        public string Department 
		{ 
		   get
           {
               return _Department;
           }
           set
           {
               if (Equals(_Department, value)) return;
               _Department = value;
               RaisePropertyChanged("Department");
           }
		} 
		private string _Department;
[Column("Deliver")]
        public string Deliver 
		{ 
		   get
           {
               return _Deliver;
           }
           set
           {
               if (Equals(_Deliver, value)) return;
               _Deliver = value;
               RaisePropertyChanged("Deliver");
           }
		} 
		private string _Deliver;
[Column("LocationID")]
        public string LocationID 
		{ 
		   get
           {
               return _LocationID;
           }
           set
           {
               if (Equals(_LocationID, value)) return;
               _LocationID = value;
               RaisePropertyChanged("LocationID");
           }
		} 
		private string _LocationID;
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
