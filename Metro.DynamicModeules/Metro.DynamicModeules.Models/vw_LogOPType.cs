using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("vw_LogOPType")]
    public partial class vw_LogOPType: INotifyPropertyChanged
    {
	
[Column("TypeID")]
        public int TypeID 
		{ 
		   get
           {
               return _TypeID;
           }
           set
           {
               if (Equals(_TypeID, value)) return;
               _TypeID = value;
               RaisePropertyChanged("TypeID");
           }
		} 
		private int _TypeID;
[Column("TypeName")]
        public string TypeName 
		{ 
		   get
           {
               return _TypeName;
           }
           set
           {
               if (Equals(_TypeName, value)) return;
               _TypeName = value;
               RaisePropertyChanged("TypeName");
           }
		} 
		private string _TypeName;
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
