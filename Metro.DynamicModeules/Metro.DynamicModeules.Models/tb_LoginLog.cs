namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_LoginLog")]
    public partial class tb_LoginLog: INotifyPropertyChanged
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
[Column("Account")]
  [StringLength(20)]
        public string Account 
		{ 
		   get
           {
               return _Account;
           }
           set
           {
               if (Equals(_Account, value)) return;
               _Account = value;
               RaisePropertyChanged("Account");
           }
		} 
		private string _Account;
[Column("LoginType")]
   [StringLength(1)]
        public string LoginType 
		{ 
		   get
           {
               return _LoginType;
           }
           set
           {
               if (Equals(_LoginType, value)) return;
               _LoginType = value;
               RaisePropertyChanged("LoginType");
           }
		} 
		private string _LoginType;
[Column("CurrentTime")]
        public Nullable<System.DateTime> CurrentTime 
		{ 
		   get
           {
               return _CurrentTime;
           }
           set
           {
               if (Equals(_CurrentTime, value)) return;
               _CurrentTime = value;
               RaisePropertyChanged("CurrentTime");
           }
		} 
		private Nullable<System.DateTime> _CurrentTime;
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
