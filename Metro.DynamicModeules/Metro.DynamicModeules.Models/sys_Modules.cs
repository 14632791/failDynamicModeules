namespace Metro.DynamicModeules.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sys_Modules")]
    public partial class sys_Modules : INotifyPropertyChanged
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleID
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
        private int _ModuleID;
        [StringLength(50)]
        public string ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                if (Equals(_ModuleName, value)) return;
                _ModuleName = value;
                RaisePropertyChanged("ModuleName");
            }
        }
        private string _ModuleName;
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
