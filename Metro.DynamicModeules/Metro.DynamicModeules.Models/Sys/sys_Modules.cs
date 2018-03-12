namespace Metro.DynamicModeules.Models.Sys
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Collections.ObjectModel;

    [Table("sys_Modules")]
    public partial class sys_Modules : INotifyPropertyChanged
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_Modules()
        {
            //tb_MyMenu = new ObservableCollection<tb_MyMenu>();
        }

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
        /// <summary>
        /// Ä£¿éÃû³Æ
        /// </summary>
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
		
		//public virtual ICollection<tb_MyMenu> tb_MyMenu { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event if needed.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
