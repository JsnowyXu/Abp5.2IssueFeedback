using System.Collections.Generic;
using Abp.Configuration;

namespace Fun2RepairMVC.Configuration
{
    public class AppSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                //new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                new SettingDefinition(AppSettingNames.UiTheme, "red", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.HeaderFixed, "", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.MenuLayout, "layout-top-nav", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.SidebarClosed, "", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.DefaultPageSize, "20", scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User, isVisibleToClients: true),

                 new SettingDefinition(AppSettingNames.WebSiteName, "", scopes: SettingScopes.Application, isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.WebSiteLogo, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.AddressIcon, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.WebSiteAddress, "", scopes: SettingScopes.Application, isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.WebSiteKeywords, "", scopes: SettingScopes.Application ,isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.WebSiteDecription, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.LogoPositionDown, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.LogoPositionRight, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.WebSiteTitle, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.EmailSender, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.EmailAccount, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.TopCode, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.BottomCode, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.LinkSetting, "", scopes: SettingScopes.Application , isVisibleToClients: true),
                new SettingDefinition(AppSettingNames.SMSIntervalTime.ToString(),"60",scopes:SettingScopes.Application,isVisibleToClients:true),
                new SettingDefinition(AppSettingNames.SMSCodeLength.ToString(),"4",scopes:SettingScopes.Application,isVisibleToClients:true),
                new SettingDefinition(AppSettingNames.SMSCodeValidTime.ToString(),"180",scopes:SettingScopes.Application,isVisibleToClients:true),
                new SettingDefinition(AppSettingNames.EmailCodeValidTime.ToString(),"10",scopes:SettingScopes.Application,isVisibleToClients:true),

            };
        }
    }
}