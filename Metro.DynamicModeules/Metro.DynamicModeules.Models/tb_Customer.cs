namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Customer")]
    public partial class tb_Customer: INotifyPropertyChanged
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
[Column("CustomerCode")]
 [Key]
        [StringLength(20)]
        public string CustomerCode 
		{ 
		   get
           {
               return _CustomerCode;
           }
           set
           {
               if (Equals(_CustomerCode, value)) return;
               _CustomerCode = value;
               RaisePropertyChanged("CustomerCode");
           }
		} 
		private string _CustomerCode;
[Column("NativeName")]
 [StringLength(100)]
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
 [StringLength(100)]
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
[Column("AttributeCodes")]
[StringLength(50)]
        public string AttributeCodes 
		{ 
		   get
           {
               return _AttributeCodes;
           }
           set
           {
               if (Equals(_AttributeCodes, value)) return;
               _AttributeCodes = value;
               RaisePropertyChanged("AttributeCodes");
           }
		} 
		private string _AttributeCodes;
[Column("Address1")]
 [StringLength(50)]
        public string Address1 
		{ 
		   get
           {
               return _Address1;
           }
           set
           {
               if (Equals(_Address1, value)) return;
               _Address1 = value;
               RaisePropertyChanged("Address1");
           }
		} 
		private string _Address1;
[Column("Address2")]
 [StringLength(50)]
        public string Address2 
		{ 
		   get
           {
               return _Address2;
           }
           set
           {
               if (Equals(_Address2, value)) return;
               _Address2 = value;
               RaisePropertyChanged("Address2");
           }
		} 
		private string _Address2;
[Column("Address3")]
        public string Address3 
		{ 
		   get
           {
               return _Address3;
           }
           set
           {
               if (Equals(_Address3, value)) return;
               _Address3 = value;
               RaisePropertyChanged("Address3");
           }
		} 
		private string _Address3;
[Column("Country")]
[StringLength(20)]
        public string Country 
		{ 
		   get
           {
               return _Country;
           }
           set
           {
               if (Equals(_Country, value)) return;
               _Country = value;
               RaisePropertyChanged("Country");
           }
		} 
		private string _Country;
[Column("Region")]
 [StringLength(20)]
        public string Region 
		{ 
		   get
           {
               return _Region;
           }
           set
           {
               if (Equals(_Region, value)) return;
               _Region = value;
               RaisePropertyChanged("Region");
           }
		} 
		private string _Region;
[Column("City")]
 [StringLength(20)]
        public string City 
		{ 
		   get
           {
               return _City;
           }
           set
           {
               if (Equals(_City, value)) return;
               _City = value;
               RaisePropertyChanged("City");
           }
		} 
		private string _City;
[Column("CountryCode")]
 [StringLength(6)]
        public string CountryCode 
		{ 
		   get
           {
               return _CountryCode;
           }
           set
           {
               if (Equals(_CountryCode, value)) return;
               _CountryCode = value;
               RaisePropertyChanged("CountryCode");
           }
		} 
		private string _CountryCode;
[Column("CityCode")]
  [StringLength(6)]
        public string CityCode 
		{ 
		   get
           {
               return _CityCode;
           }
           set
           {
               if (Equals(_CityCode, value)) return;
               _CityCode = value;
               RaisePropertyChanged("CityCode");
           }
		} 
		private string _CityCode;
[Column("Tel")]
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
[StringLength(20)]
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
[Column("PostalCode")]
        public string PostalCode 
		{ 
		   get
           {
               return _PostalCode;
           }
           set
           {
               if (Equals(_PostalCode, value)) return;
               _PostalCode = value;
               RaisePropertyChanged("PostalCode");
           }
		} 
		private string _PostalCode;
[Column("ZipCode")]
 [StringLength(20)]
        public string ZipCode 
		{ 
		   get
           {
               return _ZipCode;
           }
           set
           {
               if (Equals(_ZipCode, value)) return;
               _ZipCode = value;
               RaisePropertyChanged("ZipCode");
           }
		} 
		private string _ZipCode;
[Column("WebAddress")]
        public string WebAddress 
		{ 
		   get
           {
               return _WebAddress;
           }
           set
           {
               if (Equals(_WebAddress, value)) return;
               _WebAddress = value;
               RaisePropertyChanged("WebAddress");
           }
		} 
		private string _WebAddress;
[Column("Email")]
 [StringLength(200)]
        public string Email 
		{ 
		   get
           {
               return _Email;
           }
           set
           {
               if (Equals(_Email, value)) return;
               _Email = value;
               RaisePropertyChanged("Email");
           }
		} 
		private string _Email;
[Column("Bank")]
[StringLength(20)]
        public string Bank 
		{ 
		   get
           {
               return _Bank;
           }
           set
           {
               if (Equals(_Bank, value)) return;
               _Bank = value;
               RaisePropertyChanged("Bank");
           }
		} 
		private string _Bank;
[Column("BankAccount")]
        public string BankAccount 
		{ 
		   get
           {
               return _BankAccount;
           }
           set
           {
               if (Equals(_BankAccount, value)) return;
               _BankAccount = value;
               RaisePropertyChanged("BankAccount");
           }
		} 
		private string _BankAccount;
[Column("BankAddress")]
 [StringLength(50)]
        public string BankAddress 
		{ 
		   get
           {
               return _BankAddress;
           }
           set
           {
               if (Equals(_BankAddress, value)) return;
               _BankAddress = value;
               RaisePropertyChanged("BankAddress");
           }
		} 
		private string _BankAddress;
[Column("ContactPerson")]
 [StringLength(20)]
        public string ContactPerson 
		{ 
		   get
           {
               return _ContactPerson;
           }
           set
           {
               if (Equals(_ContactPerson, value)) return;
               _ContactPerson = value;
               RaisePropertyChanged("ContactPerson");
           }
		} 
		private string _ContactPerson;
[Column("Remark")]
 [StringLength(200)]
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
[Column("InUse")]
        public string InUse 
		{ 
		   get
           {
               return _InUse;
           }
           set
           {
               if (Equals(_InUse, value)) return;
               _InUse = value;
               RaisePropertyChanged("InUse");
           }
		} 
		private string _InUse;
[Column("PaymentTerm")]
        public Nullable<int> PaymentTerm 
		{ 
		   get
           {
               return _PaymentTerm;
           }
           set
           {
               if (Equals(_PaymentTerm, value)) return;
               _PaymentTerm = value;
               RaisePropertyChanged("PaymentTerm");
           }
		} 
		private Nullable<int> _PaymentTerm;
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
 [StringLength(50)]
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
