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
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId
        {
            get
            {
                return _itemId;
            }
            set
            {
                if (Equals(_itemId, value)) return;
                _itemId = value;
                RaisePropertyChanged("ItemId");
            }
        }
        int _itemId;

        [Key]
        [Column(Order = 1)]
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
    }
}
