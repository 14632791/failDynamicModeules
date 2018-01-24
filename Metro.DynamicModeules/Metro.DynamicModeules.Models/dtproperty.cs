using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("dtproperties")]
    public partial class dtproperty: INotifyPropertyChanged
    {
	
[Column("id")]
        public int id 
		{ 
		   get
           {
               return _id;
           }
           set
           {
               if (Equals(_id, value)) return;
               _id = value;
               RaisePropertyChanged("id");
           }
		} 
		private int _id;
[Column("objectid")]
        public Nullable<int> objectid 
		{ 
		   get
           {
               return _objectid;
           }
           set
           {
               if (Equals(_objectid, value)) return;
               _objectid = value;
               RaisePropertyChanged("objectid");
           }
		} 
		private Nullable<int> _objectid;
[Column("property")]
        public string property 
		{ 
		   get
           {
               return _property;
           }
           set
           {
               if (Equals(_property, value)) return;
               _property = value;
               RaisePropertyChanged("property");
           }
		} 
		private string _property;
[Column("value")]
        public string value 
		{ 
		   get
           {
               return _value;
           }
           set
           {
               if (Equals(_value, value)) return;
               _value = value;
               RaisePropertyChanged("value");
           }
		} 
		private string _value;
[Column("uvalue")]
        public string uvalue 
		{ 
		   get
           {
               return _uvalue;
           }
           set
           {
               if (Equals(_uvalue, value)) return;
               _uvalue = value;
               RaisePropertyChanged("uvalue");
           }
		} 
		private string _uvalue;
[Column("lvalue")]
        public byte[] lvalue 
		{ 
		   get
           {
               return _lvalue;
           }
           set
           {
               if (Equals(_lvalue, value)) return;
               _lvalue = value;
               RaisePropertyChanged("lvalue");
           }
		} 
		private byte[] _lvalue;
[Column("version")]
        public int version 
		{ 
		   get
           {
               return _version;
           }
           set
           {
               if (Equals(_version, value)) return;
               _version = value;
               RaisePropertyChanged("version");
           }
		} 
		private int _version;
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
