using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_Log")]
    public partial class tb_Log: INotifyPropertyChanged
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
[Column("LogUser")]
        public string LogUser 
		{ 
		   get
           {
               return _LogUser;
           }
           set
           {
               if (Equals(_LogUser, value)) return;
               _LogUser = value;
               RaisePropertyChanged("LogUser");
           }
		} 
		private string _LogUser;
[Column("LogDate")]
        public System.DateTime LogDate 
		{ 
		   get
           {
               return _LogDate;
           }
           set
           {
               if (Equals(_LogDate, value)) return;
               _LogDate = value;
               RaisePropertyChanged("LogDate");
           }
		} 
		private System.DateTime _LogDate;
[Column("OPType")]
        public int OPType 
		{ 
		   get
           {
               return _OPType;
           }
           set
           {
               if (Equals(_OPType, value)) return;
               _OPType = value;
               RaisePropertyChanged("OPType");
           }
		} 
		private int _OPType;
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
[Column("KeyFieldName")]
        public string KeyFieldName 
		{ 
		   get
           {
               return _KeyFieldName;
           }
           set
           {
               if (Equals(_KeyFieldName, value)) return;
               _KeyFieldName = value;
               RaisePropertyChanged("KeyFieldName");
           }
		} 
		private string _KeyFieldName;
[Column("DocNo")]
        public string DocNo 
		{ 
		   get
           {
               return _DocNo;
           }
           set
           {
               if (Equals(_DocNo, value)) return;
               _DocNo = value;
               RaisePropertyChanged("DocNo");
           }
		} 
		private string _DocNo;
[Column("IsMaster")]
        public string IsMaster 
		{ 
		   get
           {
               return _IsMaster;
           }
           set
           {
               if (Equals(_IsMaster, value)) return;
               _IsMaster = value;
               RaisePropertyChanged("IsMaster");
           }
		} 
		private string _IsMaster;
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
