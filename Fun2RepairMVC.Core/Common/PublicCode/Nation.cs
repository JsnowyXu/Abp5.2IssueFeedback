using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.PublicCode
{
    /// <summary>
    /// 區域：如亞洲，歐洲等
    /// </summary>
    [Table("pubNations")]
    public partial class Nation : FullAuditedEntity, IPassivable,IMultiLingualEntity<NationTranslation>
    {

        public const int MaxCodeLength = 20;
        public const int MaxDescLength = 50;

        [Required]
        [StringLength(MaxCodeLength)]
        public virtual string Code { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public virtual bool IsActive { get; set; }

        public virtual int Order { get; set; }

        public virtual ICollection<NationTranslation> Translations { get; set; }
    }
}
