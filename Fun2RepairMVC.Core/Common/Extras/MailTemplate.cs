using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Localization;
using Fun2RepairMVC.Common.PublicCode;
using Fun2RepairMVC.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    /// <summary>
    /// 郵件模板
    /// </summary>
    [Table("extMailTemplates")]
    public partial class MailTemplate : FullAuditedEntity, IMayHaveTenant, IPassivable
    {
        public const int MaxSubjectLength = 200;
        public int MailTypeId { get; set; }
        public int LanguageId { get; set; }
        public int? TenantId { get; set; }
        [Required]
        [StringLength(MaxSubjectLength)]
        public string Subject { get; set; }
        [Required]
        public string MailBody { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsActive { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("MailTypeId")]
        public virtual Parameter MailType { get; set; }
        [ForeignKey("LanguageId")]
        public virtual ApplicationLanguage Language { get; set; }

    }
}
