using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.MultiTenancy;
using Fun2RepairMVC.Users;
using Microsoft.AspNet.Identity;

namespace Fun2RepairMVC
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class Fun2RepairMVCAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected Fun2RepairMVCAppServiceBase()
        {
            LocalizationSourceName = Fun2RepairMVCConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}