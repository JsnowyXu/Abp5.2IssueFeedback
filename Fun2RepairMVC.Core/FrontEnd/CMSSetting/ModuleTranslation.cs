using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [Table("cmsModulesTranslation")]
    public class ModuleTranslation:Entity,IEntityTranslation<Module>
    {
        public string Name { get; set; }

        public Module Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }

    }
}
