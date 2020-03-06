using Abp.Authorization;
using Abp.Authorization.Functions;
using Abp.Localization;
using Abp.MultiTenancy;
using System.Collections.Generic;

namespace Fun2RepairMVC.Authorization
{
    public class Fun2RepairMVCAuthorizationProvider : AuthorizationProvider
    {
      
        private readonly AbpFunctionManager _functionManager;
        public Fun2RepairMVCAuthorizationProvider(AbpFunctionManager functionManager)
        {
            _functionManager = functionManager;
        }
        public override void SetPermissions(IPermissionDefinitionContext context)
        {

            ////// 需要權限驗證的所有有效菜單
            //List<AbpFunction> functions = _functionManager.GetPermissons();
            ////獲取權限列表
            //Dictionary<int, Permission> permissionList = new Dictionary<int, Permission>();
            //foreach (AbpFunction function in functions)
            //{
            //    if (!permissionList.ContainsKey(function.Id))
            //    {
            //        Permission perm = null;
            //        if (function.ParentId.HasValue && permissionList.ContainsKey(function.ParentId.Value))
            //        {
            //            var parent = permissionList[function.ParentId.Value];
            //            perm = parent.CreateChildPermission(function.Name, new LocalizableString(function.Name,Fun2RepairMVCConsts.LocalizationSourceName), multiTenancySides: function.MultiTenancySides);
            //        }
            //        else
            //        {
            //            perm = context.CreatePermission(function.Name, new LocalizableString(function.Name, Fun2RepairMVCConsts.LocalizationSourceName), multiTenancySides: function.MultiTenancySides);
            //        }
            //        permissionList.Add(function.Id, perm);

            //    }


            //}
            context.CreatePermission(PermissionNames.Pages_BasicInfo, L(PermissionNames.Pages_BasicInfo))
              .CreateChildPermission(PermissionNames.BasicInfo_SMSTemplate, L(PermissionNames.BasicInfo_SMSTemplate))
               .CreateChildPermission(PermissionNames.BasicInfo_MailTemplate, L(PermissionNames.BasicInfo_MailTemplate))
                .CreateChildPermission(PermissionNames.BasicInfo_NationMng, L(PermissionNames.BasicInfo_NationMng))
                 .CreateChildPermission(PermissionNames.BasicInfo_ProvinceMng, L(PermissionNames.BasicInfo_ProvinceMng))
                  .CreateChildPermission(PermissionNames.BasicInfo_CityMng, L(PermissionNames.BasicInfo_CityMng))
                   .CreateChildPermission(PermissionNames.BasicInfo_TownMng, L(PermissionNames.BasicInfo_TownMng));

            context.CreatePermission(PermissionNames.Pages_RepairInfo, L(PermissionNames.Pages_RepairInfo))
               .CreateChildPermission(PermissionNames.RepairInfo_FaultMng, L(PermissionNames.RepairInfo_FaultMng))
                .CreateChildPermission(PermissionNames.RepairInfo_RepairMng, L(PermissionNames.RepairInfo_RepairMng))
                 .CreateChildPermission(PermissionNames.RepairInfo_ModelMng, L(PermissionNames.RepairInfo_ModelMng))
                  .CreateChildPermission(PermissionNames.RepairInfo_MessageMng, L(PermissionNames.RepairInfo_MessageMng));

            context.CreatePermission(PermissionNames.Pages_VIPInfo, L(PermissionNames.Pages_VIPInfo))
             .CreateChildPermission(PermissionNames.VIPInfo_Customer, L(PermissionNames.VIPInfo_Customer))
              .CreateChildPermission(PermissionNames.VIPInfo_CustomerGroup, L(PermissionNames.VIPInfo_CustomerGroup))
               .CreateChildPermission(PermissionNames.VIPInfo_CustomerSetting, L(PermissionNames.VIPInfo_CustomerSetting));

            context.CreatePermission(PermissionNames.Pages_SiteInfo, L(PermissionNames.Pages_SiteInfo))
               .CreateChildPermission(PermissionNames.SiteInfo_BasicSetting, L(PermissionNames.SiteInfo_BasicSetting))
                .CreateChildPermission(PermissionNames.SiteInfo_Column, L(PermissionNames.SiteInfo_Column))
                 .CreateChildPermission(PermissionNames.SiteInfo_Banner, L(PermissionNames.SiteInfo_Banner))
                  .CreateChildPermission(PermissionNames.SiteInfo_Module, L(PermissionNames.SiteInfo_Module))
                   .CreateChildPermission(PermissionNames.SiteInfo_ServiceSetting, L(PermissionNames.SiteInfo_ServiceSetting))
                   .CreateChildPermission(PermissionNames.SiteInfo_Index, L(PermissionNames.SiteInfo_Index))
                   .CreateChildPermission(PermissionNames.SiteInfo_Footer, L(PermissionNames.SiteInfo_Footer))
                  .CreateChildPermission(PermissionNames.SiteInfo_ContactUsSetting, L(PermissionNames.SiteInfo_ContactUsSetting))
                 .CreateChildPermission(PermissionNames.SiteInfo_AboutUsSetting, L(PermissionNames.SiteInfo_AboutUsSetting));

            context.CreatePermission(PermissionNames.Pages_System, L(PermissionNames.Pages_System))
                .CreateChildPermission(PermissionNames.System_Tenants, L(PermissionNames.System_Tenants))
                 .CreateChildPermission(PermissionNames.System_Users, L(PermissionNames.System_Users))
                  .CreateChildPermission(PermissionNames.System_Roles, L(PermissionNames.System_Roles))
                   .CreateChildPermission(PermissionNames.System_Parameters, L(PermissionNames.System_Parameters))
                    .CreateChildPermission(PermissionNames.System_AuditLogs, L(PermissionNames.System_AuditLogs));

            context.CreatePermission(PermissionNames.Pages_Developer, L(PermissionNames.Pages_Developer))
                .CreateChildPermission(PermissionNames.Developer_AppSetting, L(PermissionNames.Developer_AppSetting))
                 .CreateChildPermission(PermissionNames.Developer_Function, L(PermissionNames.Developer_Function))
                  .CreateChildPermission(PermissionNames.Developer_Language, L(PermissionNames.Developer_Language));
        }


        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Fun2RepairMVCConsts.LocalizationSourceName);
        }
    }
}
