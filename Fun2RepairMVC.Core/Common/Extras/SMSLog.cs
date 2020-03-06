using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.Common.PublicCode;
using Fun2RepairMVC.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    /// <summary>
    /// 短信發送記錄
    /// </summary>
    [Table("extSMSLogs")]
    public partial class SMSLog : CreationAuditedEntity<long>, IMayHaveTenant
    {
        public const int MaxNumberLength = 20;
        public int? TenantId { get; set; }
        public int SMSTypeId { get; set; }
        [Required]
        [StringLength(MaxNumberLength)]
        public string PhoneNo { get; set; }
        [Required]
        public string SMSText { get; set; }
        public System.DateTime SentOn { get; set; }

        [StringLength(MaxNumberLength)]
        public string LanguageCode { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("SMSTypeId")]
        public virtual Parameter SMSType { get; set; }
    }
}
