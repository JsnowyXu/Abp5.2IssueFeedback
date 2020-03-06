using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [AutoMap(typeof(CmsParameter))]
    public class CmsParameterDto:EntityDto<long>
    {
        public virtual int? ColumnId1 { get; set; }
        public virtual int? ColumnId2 { get; set; }
        public virtual int? ColumnId3 { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Description { get; set; }
        public virtual int ParaTypeId { get; set; }
        public virtual bool IsMandatory { get; set; }
        public virtual int? ModuleId { get; set; }
        public virtual int OrderNo { get; set; }
        public virtual bool IsDisplay { get; set; }
        public virtual string OptionValues { get; set; }

        public List<CmsParameterTranslationDto> Translations { get; set; }

    }
}
