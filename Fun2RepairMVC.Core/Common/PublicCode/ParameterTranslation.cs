

using Abp.Domain.Entities;

namespace Fun2RepairMVC.Common.PublicCode
{
    public class ParameterTranslation: Entity, IEntityTranslation<Parameter>
    {

        public string Name { get; set; }

        public Parameter Core { get; set; }

        public int CoreId { get; set; }

        public string Language { get; set; }

    }
}
