using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_LogDtl")]
    public partial class tb_LogDtl: INotifyPropertyChanged
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
[Column("GUID32")]
        public string GUID32 
		{ 
		   get
           {
               return _GUID32;
           }
           set
           {
               if (Equals(_GUID32, value)) return;
               _GUID32 = value;
               RaisePropertyChanged("GUID32");
           }
		} 
		private string _GUID32;
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
[Column("OldValue")]
        public string OldValue 
		{ 
		   get
           {
               return _OldValue;
           }
           set
           {
               if (Equals(_OldValue, value)) return;
               _OldValue = value;
               RaisePropertyChanged("OldValue");
           }
		} 
		private string _OldValue;
[Column("NewValue")]
        public string NewValue 
		{ 
		   get
           {
               return _NewValue;
           }
           set
           {
               if (Equals(_NewValue, value)) return;
               _NewValue = value;
               RaisePropertyChanged("NewValue");
           }
		} 
		private string _NewValue;
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
