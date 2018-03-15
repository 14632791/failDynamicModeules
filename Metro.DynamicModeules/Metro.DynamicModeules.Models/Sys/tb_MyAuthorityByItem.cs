namespace Metro.DynamicModeules.Models.Sys
{
    using Metro.DynamicModeules.Models.Base;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_MyAuthorityByItem")]
    public class tb_MyAuthorityByItem: NotifyPropertyChanged
    {
        

        [Key]
        [Column("MenuId",Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId
        {
            get
            {
                return _menuId;
            }
            set
            {
                if (Equals(_menuId, value)) return;
                _menuId = value;
                RaisePropertyChanged("MenuId");
            }
        }
        int _menuId;

        /// <summary>
        /// °´Å¥code
        /// </summary>
        [Column("code",Order =1)]
        [StringLength(20)]
        [Key]
        public string AuthorityCode
        {
            get
            {
                return _code;
            }
            set
            {
                if (Equals(_code, value)) return;
                _code = value;
                RaisePropertyChanged("AuthorityCode");
            }
        }
        private string _code;
    }
}
