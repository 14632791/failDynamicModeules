namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Product")]
    public partial class tb_Product: INotifyPropertyChanged
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
[Column("ProductCode")]
 [Key]
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
[Column("ProductName")]
[StringLength(50)]
        public string ProductName 
		{ 
		   get
           {
               return _ProductName;
           }
           set
           {
               if (Equals(_ProductName, value)) return;
               _ProductName = value;
               RaisePropertyChanged("ProductName");
           }
		} 
		private string _ProductName;
[Column("CategoryId")]
 [StringLength(20)]
        public string CategoryId 
		{ 
		   get
           {
               return _CategoryId;
           }
           set
           {
               if (Equals(_CategoryId, value)) return;
               _CategoryId = value;
               RaisePropertyChanged("CategoryId");
           }
		} 
		private string _CategoryId;
[Column("SellPrice")]
        public Nullable<decimal> SellPrice 
		{ 
		   get
           {
               return _SellPrice;
           }
           set
           {
               if (Equals(_SellPrice, value)) return;
               _SellPrice = value;
               RaisePropertyChanged("SellPrice");
           }
		} 
		private Nullable<decimal> _SellPrice;
[Column("Supplier")]
[StringLength(50)]
        public string Supplier 
		{ 
		   get
           {
               return _Supplier;
           }
           set
           {
               if (Equals(_Supplier, value)) return;
               _Supplier = value;
               RaisePropertyChanged("Supplier");
           }
		} 
		private string _Supplier;
[Column("Remark")]
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
