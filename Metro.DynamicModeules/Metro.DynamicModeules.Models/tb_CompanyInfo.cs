namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_CompanyInfo")]
    public partial class tb_CompanyInfo: INotifyPropertyChanged
    {
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
[Column("ISID")]
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
[Column("CompanyCode")]
 [Key]
        [StringLength(3)]
        public string CompanyCode 
		{ 
		   get
           {
               return _CompanyCode;
           }
           set
           {
               if (Equals(_CompanyCode, value)) return;
               _CompanyCode = value;
               RaisePropertyChanged("CompanyCode");
           }
		} 
		private string _CompanyCode;
[Column("NativeName")]
 [StringLength(40)]
        public string NativeName 
		{ 
		   get
           {
               return _NativeName;
           }
           set
           {
               if (Equals(_NativeName, value)) return;
               _NativeName = value;
               RaisePropertyChanged("NativeName");
           }
		} 
		private string _NativeName;
[Column("EnglishName")]
        public string EnglishName 
		{ 
		   get
           {
               return _EnglishName;
           }
           set
           {
               if (Equals(_EnglishName, value)) return;
               _EnglishName = value;
               RaisePropertyChanged("EnglishName");
           }
		} 
		private string _EnglishName;
[Column("ProgramName")]
 [StringLength(40)]
        public string ProgramName 
		{ 
		   get
           {
               return _ProgramName;
           }
           set
           {
               if (Equals(_ProgramName, value)) return;
               _ProgramName = value;
               RaisePropertyChanged("ProgramName");
           }
		} 
		private string _ProgramName;
[Column("ReportHead")]
 [StringLength(50)]
        public string ReportHead 
		{ 
		   get
           {
               return _ReportHead;
           }
           set
           {
               if (Equals(_ReportHead, value)) return;
               _ReportHead = value;
               RaisePropertyChanged("ReportHead");
           }
		} 
		private string _ReportHead;
[Column("Address")]
        public string Address 
		{ 
		   get
           {
               return _Address;
           }
           set
           {
               if (Equals(_Address, value)) return;
               _Address = value;
               RaisePropertyChanged("Address");
           }
		} 
		private string _Address;
[Column("Tel")]
  [StringLength(50)]
        public string Tel 
		{ 
		   get
           {
               return _Tel;
           }
           set
           {
               if (Equals(_Tel, value)) return;
               _Tel = value;
               RaisePropertyChanged("Tel");
           }
		} 
		private string _Tel;
[Column("Fax")]
        public string Fax 
		{ 
		   get
           {
               return _Fax;
           }
           set
           {
               if (Equals(_Fax, value)) return;
               _Fax = value;
               RaisePropertyChanged("Fax");
           }
		} 
		private string _Fax;
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
[Column("CreatedBy")]
[StringLength(50)]
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
