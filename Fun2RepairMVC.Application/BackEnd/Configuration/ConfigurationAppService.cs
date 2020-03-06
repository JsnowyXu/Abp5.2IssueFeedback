using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Fun2RepairMVC.Configuration.Dto;

namespace Fun2RepairMVC.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Fun2RepairMVCAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
