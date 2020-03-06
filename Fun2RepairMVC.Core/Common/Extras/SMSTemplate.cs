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
    /// 短信模板
    /// </summary>
    [Table("extSMSTemplates")]
    public partial class SMSTemplate : FullAuditedEntity, IMayHaveTenant, IPassivable
    {
        public const int MaxTextLength = 1000;
        public int SMSTemplateId { get; set; }
        public int SMSTypeId { get; set; }
        public int LanguageId { get; set; }
        public int? TenantId { get; set; }
        [Required]
        [StringLength(MaxTextLength)]
        public string SMSText { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsActive { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("SMSTypeId")]
        public virtual Parameter SMSType { get; set; }

        [ForeignKey("LanguageId")]
        public virtual ApplicationLanguage Language { get; set; }
    }
}
