using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Fun2RepairMVC.MultiTenancy;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.Extras
{
    [Table("extAnnounces")]
    public partial class Announce : FullAuditedEntity<long>,IMayHaveTenant
    {   
        public const int MaxTitleLength = 200;
        public const int MaxContentLength = 2000;

        [Required]
        [StringLength(MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        /// <summary>
        /// ¸m³»
        /// </summary>
        public virtual bool IsTop { get; set; }

        /// <summary>
        /// ¬O§_­«­n
        /// </summary>
        public virtual bool IsImportant { get; set; }

        public int? TenantId { get; set; }        
        

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }


    }
}
