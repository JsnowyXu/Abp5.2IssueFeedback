using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.FrontEnd.Customers
{
    [AutoMap(typeof(CustomerGroup))]
    public class CustomerGroupListDto:EntityDto
    {
        public virtual string Name { get; set; }
       
        public virtual bool IsDefault { get; set; }
      
        public virtual bool IsActive { get; set; }
       
        public virtual bool IsStatic { get; set; }
       
        public virtual string Description { get; set; }

        
    }
}
