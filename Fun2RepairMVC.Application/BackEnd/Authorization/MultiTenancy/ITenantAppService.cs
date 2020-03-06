using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Fun2RepairMVC.MultiTenancy.Dto;

namespace Fun2RepairMVC.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
