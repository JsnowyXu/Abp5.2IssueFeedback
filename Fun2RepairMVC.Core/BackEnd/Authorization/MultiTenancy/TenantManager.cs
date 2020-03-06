using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.Editions;

namespace Fun2RepairMVC.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}