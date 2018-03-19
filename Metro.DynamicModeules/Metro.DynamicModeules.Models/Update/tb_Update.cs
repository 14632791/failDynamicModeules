using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.DynamicModeules.Models.Update
{
    //[Table("tb_Update")]
    public class tb_Update //: PagedModel
    {
        /// <summary>
        /// guid的string值
        /// </summary>
        [Key]
        [StringLength(32)]
        public string id { get; set; }

        [Required]
        public string projectCode { get; set; }

        [Required(ErrorMessage = "必填项")]
        public string version { get; set; }

        public Nullable<bool> mandatory { get; set; }

        [NotMapped]
        public string MandatoryBoolText
        {
            get
            {
                return (bool)mandatory ? "是" : "否";
            }
        }
        public string downloadurl { get; set; }

        public string serverUrl { get; set; }
        public string updatelog { get; set; }
        public string remark { get; set; }

        /// <summary>
        /// 0 = XPx86...参考UpdateType
        /// </summary>
        public int? updateType { get; set; }
        public DateTime? createdon { get; set; }

    }

    /// <summary>
    /// 更新的客户端类型
    /// </summary>
    public enum UpdateType
    {
        XPx86 = 0,
        XPx64,
        Win7x86,
        Win7x64
    }
}
