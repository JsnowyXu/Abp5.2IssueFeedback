using Abp.Domain.Entities;
namespace Fun2RepairMVC.Common.PublicCode
{
    public class ProvinceTranslation : Entity,IEntityTranslation<Province>
    {
        public string Name { get; set; }

        public Province Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
