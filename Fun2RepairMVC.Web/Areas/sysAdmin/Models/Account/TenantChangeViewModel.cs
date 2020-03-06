using Abp.AutoMapper;
using Fun2RepairMVC.Sessions.Dto;

namespace Fun2RepairMVC.Web.Areas.sysAdmin.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}