using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_LogFields")]
    public partial class tb_LogFields: INotifyPropertyChanged
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
[Column("TableName")]
        public string TableName 
		{ 
		   get
           {
               return _TableName;
           }
           set
           {
               if (Equals(_TableName, value)) return;
               _TableName = value;
               RaisePropertyChanged("TableName");
           }
		} 
		private string _TableName;
[Column("FieldName")]
        public string FieldName 
		{ 
		   get
           {
               return _FieldName;
           }
           set
           {
               if (Equals(_FieldName, value)) return;
               _FieldName = value;
               RaisePropertyChanged("FieldName");
           }
		} 
		private string _FieldName;
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
