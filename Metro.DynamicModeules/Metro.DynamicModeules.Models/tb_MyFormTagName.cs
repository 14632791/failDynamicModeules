using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_MyFormTagName")]
    public partial class tb_MyFormTagName: INotifyPropertyChanged
    {
	
[Column("AUID")]
        public int AUID 
		{ 
		   get
           {
               return _AUID;
           }
           set
           {
               if (Equals(_AUID, value)) return;
               _AUID = value;
               RaisePropertyChanged("AUID");
           }
		} 
		private int _AUID;
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
[Column("TagValue")]
        public int TagValue 
		{ 
		   get
           {
               return _TagValue;
           }
           set
           {
               if (Equals(_TagValue, value)) return;
               _TagValue = value;
               RaisePropertyChanged("TagValue");
           }
		} 
		private int _TagValue;
[Column("TagName")]
        public string TagName 
		{ 
		   get
           {
               return _TagName;
           }
           set
           {
               if (Equals(_TagName, value)) return;
               _TagName = value;
               RaisePropertyChanged("TagName");
           }
		} 
		private string _TagName;
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
