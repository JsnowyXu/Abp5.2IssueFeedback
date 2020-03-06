using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Province))]
    public  class ProvinceListDto:EntityDto
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }

        public virtual int NationId { get; set; }

        public virtual int NationName { get; set; }
    }
}
