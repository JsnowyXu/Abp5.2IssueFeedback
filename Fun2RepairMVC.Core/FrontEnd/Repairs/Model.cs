using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;

namespace Fun2RepairMVC.FrontEnd.Repairs
{
    public class Model:FullAuditedEntity
    {
        //型號代碼，不重複
        [StringLength(20)]
        public virtual string Code { get; set; }
        //型號名稱
        [StringLength(50)]
        public virtual string Name { get; set; }

        //型號描述
        [StringLength(500)]
        public virtual string Description { get; set; }
        //型號對應圖片地址
        [StringLength(100)]
        public virtual string Image { get; set; }

    }
}
