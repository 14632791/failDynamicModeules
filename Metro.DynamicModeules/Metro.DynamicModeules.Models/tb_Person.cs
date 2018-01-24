namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Person")]
    public partial class tb_Person: INotifyPropertyChanged
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
[Column("SalesCode")]
  [Key]
        [StringLength(20)]
        public string SalesCode 
		{ 
		   get
           {
               return _SalesCode;
           }
           set
           {
               if (Equals(_SalesCode, value)) return;
               _SalesCode = value;
               RaisePropertyChanged("SalesCode");
           }
		} 
		private string _SalesCode;
[Column("SalesName")]
[Required]
        [StringLength(20)]
        public string SalesName 
		{ 
		   get
           {
               return _SalesName;
           }
           set
           {
               if (Equals(_SalesName, value)) return;
               _SalesName = value;
               RaisePropertyChanged("SalesName");
           }
		} 
		private string _SalesName;
[Column("Department")]
[StringLength(20)]
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
[Column("InUse")]
 [StringLength(1)]
        public string InUse 
		{ 
		   get
           {
               return _InUse;
           }
           set
           {
               if (Equals(_InUse, value)) return;
               _InUse = value;
               RaisePropertyChanged("InUse");
           }
		} 
		private string _InUse;
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
