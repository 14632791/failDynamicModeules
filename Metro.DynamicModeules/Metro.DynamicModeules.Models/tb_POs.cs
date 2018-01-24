namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_POs")]
    public partial class tb_POs: INotifyPropertyChanged
    {
 [Key]	
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
[Required]
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
[Column("Queue")]
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
[Column("ProductCode")]
[Required]
        [StringLength(20)]
        public string ProductCode 
		{ 
		   get
           {
               return _ProductCode;
           }
           set
           {
               if (Equals(_ProductCode, value)) return;
               _ProductCode = value;
               RaisePropertyChanged("ProductCode");
           }
		} 
		private string _ProductCode;
[Column("Unit")]
[StringLength(10)]
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
[Column("Quantity")]
        public Nullable<int> Quantity 
		{ 
		   get
           {
               return _Quantity;
           }
           set
           {
               if (Equals(_Quantity, value)) return;
               _Quantity = value;
               RaisePropertyChanged("Quantity");
           }
		} 
		private Nullable<int> _Quantity;

[Column("Price",TypeName = "numeric")]
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
[StringLength(50)]
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
 [StringLength(50)]
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
