namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys_DataSN")]
    public partial class sys_DataSN : INotifyPropertyChanged
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

        [StringLength(10)]
        public string DataCode
        {
            get
            {
                return _DataCode;
            }
            set
            {
                if (Equals(_DataCode, value)) return;
                _DataCode = value;
                RaisePropertyChanged("DataCode");
            }
        }
        private string _DataCode;
        [StringLength(10)]
        public string Header
        {
            get
            {
                return _Header;
            }
            set
            {
                if (Equals(_Header, value)) return;
                _Header = value;
                RaisePropertyChanged("Header");
            }
        }
        private string _Header;
        [Column("Length")]
        public Nullable<int> Length
        {
            get
            {
                return _Length;
            }
            set
            {
                if (Equals(_Length, value)) return;
                _Length = value;
                RaisePropertyChanged("Length");
            }
        }
        private Nullable<int> _Length;
        [Column("MaxID")]
        public Nullable<int> MaxID
        {
            get
            {
                return _MaxID;
            }
            set
            {
                if (Equals(_MaxID, value)) return;
                _MaxID = value;
                RaisePropertyChanged("MaxID");
            }
        }
        private Nullable<int> _MaxID;
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
