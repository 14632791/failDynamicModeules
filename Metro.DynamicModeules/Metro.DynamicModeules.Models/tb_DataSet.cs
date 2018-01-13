using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_DataSet")]
    public partial class tb_DataSet: INotifyPropertyChanged
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
[Column("DataSetID")]
        public string DataSetID 
		{ 
		   get
           {
               return _DataSetID;
           }
           set
           {
               if (Equals(_DataSetID, value)) return;
               _DataSetID = value;
               RaisePropertyChanged("DataSetID");
           }
		} 
		private string _DataSetID;
[Column("DataSetName")]
        public string DataSetName 
		{ 
		   get
           {
               return _DataSetName;
           }
           set
           {
               if (Equals(_DataSetName, value)) return;
               _DataSetName = value;
               RaisePropertyChanged("DataSetName");
           }
		} 
		private string _DataSetName;
[Column("ServerIP")]
        public string ServerIP 
		{ 
		   get
           {
               return _ServerIP;
           }
           set
           {
               if (Equals(_ServerIP, value)) return;
               _ServerIP = value;
               RaisePropertyChanged("ServerIP");
           }
		} 
		private string _ServerIP;
[Column("DBName")]
        public string DBName 
		{ 
		   get
           {
               return _DBName;
           }
           set
           {
               if (Equals(_DBName, value)) return;
               _DBName = value;
               RaisePropertyChanged("DBName");
           }
		} 
		private string _DBName;
[Column("DBUserName")]
        public string DBUserName 
		{ 
		   get
           {
               return _DBUserName;
           }
           set
           {
               if (Equals(_DBUserName, value)) return;
               _DBUserName = value;
               RaisePropertyChanged("DBUserName");
           }
		} 
		private string _DBUserName;
[Column("DBUserPassword")]
        public string DBUserPassword 
		{ 
		   get
           {
               return _DBUserPassword;
           }
           set
           {
               if (Equals(_DBUserPassword, value)) return;
               _DBUserPassword = value;
               RaisePropertyChanged("DBUserPassword");
           }
		} 
		private string _DBUserPassword;
[Column("Remark")]
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
