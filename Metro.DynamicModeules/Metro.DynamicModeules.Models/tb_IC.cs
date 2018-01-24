namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_IC")]
    public partial class tb_IC: INotifyPropertyChanged
    {
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
[Column("ISID")]
        [Key]
        public int ISID 
		{ 
		   get
           {
               return _ISID;
           }
           set
           {
               if (Equals(_ISID, value)) return;
               _ISID = value;
               RaisePropertyChanged("ISID");
           }
		} 
		private int _ISID;
[Column("ICNO")]
        public string ICNO 
		{ 
		   get
           {
               return _ICNO;
           }
           set
           {
               if (Equals(_ICNO, value)) return;
               _ICNO = value;
               RaisePropertyChanged("ICNO");
           }
		} 
		private string _ICNO;
[Column("DocDate")]
        public Nullable<System.DateTime> DocDate 
		{ 
		   get
           {
               return _DocDate;
           }
           set
           {
               if (Equals(_DocDate, value)) return;
               _DocDate = value;
               RaisePropertyChanged("DocDate");
           }
		} 
		private Nullable<System.DateTime> _DocDate;
[Column("DocUser")]
 [StringLength(20)]
        public string DocUser 
		{ 
		   get
           {
               return _DocUser;
           }
           set
           {
               if (Equals(_DocUser, value)) return;
               _DocUser = value;
               RaisePropertyChanged("DocUser");
           }
		} 
		private string _DocUser;
[Column("FlagApp")]
 [StringLength(1)]
        public string FlagApp 
		{ 
		   get
           {
               return _FlagApp;
           }
           set
           {
               if (Equals(_FlagApp, value)) return;
               _FlagApp = value;
               RaisePropertyChanged("FlagApp");
           }
		} 
		private string _FlagApp;
[Column("Remark")]
 [StringLength(250)]
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
[Column("CreatedBy")]
[StringLength(20)]
        public string CreatedBy 
		{ 
		   get
           {
               return _CreatedBy;
           }
           set
           {
               if (Equals(_CreatedBy, value)) return;
               _CreatedBy = value;
               RaisePropertyChanged("CreatedBy");
           }
		} 
		private string _CreatedBy;
[Column("CreationDate")]
        public Nullable<System.DateTime> CreationDate 
		{ 
		   get
           {
               return _CreationDate;
           }
           set
           {
               if (Equals(_CreationDate, value)) return;
               _CreationDate = value;
               RaisePropertyChanged("CreationDate");
           }
		} 
		private Nullable<System.DateTime> _CreationDate;
[Column("AppUser")]
[StringLength(20)]
        public string AppUser 
		{ 
		   get
           {
               return _AppUser;
           }
           set
           {
               if (Equals(_AppUser, value)) return;
               _AppUser = value;
               RaisePropertyChanged("AppUser");
           }
		} 
		private string _AppUser;
[Column("AppDate")]
        public Nullable<System.DateTime> AppDate 
		{ 
		   get
           {
               return _AppDate;
           }
           set
           {
               if (Equals(_AppDate, value)) return;
               _AppDate = value;
               RaisePropertyChanged("AppDate");
           }
		} 
		private Nullable<System.DateTime> _AppDate;
[Column("LastUpdatedBy")]
[StringLength(20)]
        public string LastUpdatedBy 
		{ 
		   get
           {
               return _LastUpdatedBy;
           }
           set
           {
               if (Equals(_LastUpdatedBy, value)) return;
               _LastUpdatedBy = value;
               RaisePropertyChanged("LastUpdatedBy");
           }
		} 
		private string _LastUpdatedBy;
[Column("LastUpdateDate")]
        public Nullable<System.DateTime> LastUpdateDate 
		{ 
		   get
           {
               return _LastUpdateDate;
           }
           set
           {
               if (Equals(_LastUpdateDate, value)) return;
               _LastUpdateDate = value;
               RaisePropertyChanged("LastUpdateDate");
           }
		} 
		private Nullable<System.DateTime> _LastUpdateDate;
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
