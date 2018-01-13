using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("sys_BusinessTables")]
    public partial class sys_BusinessTables: INotifyPropertyChanged
    {
	
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
[Column("SortID")]
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
[Column("FormName")]
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
[Column("FormNameSpace")]
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
[Column("FormCaption")]
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
[Column("KeyFieldName")]
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
[Column("Table1")]
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
[Column("Table1Name")]
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
[Column("Table2")]
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
[Column("Table2Name")]
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
[Column("Table3")]
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
[Column("Table3Name")]
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
[Column("Table4")]
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
[Column("Table4Name")]
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
[Column("Table5")]
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
[Column("Table5Name")]
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
