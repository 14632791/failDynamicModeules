namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_ProductCategory")]
    public partial class tb_ProductCategory: INotifyPropertyChanged
    {
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]	
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
[Column("CategoryId")]
[Key]
        [StringLength(20)]
        public string CategoryId 
		{ 
		   get
           {
               return _CategoryId;
           }
           set
           {
               if (Equals(_CategoryId, value)) return;
               _CategoryId = value;
               RaisePropertyChanged("CategoryId");
           }
		} 
		private string _CategoryId;
[Column("ParentId")]
        public string ParentId 
		{ 
		   get
           {
               return _ParentId;
           }
           set
           {
               if (Equals(_ParentId, value)) return;
               _ParentId = value;
               RaisePropertyChanged("ParentId");
           }
		} 
		private string _ParentId;
[Column("CategoryName")]
 [StringLength(50)]
        public string CategoryName 
		{ 
		   get
           {
               return _CategoryName;
           }
           set
           {
               if (Equals(_CategoryName, value)) return;
               _CategoryName = value;
               RaisePropertyChanged("CategoryName");
           }
		} 
		private string _CategoryName;
[Column("Column1")]
 [StringLength(50)]
        public string Column1 
		{ 
		   get
           {
               return _Column1;
           }
           set
           {
               if (Equals(_Column1, value)) return;
               _Column1 = value;
               RaisePropertyChanged("Column1");
           }
		} 
		private string _Column1;
[Column("Remark")]
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
