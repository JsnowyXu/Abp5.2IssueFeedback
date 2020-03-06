using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsOptionTranslation")]
    public class CmsOptionTranslation : Entity, IEntityTranslation<CmsOption>
    {
        public string Name { get; set; }

        public CmsOption Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }

    }
}
