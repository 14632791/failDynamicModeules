namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_MyAuthorityItem")]
    public partial class tb_MyAuthorityItem: INotifyPropertyChanged
    {
	  [Key]
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
[Column("AuthorityName")]
 [StringLength(20)]
        public string AuthorityName 
		{ 
		   get
           {
               return _AuthorityName;
           }
           set
           {
               if (Equals(_AuthorityName, value)) return;
               _AuthorityName = value;
               RaisePropertyChanged("AuthorityName");
           }
		} 
		private string _AuthorityName;
[Column("AuthorityValue")]
        public Nullable<int> AuthorityValue 
		{ 
		   get
           {
               return _AuthorityValue;
           }
           set
           {
               if (Equals(_AuthorityValue, value)) return;
               _AuthorityValue = value;
               RaisePropertyChanged("AuthorityValue");
           }
		} 
		private Nullable<int> _AuthorityValue;
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
