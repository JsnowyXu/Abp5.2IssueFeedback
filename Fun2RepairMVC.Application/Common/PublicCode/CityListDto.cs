using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(City))]
    public class CityListDto:EntityDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }

    }
}
