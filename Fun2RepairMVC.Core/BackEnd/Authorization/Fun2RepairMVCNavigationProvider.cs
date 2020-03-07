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
        private readonly AbpFunctionManager _functionManager;
        public Fun2RepairMVCNavigationProvider(AbpFunctionManager functionManager)
        {
            _functionManager = functionManager;
        }
        public override void SetNavigation(INavigationProviderContext context)
        {
            // here will throw the error. 
           // if you want to run it ,please delete the below code
            var test = _functionManager.GetAll();


            context.Manager.MainMenu
               .AddItem(
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
                               url: "/sysAdmin/System/Tenants",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Tenants)
                                )
                            )
                          .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Users,
                               L(PermissionNames.System_Users),
                               url: "/sysadmin/System/Users",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Users)
                                )
                            )
                            .AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Roles,
                               L(PermissionNames.System_Roles),
                               url: "/sysadmin/System/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Roles)
                                )
                            ).AddItem(
                               new MenuItemDefinition(
                               PermissionNames.System_Parameters,
                               L(PermissionNames.System_Parameters),
                               url: "sysadmin/System/roles",
                               icon: "business",
                               permissionDependency: new SimplePermissionDependency(PermissionNames.System_Parameters)
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
