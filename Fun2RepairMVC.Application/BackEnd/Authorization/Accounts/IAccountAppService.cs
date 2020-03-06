using System.Threading.Tasks;
using Abp.Application.Services;
using Fun2RepairMVC.Authorization.Accounts.Dto;

namespace Fun2RepairMVC.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
