using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.PublicCode
{
    /// <summary>
    /// 省份
    /// </summary>
    [Table("pubProvinces")]
    public class Province : Entity,IMultiLingualEntity<ProvinceTranslation>
    {
        public const int MaxCodeLength = 100;
        [Required]
        [StringLength(MaxCodeLength)]
        public virtual string Code { get; set; }

        public virtual int NationId { get; set; }

        public virtual ICollection<ProvinceTranslation> Translations { get; set; }


    }
}
