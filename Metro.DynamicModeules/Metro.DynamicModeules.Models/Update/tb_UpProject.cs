using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Models.Update
{
    //[Table("tb_UpProject")]
    public class tb_UpProject
    {
        //public string id { get; set; }

        [Required(ErrorMessage = "必填")]
        public string name { get; set; }

        [Required]
        public int type { get; set; }

        [Required(ErrorMessage = "必填")]
        [Key]
        [Column("code")]
        [StringLength(50)]
        public string code { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [StringLength(500)]
        public string remark { get; set; }

        [Required]
        public bool Disable { get; set; }

        [StringLength(100)]
        public string downloadserverurl { get; set; }

    }
}
