using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    [Table("extAnnounceAttachements")]
    public partial class AnnounceAttachment : CreationAuditedEntity<long>
    { 
        public long AnnounceId { get; set; }
        public long AttachmentId { get; set; }

        [ForeignKey("AttachmentId")]
        public virtual Attachment Attachment { get; set; }

        [ForeignKey("AnnounceId")]
        public virtual Announce Notice { get; set; }

    }
}
