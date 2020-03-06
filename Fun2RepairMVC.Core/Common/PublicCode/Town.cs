using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.Common.PublicCode
{
    public class Town:Entity
    {
        [Required]
        [StringLength(20)]
        public virtual string Code { get; set; }
        [Required]
        public virtual string Name { get; set; }
        public virtual int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
