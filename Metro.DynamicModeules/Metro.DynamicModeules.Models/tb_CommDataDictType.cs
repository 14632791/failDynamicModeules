using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_CommDataDictType")]
    public partial class tb_CommDataDictType: INotifyPropertyChanged
    {
	
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
[Column("DataType")]
        public int DataType 
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
		private int _DataType;
[Column("TypeName")]
        public string TypeName 
		{ 
		   get
           {
               return _TypeName;
           }
           set
           {
               if (Equals(_TypeName, value)) return;
               _TypeName = value;
               RaisePropertyChanged("TypeName");
           }
		} 
		private string _TypeName;
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
