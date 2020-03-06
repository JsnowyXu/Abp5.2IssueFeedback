using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.PublicCode
{

    [Table("pubParameters")]
    public partial class Parameter : FullAuditedEntity, IPassivable,IMultiLingualEntity<ParameterTranslation>
    {
        public const int MaxCodeLength = 20;
        public const int MaxDescLength = 500;

        public CodeTypes Type { get; set; }
        [Required]
        [StringLength(MaxCodeLength)]
        public string Code { get; set; }
        //是否為輸入選項
        public bool IsInput { get; set; }
        public string Description { get; set; }
        //排序
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ParameterTranslation> Translations { get; set; }
    }
}
