using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [AutoMap(typeof(CmsOption))]
    public class CmsOptionDto:EntityDto<long>
    {
        public virtual long ParaId { get; set; }
        public virtual string OptionValue { get; set; }

        public virtual int OrderNo { get; set; }
        public virtual ICollection<CmsOptionTranslation> Translations { get; set; }

    }
}
