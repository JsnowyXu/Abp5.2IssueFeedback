using System.Collections.Generic;
using Abp.Application.Navigation;
using Abp.Authorization.Functions;
using Abp.Localization;
using Abp.Domain.Uow;
using Abp.Authorization;
using Fun2RepairMVC.Authorization;
using Fun2RepairMVC.Authorization.Users;
using Abp.Domain.Repositories;

namespace Fun2RepairMVC.Authorization
{
    public class Fun2RepairMVCNavigationProvider : NavigationProvider
    {
        private readonly IRepository<AbpFunction> _functionManager;
        public Fun2RepairMVCNavigationProvider(IRepository<AbpFunction> functionManager)
        {
            _functionManager = functionManager;
        }
        public override void SetNavigation(INavigationProviderContext context)
        {
            var test = _functionManager.GetAll();
            context.Manager.MainMenu
               .AddItem(
                   new MenuItemDefinition(
                       PermissionNames.Pages_BasicInfo,
                       L(PermissionNames.Pages_BasicInfo),
                       url: "",
                       icon: "home",
                       requiresAuthentication: true
                   ).AddItem(
                         new MenuItemDefinition(
                           PermissionNames.BasicInfo_MailTemplate,
                           L("PermissionNames.BasicInfo_MailTemplate"),
                           url: "/sysAdmin/Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.BasicInfo_MailTemplate)
                       )
                  ).AddItem(
                         new MenuItemDefinition(
                           PermissionNames.BasicInfo_MailTemplate,
                           L(PermissionNames.BasicInfo_MailTemplate),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.BasicInfo_SMSTemplate)
                       )
                  ).AddItem(
                         new MenuItemDefinition(
                           PermissionNames.BasicInfo_NationMng,
                           L(PermissionNames.BasicInfo_NationMng),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.BasicInfo_NationMng)
                       )
                  )
               ).AddItem(
                   new MenuItemDefinition(
                       PermissionNames.Pages_RepairInfo,
                       L(PermissionNames.Pages_RepairInfo),
                       url: "Tenants",
                       icon: "business",
                       permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_RepairInfo)
                   ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.RepairInfo_RepairMng,
                           L(PermissionNames.RepairInfo_RepairMng),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.RepairInfo_RepairMng)
                            )
                      ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.RepairInfo_ModelMng,
                           L(PermissionNames.RepairInfo_ModelMng),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.RepairInfo_ModelMng)
                            )
                      ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.RepairInfo_MessageMng,
                           L(PermissionNames.RepairInfo_MessageMng),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.RepairInfo_MessageMng)
                            )
                      ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.RepairInfo_FaultMng,
                           L(PermissionNames.RepairInfo_FaultMng),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.RepairInfo_FaultMng)
                            )
                      )

               ).AddItem(
                   new MenuItemDefinition(
                       PermissionNames.Pages_VIPInfo,
                       L(PermissionNames.Pages_VIPInfo),
                       url: "Tenants",
                       icon: "business",
                       permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_VIPInfo)
                   ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.VIPInfo_Customer,
                           L(PermissionNames.VIPInfo_Customer),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.VIPInfo_Customer)
                            )
                      ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.VIPInfo_CustomerGroup,
                           L(PermissionNames.VIPInfo_CustomerGroup),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.VIPInfo_CustomerGroup)
                            )
                      ).AddItem(
                           new MenuItemDefinition(
                           PermissionNames.VIPInfo_CustomerSetting,
                           L(PermissionNames.VIPInfo_CustomerSetting),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.VIPInfo_CustomerSetting)
                            )
                      )
               ).AddItem(
                   new MenuItemDefinition(
                           PermissionNames.Pages_SiteInfo,
                           L(PermissionNames.Pages_SiteInfo),
                           url: "Tenants",
                           icon: "business",
                           permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_SiteInfo)
                           )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_BasicSetting,
                               L(PermissionNames.SiteInfo_BasicSetting),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_BasicSetting)
                              )
                           )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_Column,
                               L(PermissionNames.SiteInfo_Column),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_Column)
                                )
                          ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_Banner,
                               L(PermissionNames.SiteInfo_Banner),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_Banner)
                                )
                          ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_Module,
                               L(PermissionNames.SiteInfo_Module),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_Module)
                                )
                          ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_Index,
                               L(PermissionNames.SiteInfo_Index),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_Index)
                                )
                            )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_Footer,
                               L(PermissionNames.SiteInfo_Footer),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_Footer)
                                )
                            )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_AboutUsSetting,
                               L(PermissionNames.SiteInfo_AboutUsSetting),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_AboutUsSetting)
                                )
                            )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_ContactUsSetting,
                               L(PermissionNames.SiteInfo_ContactUsSetting),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_ContactUsSetting)
                                )
                            )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.SiteInfo_ServiceSetting,
                               L(PermissionNames.SiteInfo_ServiceSetting),
                               url: "Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.SiteInfo_ServiceSetting)
                                )
                            )
               ).AddItem(
                        new MenuItemDefinition(
                        PermissionNames.Pages_System,
                        L(PermissionNames.Pages_System),
                        url: "",
                        icon: "business",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_System)
                        ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Tenants,
                               L(PermissionNames.System_Tenants),
                               url: "/sysAdmin./Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Tenants)
                                )
                            )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Users,
                               L(PermissionNames.System_Users),
                               url: "/sysadmin/Users",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Users)
                                )
                            )
                            .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Roles,
                               L(PermissionNames.System_Roles),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Roles)
                                )
                            ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Parameters,
                               L(PermissionNames.System_Parameters),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Parameters)
                                )
                            )
                              .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_TenantSetting,
                               L(PermissionNames.System_TenantSetting),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_TenantSetting)
                                )
                            )
                               .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_AuditLogs,
                               L(PermissionNames.System_AuditLogs),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_AuditLogs)
                                )
                            )
                                .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Calendars,
                               L(PermissionNames.System_Calendars),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Calendars)
                                )
                            ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_SMSLogs,
                               L(PermissionNames.System_SMSLogs),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_SMSLogs)
                                )
                            ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_EmailLogs,
                               L(PermissionNames.System_EmailLogs),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_EmailLogs)
                                )
                            )

               ).AddItem( //Menu items below is just for demonstration!
                   new MenuItemDefinition(
                               PermissionNames.Pages_Developer,
                               L(PermissionNames.Pages_Developer),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Developer)
                                ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.Developer_Function,
                               L(PermissionNames.Developer_Function),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.Developer_Function)
                                )
                            )
                                .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.Developer_Language,
                               L(PermissionNames.Developer_Language),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.Developer_Language)
                                )
                            ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.Developer_AppSetting,
                               L(PermissionNames.Developer_AppSetting),
                               url: "sysadmin/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.Developer_AppSetting)
                                )
                            )
  
               );
            //context.Manager.MainMenu.Items.Clear();
            //List<AbpFunction> sysMenus = _functionManager.GetMenus();
            //Dictionary<int, MenuItemDefinition> menuList = new Dictionary<int, MenuItemDefinition>();
            //foreach (AbpFunction menu in sysMenus)
            //{
            //    if (!menuList.ContainsKey(menu.Id))
            //    {
            //        MenuItemDefinition menuItem = new MenuItemDefinition(
            //            menu.Name,
            //            new LocalizableString(menu.Name, Fun2RepairMVCConsts.LocalizationSourceName),
            //            icon: menu.Icon,
            //            url: menu.Url,
            //            requiresAuthentication: menu.RequiresAuthentication,
            //            permissionDependency: new SimplePermissionDependency(menu.Name)
            //            );
            //        if (menu.ParentId.HasValue && menuList.ContainsKey(menu.ParentId.Value))
            //        {
            //            var parent = menuList[menu.ParentId.Value];
            //            parent.AddItem(menuItem);
            //        }
            //        else
            //        {
            //            context.Manager.MainMenu.AddItem(menuItem);
            //        }
            //        menuList.Add(menu.Id, menuItem);
            //    }
            //}
        }
        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Fun2RepairMVCConsts.LocalizationSourceName);
        }
    }
}
