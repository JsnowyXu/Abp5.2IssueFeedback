using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(City))]
    public class CityDto:EntityDto
    {
        public string Code { get; set; }

        public int ProvinceId { get; set; }

        public virtual ICollection<CityTranslationDto> Translations { get; set; }
    }
}
