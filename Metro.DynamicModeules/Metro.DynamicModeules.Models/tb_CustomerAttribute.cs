using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_CustomerAttribute")]
    public partial class tb_CustomerAttribute: INotifyPropertyChanged
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
[Column("AttributeCode")]
        public string AttributeCode 
		{ 
		   get
           {
               return _AttributeCode;
           }
           set
           {
               if (Equals(_AttributeCode, value)) return;
               _AttributeCode = value;
               RaisePropertyChanged("AttributeCode");
           }
		} 
		private string _AttributeCode;
[Column("NativeName")]
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
[Column("IsSelected")]
        public string IsSelected 
		{ 
		   get
           {
               return _IsSelected;
           }
           set
           {
               if (Equals(_IsSelected, value)) return;
               _IsSelected = value;
               RaisePropertyChanged("IsSelected");
           }
		} 
		private string _IsSelected;
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
