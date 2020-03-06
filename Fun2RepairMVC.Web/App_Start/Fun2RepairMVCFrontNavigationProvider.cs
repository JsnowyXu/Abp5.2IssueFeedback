using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Fun2RepairMVC.Authorization;
using Fun2RepairMVC.FrontEnd.CMS;
using System.Collections.Generic;

namespace Fun2RepairMVC.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class Fun2RepairMVCFrontNavigationProvider : NavigationProvider
    {
        private readonly ColumnManager _columnManager;
        public const string MenuName = "FrontMenu";
        public Fun2RepairMVCFrontNavigationProvider(ColumnManager columnManager)
        {
            _columnManager = columnManager;
        }
        public override void SetNavigation(INavigationProviderContext context)
        {
            var frontEndMenu = new MenuDefinition(MenuName, new FixedLocalizableString("FrontEnd Navigation"));
            context.Manager.Menus[MenuName] = frontEndMenu;
            context.Manager.Menus[MenuName].Items.Clear();
            List<Column> sysMenus = _columnManager.GetFrontMenus();
            Dictionary<int, MenuItemDefinition> menuList = new Dictionary<int, MenuItemDefinition>();
            foreach (Column menu in sysMenus)
            {
                if (!menuList.ContainsKey(menu.Id))
                {
                    object customerObj = "";
                    if (menu.Height != 0)
                    {
                        customerObj += menu.Height.ToString() + "|" + menu.BannerTypeId;
                    }
                    MenuItemDefinition menuItem = new MenuItemDefinition(
                        name: menu.Name,
                        displayName: new LocalizableString(menu.Name, Fun2RepairMVCConsts.LocalizationSourceName),
                        icon: menu.Icon,
                        url: menu.TargetUrl,
                        requiresAuthentication: menu.RequiresAuthentication,
                        permissionDependency: new SimplePermissionDependency(menu.Name),
                        order: menu.Id,
                        customData: customerObj,
                        featureDependency: null,
                        target: menu.TargetWindow,
                        isEnabled: menu.IsContent,
                        isVisible: menu.IsExternal
                        );
                    if (menu.BigClassId.HasValue && menuList.ContainsKey(menu.BigClassId.Value))
                    {
                        var parent = menuList[menu.BigClassId.Value];
                        parent.AddItem(menuItem);
                    }
                    else
                    {
                        frontEndMenu.AddItem(menuItem);
                    }
                    menuList.Add(menu.Id, menuItem);
                }
            }



            #region 手動菜單
            //context.Manager.MainMenu
            //    .AddItem(
            //        new MenuItemDefinition(
            //            PageNames.Home,
            //            L("HomePage"),
            //            url: "",
            //            icon: "home",
            //            requiresAuthentication: true
            //        )
            //    ).AddItem(
            //        new MenuItemDefinition(
            //            PageNames.Tenants,
            //            L("Tenants"),
            //            url: "Tenants",
            //            icon: "business",
            //            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
            //        )
            //    ).AddItem(
            //        new MenuItemDefinition(
            //            PageNames.Users,
            //            L("Users"),
            //            url: "Users",
            //            icon: "people",
            //            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
            //        )
            //    ).AddItem(
            //        new MenuItemDefinition(
            //            PageNames.Roles,
            //            L("Roles"),
            //            url: "Roles",
            //            icon: "local_offer",
            //            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
            //        )
            //    )
            //    .AddItem(
            //        new MenuItemDefinition(
            //            PageNames.About,
            //            L("About"),
            //            url: "About",
            //            icon: "info"
            //        )
            //    ).AddItem( //Menu items below is just for demonstration!
            //        new MenuItemDefinition(
            //            "MultiLevelMenu",
            //            L("MultiLevelMenu"),
            //            icon: "menu"
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetBoilerplate",
            //                new FixedLocalizableString("ASP.NET Boilerplate")
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetBoilerplateHome",
            //                    new FixedLocalizableString("Home"),
            //                    url: "https://aspnetboilerplate.com?ref=abptmpl"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetBoilerplateTemplates",
            //                    new FixedLocalizableString("Templates"),
            //                    url: "https://aspnetboilerplate.com/Templates?ref=abptmpl"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetBoilerplateSamples",
            //                    new FixedLocalizableString("Samples"),
            //                    url: "https://aspnetboilerplate.com/Samples?ref=abptmpl"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetBoilerplateDocuments",
            //                    new FixedLocalizableString("Documents"),
            //                    url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl"
            //                )
            //            )
            //        ).AddItem(
            //            new MenuItemDefinition(
            //                "AspNetZero",
            //                new FixedLocalizableString("ASP.NET Zero")
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetZeroHome",
            //                    new FixedLocalizableString("Home"),
            //                    url: "https://aspnetzero.com?ref=abptmpl"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetZeroDescription",
            //                    new FixedLocalizableString("Description"),
            //                    url: "https://aspnetzero.com/?ref=abptmpl#description"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetZeroFeatures",
            //                    new FixedLocalizableString("Features"),
            //                    url: "https://aspnetzero.com/?ref=abptmpl#features"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetZeroPricing",
            //                    new FixedLocalizableString("Pricing"),
            //                    url: "https://aspnetzero.com/?ref=abptmpl#pricing"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetZeroFaq",
            //                    new FixedLocalizableString("Faq"),
            //                    url: "https://aspnetzero.com/Faq?ref=abptmpl"
            //                )
            //            ).AddItem(
            //                new MenuItemDefinition(
            //                    "AspNetZeroDocuments",
            //                    new FixedLocalizableString("Documents"),
            //                    url: "https://aspnetzero.com/Documents?ref=abptmpl"
            //                )
            //            )
            //        )
            //    );
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Fun2RepairMVCConsts.LocalizationSourceName);
        }
    }
}
