using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Metro.DynamicModeules.Models
{
    [Table("tb_AttachFile")]
    public partial class tb_AttachFile: INotifyPropertyChanged
    {
	
[Column("FileID")]
        public int FileID 
		{ 
		   get
           {
               return _FileID;
           }
           set
           {
               if (Equals(_FileID, value)) return;
               _FileID = value;
               RaisePropertyChanged("FileID");
           }
		} 
		private int _FileID;
[Column("DocID")]
        public string DocID 
		{ 
		   get
           {
               return _DocID;
           }
           set
           {
               if (Equals(_DocID, value)) return;
               _DocID = value;
               RaisePropertyChanged("DocID");
           }
		} 
		private string _DocID;
[Column("FileTitle")]
        public string FileTitle 
		{ 
		   get
           {
               return _FileTitle;
           }
           set
           {
               if (Equals(_FileTitle, value)) return;
               _FileTitle = value;
               RaisePropertyChanged("FileTitle");
           }
		} 
		private string _FileTitle;
[Column("FileName")]
        public string FileName 
		{ 
		   get
           {
               return _FileName;
           }
           set
           {
               if (Equals(_FileName, value)) return;
               _FileName = value;
               RaisePropertyChanged("FileName");
           }
		} 
		private string _FileName;
[Column("FileType")]
        public string FileType 
		{ 
		   get
           {
               return _FileType;
           }
           set
           {
               if (Equals(_FileType, value)) return;
               _FileType = value;
               RaisePropertyChanged("FileType");
           }
		} 
		private string _FileType;
[Column("FileSize")]
        public Nullable<decimal> FileSize 
		{ 
		   get
           {
               return _FileSize;
           }
           set
           {
               if (Equals(_FileSize, value)) return;
               _FileSize = value;
               RaisePropertyChanged("FileSize");
           }
		} 
		private Nullable<decimal> _FileSize;
[Column("FileBody")]
        public byte[] FileBody 
		{ 
		   get
           {
               return _FileBody;
           }
           set
           {
               if (Equals(_FileBody, value)) return;
               _FileBody = value;
               RaisePropertyChanged("FileBody");
           }
		} 
		private byte[] _FileBody;
[Column("IsDroped")]
        public string IsDroped 
		{ 
		   get
           {
               return _IsDroped;
           }
           set
           {
               if (Equals(_IsDroped, value)) return;
               _IsDroped = value;
               RaisePropertyChanged("IsDroped");
           }
		} 
		private string _IsDroped;
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
