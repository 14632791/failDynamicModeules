using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Metro.DynamicModeules.CodeFirst.Models
{
    public  class log_SOs: INotifyPropertyChanged
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
        public decimal Queue 
		{ 
		   get
           {
               return _Queue;
           }
           set
           {
               if (Equals(_Queue, value)) return;
               _Queue = value;
               RaisePropertyChanged("Queue");
           }
		} 
		private decimal _Queue;
        public string StockCode 
		{ 
		   get
           {
               return _StockCode;
           }
           set
           {
               if (Equals(_StockCode, value)) return;
               _StockCode = value;
               RaisePropertyChanged("StockCode");
           }
		} 
		private string _StockCode;
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
        public Nullable<System.DateTime> ShipDay 
		{ 
		   get
           {
               return _ShipDay;
           }
           set
           {
               if (Equals(_ShipDay, value)) return;
               _ShipDay = value;
               RaisePropertyChanged("ShipDay");
           }
		} 
		private Nullable<System.DateTime> _ShipDay;
        public string Unit 
		{ 
		   get
           {
               return _Unit;
           }
           set
           {
               if (Equals(_Unit, value)) return;
               _Unit = value;
               RaisePropertyChanged("Unit");
           }
		} 
		private string _Unit;
        public Nullable<int> Qty 
		{ 
		   get
           {
               return _Qty;
           }
           set
           {
               if (Equals(_Qty, value)) return;
               _Qty = value;
               RaisePropertyChanged("Qty");
           }
		} 
		private Nullable<int> _Qty;
        public Nullable<decimal> Price 
		{ 
		   get
           {
               return _Price;
           }
           set
           {
               if (Equals(_Price, value)) return;
               _Price = value;
               RaisePropertyChanged("Price");
           }
		} 
		private Nullable<decimal> _Price;
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
