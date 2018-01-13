using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("sys_DocSN")]
    public partial class sys_DocSN: INotifyPropertyChanged
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
[Column("DocName")]
        public string DocName 
		{ 
		   get
           {
               return _DocName;
           }
           set
           {
               if (Equals(_DocName, value)) return;
               _DocName = value;
               RaisePropertyChanged("DocName");
           }
		} 
		private string _DocName;
[Column("Header")]
        public string Header 
		{ 
		   get
           {
               return _Header;
           }
           set
           {
               if (Equals(_Header, value)) return;
               _Header = value;
               RaisePropertyChanged("Header");
           }
		} 
		private string _Header;
[Column("YYMM")]
        public string YYMM 
		{ 
		   get
           {
               return _YYMM;
           }
           set
           {
               if (Equals(_YYMM, value)) return;
               _YYMM = value;
               RaisePropertyChanged("YYMM");
           }
		} 
		private string _YYMM;
[Column("MaxID")]
        public Nullable<int> MaxID 
		{ 
		   get
           {
               return _MaxID;
           }
           set
           {
               if (Equals(_MaxID, value)) return;
               _MaxID = value;
               RaisePropertyChanged("MaxID");
           }
		} 
		private Nullable<int> _MaxID;
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
