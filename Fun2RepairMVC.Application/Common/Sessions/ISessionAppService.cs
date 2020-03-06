using System.Threading.Tasks;
using Abp.Application.Services;
using Fun2RepairMVC.Sessions.Dto;

namespace Fun2RepairMVC.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
