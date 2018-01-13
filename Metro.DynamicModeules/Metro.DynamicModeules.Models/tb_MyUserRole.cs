using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_MyUserRole")]
    public partial class tb_MyUserRole: INotifyPropertyChanged
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
[Column("ModuleID")]
        public Nullable<int> ModuleID 
		{ 
		   get
           {
               return _ModuleID;
           }
           set
           {
               if (Equals(_ModuleID, value)) return;
               _ModuleID = value;
               RaisePropertyChanged("ModuleID");
           }
		} 
		private Nullable<int> _ModuleID;
[Column("AuthorityID")]
        public string AuthorityID 
		{ 
		   get
           {
               return _AuthorityID;
           }
           set
           {
               if (Equals(_AuthorityID, value)) return;
               _AuthorityID = value;
               RaisePropertyChanged("AuthorityID");
           }
		} 
		private string _AuthorityID;
[Column("Authorities")]
        public Nullable<int> Authorities 
		{ 
		   get
           {
               return _Authorities;
           }
           set
           {
               if (Equals(_Authorities, value)) return;
               _Authorities = value;
               RaisePropertyChanged("Authorities");
           }
		} 
		private Nullable<int> _Authorities;
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
