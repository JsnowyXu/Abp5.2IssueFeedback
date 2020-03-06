using Abp.Domain.Services;

namespace Fun2RepairMVC
{
    public abstract class Fun2RepairMVCDomainService : DomainService
    {
        protected Fun2RepairMVCDomainService()
        {
            LocalizationSourceName = Fun2RepairMVCConsts.LocalizationSourceName;
        }
        
    }
}
