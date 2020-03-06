using Abp.Domain.Entities;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    public class CmsParameterTranslation : Entity,IEntityTranslation<CmsParameter>
    {
        public string Name { get; set; }

        public CmsParameter Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
