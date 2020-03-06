using Abp.AutoMapper;
using System.Collections.Generic;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [AutoMap(typeof(Module))]
    public class ModuleDto
    {
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
        public virtual string Icon { get; set; }
        public virtual string TargetUrl { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsContent { get; set; }
        public virtual bool IsShowInManage { get; set; }
        public ICollection<ModuleTranslationDto> Translations { get; set; }
    }
}
