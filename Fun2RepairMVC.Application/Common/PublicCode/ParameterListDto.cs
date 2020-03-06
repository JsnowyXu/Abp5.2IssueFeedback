using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.Common.PublicCode
{
    [AutoMap(typeof(Parameter))]
    public class ParameterListDto:EntityDto
    {
        public CodeTypes Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        //是否為輸入選項
        public bool IsInput { get; set; }
        public string Description { get; set; }
        //排序
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
