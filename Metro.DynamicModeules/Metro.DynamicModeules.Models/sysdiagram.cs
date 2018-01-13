using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("sysdiagrams")]
    public partial class sysdiagram: INotifyPropertyChanged
    {
	
[Column("name")]
        public string name 
		{ 
		   get
           {
               return _name;
           }
           set
           {
               if (Equals(_name, value)) return;
               _name = value;
               RaisePropertyChanged("name");
           }
		} 
		private string _name;
[Column("principal_id")]
        public int principal_id 
		{ 
		   get
           {
               return _principal_id;
           }
           set
           {
               if (Equals(_principal_id, value)) return;
               _principal_id = value;
               RaisePropertyChanged("principal_id");
           }
		} 
		private int _principal_id;
[Column("diagram_id")]
        public int diagram_id 
		{ 
		   get
           {
               return _diagram_id;
           }
           set
           {
               if (Equals(_diagram_id, value)) return;
               _diagram_id = value;
               RaisePropertyChanged("diagram_id");
           }
		} 
		private int _diagram_id;
[Column("version")]
        public Nullable<int> version 
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
		private Nullable<int> _version;
[Column("definition")]
        public byte[] definition 
		{ 
		   get
           {
               return _definition;
           }
           set
           {
               if (Equals(_definition, value)) return;
               _definition = value;
               RaisePropertyChanged("definition");
           }
		} 
		private byte[] _definition;
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
