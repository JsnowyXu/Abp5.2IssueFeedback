using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [AutoMap(typeof(CmsOptionTranslation))]
    public  class CmsOptionTranslationDto:EntityDto<long>
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
