using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_Person")]
    public partial class tb_Person: INotifyPropertyChanged
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
[Column("SalesCode")]
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
