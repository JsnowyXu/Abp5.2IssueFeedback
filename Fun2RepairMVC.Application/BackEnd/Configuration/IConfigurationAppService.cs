using System.Threading.Tasks;
using Abp.Application.Services;
using Fun2RepairMVC.Configuration.Dto;

namespace Fun2RepairMVC.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}