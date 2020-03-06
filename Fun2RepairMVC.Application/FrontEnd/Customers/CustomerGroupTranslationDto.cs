using Abp.AutoMapper;


namespace Fun2RepairMVC.FrontEnd.Customers
{
    [AutoMap(typeof(CustomerGroup))]
    public class CustomerGroupTranslationDto
    {
        public virtual string Name { get; set; }
        public string Language { get; set; }
    }
}
