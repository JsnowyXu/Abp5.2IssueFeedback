using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Common.PublicCode;
using Fun2RepairMVC.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    /// <summary>
    /// 郵件發送記錄
    /// </summary>
    [Table("extMailLogs")]
    public partial class MailLog : CreationAuditedEntity<long>, IMayHaveTenant
    {
        public const int MaxSubjectLength = 200;
        public const int MaxAddressLength = 200;
        public const int MaxCodeLength = 20;

     
        public int MailTypeId { get; set; }
        [Required]
        [StringLength(MaxAddressLength)]
        public string MailAddress { get; set; }
        [Required]
        [StringLength(MaxSubjectLength)]
        public string Subject { get; set; }
        public string MailBody { get; set; }
        public System.DateTime SentOn { get; set; }
        [StringLength(MaxCodeLength)]
        public string LanguageCode { get; set; }
        public int? TenantId { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("MailTypeId")]
        public virtual Parameter MailType { get; set; }
    }
}
