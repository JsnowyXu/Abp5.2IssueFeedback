using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Common.Extras;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.Repairs
{
    [Table("rpRepairAttachment")]
    public class RepairAttachment: CreationAuditedEntity<long>
    {
      public virtual long RepairApplyId { get; set; }
      public virtual long AttachmentId { get; set; }

        [ForeignKey("AttachmentId")]
        public virtual Attachment Attachment { get; set; }

        [ForeignKey("RepairApplyId")]
        public virtual RepairApply RepairApply { get; set; }

    }
}
