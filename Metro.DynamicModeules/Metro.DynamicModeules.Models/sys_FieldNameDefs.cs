namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys_FieldNameDefs")]
    public partial class sys_FieldNameDefs: INotifyPropertyChanged
    {
	
 [Key]
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
 [StringLength(50)]
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
[StringLength(50)]
        public string FieldName 
		{ 
		   get
           {
               return _FieldName;
           }
           set
           {
               if (Equals(_FieldName, value)) return;
               _FieldName = value;
               RaisePropertyChanged("FieldName");
           }
		} 
		private string _FieldName;
 [StringLength(50)]
        public string DisplayName 
		{ 
		   get
           {
               return _DisplayName;
           }
           set
           {
               if (Equals(_DisplayName, value)) return;
               _DisplayName = value;
               RaisePropertyChanged("DisplayName");
           }
		} 
		private string _DisplayName;
 [StringLength(100)]
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
[StringLength(1)]
        public string FlagDisplay 
		{ 
		   get
           {
               return _FlagDisplay;
           }
           set
           {
               if (Equals(_FlagDisplay, value)) return;
               _FlagDisplay = value;
               RaisePropertyChanged("FlagDisplay");
           }
		} 
		private string _FlagDisplay;
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
