namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_CommonDataDict")]
    public partial class tb_CommonDataDict: INotifyPropertyChanged
    {
	
[Column("ISID")]
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
[Column("DataType")]
        public Nullable<int> DataType 
		{ 
		   get
           {
               return _DataType;
           }
           set
           {
               if (Equals(_DataType, value)) return;
               _DataType = value;
               RaisePropertyChanged("DataType");
           }
		} 
		private Nullable<int> _DataType;
[Column("DataCode")]
 [StringLength(20)]
        public string DataCode 
		{ 
		   get
           {
               return _DataCode;
           }
           set
           {
               if (Equals(_DataCode, value)) return;
               _DataCode = value;
               RaisePropertyChanged("DataCode");
           }
		} 
		private string _DataCode;
[Column("NativeName")]
  [StringLength(100)]
        public string NativeName 
		{ 
		   get
           {
               return _NativeName;
           }
           set
           {
               if (Equals(_NativeName, value)) return;
               _NativeName = value;
               RaisePropertyChanged("NativeName");
           }
		} 
		private string _NativeName;
[Column("EnglishName")]
[StringLength(50)]
        public string EnglishName 
		{ 
		   get
           {
               return _EnglishName;
           }
           set
           {
               if (Equals(_EnglishName, value)) return;
               _EnglishName = value;
               RaisePropertyChanged("EnglishName");
           }
		} 
		private string _EnglishName;
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
