using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_MyMenu")]
    public partial class tb_MyMenu: INotifyPropertyChanged
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
[Column("MenuName")]
        public string MenuName 
		{ 
		   get
           {
               return _MenuName;
           }
           set
           {
               if (Equals(_MenuName, value)) return;
               _MenuName = value;
               RaisePropertyChanged("MenuName");
           }
		} 
		private string _MenuName;
[Column("MenuCaption")]
        public string MenuCaption 
		{ 
		   get
           {
               return _MenuCaption;
           }
           set
           {
               if (Equals(_MenuCaption, value)) return;
               _MenuCaption = value;
               RaisePropertyChanged("MenuCaption");
           }
		} 
		private string _MenuCaption;
[Column("Auths")]
        public Nullable<int> Auths 
		{ 
		   get
           {
               return _Auths;
           }
           set
           {
               if (Equals(_Auths, value)) return;
               _Auths = value;
               RaisePropertyChanged("Auths");
           }
		} 
		private Nullable<int> _Auths;
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
[Column("MenuType")]
        public string MenuType 
		{ 
		   get
           {
               return _MenuType;
           }
           set
           {
               if (Equals(_MenuType, value)) return;
               _MenuType = value;
               RaisePropertyChanged("MenuType");
           }
		} 
		private string _MenuType;
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
