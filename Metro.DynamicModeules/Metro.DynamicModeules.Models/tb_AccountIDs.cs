namespace Metro.DynamicModeules.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tb_AccountIDs")]
    public partial class tb_AccountIDs : INotifyPropertyChanged
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Column("AccID")]
        [Key]
        [StringLength(20)]
        public string AccID
        {
            get
            {
                return _AccID;
            }
            set
            {
                if (Equals(_AccID, value)) return;
                _AccID = value;
                RaisePropertyChanged("AccID");
            }
        }
        private string _AccID;
        [StringLength(50)]
        public string AccName
        {
            get
            {
                return _AccName;
            }
            set
            {
                if (Equals(_AccName, value)) return;
                _AccName = value;
                RaisePropertyChanged("AccName");
            }
        }
        private string _AccName;
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
