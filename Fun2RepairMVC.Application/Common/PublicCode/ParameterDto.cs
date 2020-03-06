using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;


namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Parameter))]
    public class ParameterDto:EntityDto
    {
        public CodeTypes Type { get; set; }
        public string Code { get; set; }
        //是否為輸入選項
        public bool IsInput { get; set; }
        public string Description { get; set; }
        //排序
        public int Order { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ParameterTranslationDto> Translations { get; set; }
    }
}
