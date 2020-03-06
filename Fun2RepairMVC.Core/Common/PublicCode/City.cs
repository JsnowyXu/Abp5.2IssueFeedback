using Abp.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.PublicCode
{
    [Table("pubCities")]
    public partial class City : Entity,IMultiLingualEntity<CityTranslation>
    {

        public const int MaxCodeLength = 100;
        public int ProvinceId { get; set; }
        [Required]
        [StringLength(MaxCodeLength)]
        public string Code { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public virtual ICollection<CityTranslation> Translations { get; set; }
    }
}
