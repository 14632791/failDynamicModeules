using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_MyUserGroup")]
    public partial class tb_MyUserGroup: INotifyPropertyChanged
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
[Column("GroupCode")]
        public string GroupCode 
		{ 
		   get
           {
               return _GroupCode;
           }
           set
           {
               if (Equals(_GroupCode, value)) return;
               _GroupCode = value;
               RaisePropertyChanged("GroupCode");
           }
		} 
		private string _GroupCode;
[Column("GroupName")]
        public string GroupName 
		{ 
		   get
           {
               return _GroupName;
           }
           set
           {
               if (Equals(_GroupName, value)) return;
               _GroupName = value;
               RaisePropertyChanged("GroupName");
           }
		} 
		private string _GroupName;
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
