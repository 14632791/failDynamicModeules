namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_ARs")]
    public partial class tb_ARs: INotifyPropertyChanged
    {
	
[Key]
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
[StringLength(20)]
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
[Column("Queue")]
        public Nullable<decimal> Queue 
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
		private Nullable<decimal> _Queue;
 [StringLength(20)]
        public string InvoiceNo 
		{ 
		   get
           {
               return _InvoiceNo;
           }
           set
           {
               if (Equals(_InvoiceNo, value)) return;
               _InvoiceNo = value;
               RaisePropertyChanged("InvoiceNo");
           }
		} 
		private string _InvoiceNo;
 [StringLength(20)]
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
