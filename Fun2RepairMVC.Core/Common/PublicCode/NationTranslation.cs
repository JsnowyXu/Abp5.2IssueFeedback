using Abp.Domain.Entities;
namespace Fun2RepairMVC.Common.PublicCode
{
    public class NationTranslation:Entity,IEntityTranslation<Nation>
    {
        public string Name { get; set; }

        public Nation Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
