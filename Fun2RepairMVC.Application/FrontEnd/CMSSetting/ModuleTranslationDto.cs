using Abp.AutoMapper;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    [AutoMap(typeof(ModuleTranslation))]
    public class ModuleTranslationDto
    {
        public virtual string Name { get; set; }
        public string Language { get; set; }
    }
}
