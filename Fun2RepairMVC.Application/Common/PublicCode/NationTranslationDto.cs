using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(NationTranslation))]
    public class NationTranslationDto:EntityDto
    {
        public virtual string Name { get; set; }
        public string Language { get; set; }
    }
}
