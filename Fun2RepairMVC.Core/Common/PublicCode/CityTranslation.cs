using Abp.Domain.Entities;
namespace Fun2RepairMVC.Common.PublicCode
{
    public class CityTranslation : Entity,IEntityTranslation<City>
    {
        public string Name { get; set; }

        public City Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
