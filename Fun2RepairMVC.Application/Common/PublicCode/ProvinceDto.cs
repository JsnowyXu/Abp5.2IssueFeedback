using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Province))]
    public class ProvinceDto:EntityDto
    {
        public virtual string Code { get; set; }

        public virtual int NationId { get; set; }
        public virtual ICollection<ProvinceTranslationDto> Translations { get; set; }
    }
}
