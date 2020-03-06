using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Fun2RepairMVC.FrontEnd.Customers
{
    public class CustomerGroupTranslation: FullAuditedEntity, IEntityTranslation<CustomerGroup>
    {
        public string Name { get; set; }

        public CustomerGroup Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }
    }
}
