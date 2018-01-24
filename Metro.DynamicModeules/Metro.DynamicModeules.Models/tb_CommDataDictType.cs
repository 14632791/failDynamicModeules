namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_CommDataDictType")]
    public partial class tb_CommDataDictType: INotifyPropertyChanged
    {
	
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
[Column("DataType")]
[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DataType 
		{ 
		   get
           {
               return _DataType;
           }
           set
           {
               if (Equals(_DataType, value)) return;
               _DataType = value;
               RaisePropertyChanged("DataType");
           }
		} 
		private int _DataType;
[Column("TypeName")]
 [StringLength(20)]
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
