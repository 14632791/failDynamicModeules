using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("vw_CommonDataDicts")]
    public partial class vw_CommonDataDicts: INotifyPropertyChanged
    {
	
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
[Column("DataName")]
        public string DataName 
		{ 
		   get
           {
               return _DataName;
           }
           set
           {
               if (Equals(_DataName, value)) return;
               _DataName = value;
               RaisePropertyChanged("DataName");
           }
		} 
		private string _DataName;
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
