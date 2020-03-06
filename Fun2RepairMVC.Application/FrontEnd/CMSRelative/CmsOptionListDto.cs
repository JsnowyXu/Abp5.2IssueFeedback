using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [AutoMap(typeof(CmsOption))]
    public class CmsOptionListDto:EntityDto<long>
    {
        public virtual string Name { get; set; }
        public virtual long ParaId { get; set; }
        
        public virtual string OptionValue { get; set; }

        public virtual int OrderNo { get; set; }
    }
}
