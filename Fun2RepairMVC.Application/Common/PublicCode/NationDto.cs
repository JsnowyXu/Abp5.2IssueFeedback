using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Nation))]
    public class NationDto:EntityDto
    {
        public virtual string Code { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int Order { get; set; }
        public virtual ICollection<NationTranslationDto> Translations { get; set; }
    }
}
