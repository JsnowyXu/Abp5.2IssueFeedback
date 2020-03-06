using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(CityTranslation))]
    public class CityTranslationDto:EntityDto
    {
        public virtual string Name { get; set; }
        public string Language { get; set; }
    }
}
