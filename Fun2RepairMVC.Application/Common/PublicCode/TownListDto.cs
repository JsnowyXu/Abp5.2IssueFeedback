using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Town))]
    public class TownListDto:EntityDto
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int CityId { get; set; }
        public virtual string CityName { get; set; }
    }
}
