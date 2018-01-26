namespace Metro.DynamicModeules.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sys_BusinessTables")]
    public partial class sys_BusinessTables : INotifyPropertyChanged
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
        [Column("ModuleID")]
        public Nullable<int> ModuleID
        {
            get
            {
                return _ModuleID;
            }
            set
            {
                if (Equals(_ModuleID, value)) return;
                _ModuleID = value;
                RaisePropertyChanged("ModuleID");
            }
        }
        private Nullable<int> _ModuleID;

        public Nullable<int> SortID
        {
            get
            {
                return _SortID;
            }
            set
            {
                if (Equals(_SortID, value)) return;
                _SortID = value;
                RaisePropertyChanged("SortID");
            }
        }
        private Nullable<int> _SortID;

        [StringLength(50)]
        public string FormName
        {
            get
            {
                return _FormName;
            }
            set
            {
                if (Equals(_FormName, value)) return;
                _FormName = value;
                RaisePropertyChanged("FormName");
            }
        }
        private string _FormName;
        [StringLength(100)]
        public string FormNameSpace
        {
            get
            {
                return _FormNameSpace;
            }
            set
            {
                if (Equals(_FormNameSpace, value)) return;
                _FormNameSpace = value;
                RaisePropertyChanged("FormNameSpace");
            }
        }
        private string _FormNameSpace;
        [StringLength(50)]
        public string FormCaption
        {
            get
            {
                return _FormCaption;
            }
            set
            {
                if (Equals(_FormCaption, value)) return;
                _FormCaption = value;
                RaisePropertyChanged("FormCaption");
            }
        }
        private string _FormCaption;
        [StringLength(50)]
        public string KeyFieldName
        {
            get
            {
                return _KeyFieldName;
            }
            set
            {
                if (Equals(_KeyFieldName, value)) return;
                _KeyFieldName = value;
                RaisePropertyChanged("KeyFieldName");
            }
        }
        private string _KeyFieldName;
        [StringLength(50)]
        public string Table1
        {
            get
            {
                return _Table1;
            }
            set
            {
                if (Equals(_Table1, value)) return;
                _Table1 = value;
                RaisePropertyChanged("Table1");
            }
        }
        private string _Table1;
        [StringLength(50)]
        public string Table1Name
        {
            get
            {
                return _Table1Name;
            }
            set
            {
                if (Equals(_Table1Name, value)) return;
                _Table1Name = value;
                RaisePropertyChanged("Table1Name");
            }
        }
        private string _Table1Name;
        [StringLength(50)]
        public string Table2
        {
            get
            {
                return _Table2;
            }
            set
            {
                if (Equals(_Table2, value)) return;
                _Table2 = value;
                RaisePropertyChanged("Table2");
            }
        }
        private string _Table2;
        [StringLength(50)]
        public string Table2Name
        {
            get
            {
                return _Table2Name;
            }
            set
            {
                if (Equals(_Table2Name, value)) return;
                _Table2Name = value;
                RaisePropertyChanged("Table2Name");
            }
        }
        private string _Table2Name;
        [StringLength(50)]
        public string Table3
        {
            get
            {
                return _Table3;
            }
            set
            {
                if (Equals(_Table3, value)) return;
                _Table3 = value;
                RaisePropertyChanged("Table3");
            }
        }
        private string _Table3;
        [StringLength(50)]
        public string Table3Name
        {
            get
            {
                return _Table3Name;
            }
            set
            {
                if (Equals(_Table3Name, value)) return;
                _Table3Name = value;
                RaisePropertyChanged("Table3Name");
            }
        }
        private string _Table3Name;
        [StringLength(50)]
        public string Table4
        {
            get
            {
                return _Table4;
            }
            set
            {
                if (Equals(_Table4, value)) return;
                _Table4 = value;
                RaisePropertyChanged("Table4");
            }
        }
        private string _Table4;
        [StringLength(50)]
        public string Table4Name
        {
            get
            {
                return _Table4Name;
            }
            set
            {
                if (Equals(_Table4Name, value)) return;
                _Table4Name = value;
                RaisePropertyChanged("Table4Name");
            }
        }
        private string _Table4Name;
        [StringLength(50)]
        public string Table5
        {
            get
            {
                return _Table5;
            }
            set
            {
                if (Equals(_Table5, value)) return;
                _Table5 = value;
                RaisePropertyChanged("Table5");
            }
        }
        private string _Table5;
        [StringLength(50)]
        public string Table5Name
        {
            get
            {
                return _Table5Name;
            }
            set
            {
                if (Equals(_Table5Name, value)) return;
                _Table5Name = value;
                RaisePropertyChanged("Table5Name");
            }
        }
        private string _Table5Name;
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
