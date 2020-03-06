using Abp.Application.Services.Dto;
using Abp.AutoMapper;


namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Nation))]
    public class NationListDto:EntityDto
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int Order { get; set; }
    }
}
