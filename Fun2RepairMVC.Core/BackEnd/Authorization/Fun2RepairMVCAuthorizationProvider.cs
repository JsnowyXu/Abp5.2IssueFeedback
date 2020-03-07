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
            //for test the error

            //var test = _functionManager.GetAll();

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

            context.CreatePermission(PermissionNames.Pages_System, L(PermissionNames.Pages_System))
                .CreateChildPermission(PermissionNames.System_Tenants, L(PermissionNames.System_Tenants))
                 .CreateChildPermission(PermissionNames.System_Users, L(PermissionNames.System_Users))
                  .CreateChildPermission(PermissionNames.System_Roles, L(PermissionNames.System_Roles))
                   .CreateChildPermission(PermissionNames.System_Parameters, L(PermissionNames.System_Parameters));

        }


        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, Fun2RepairMVCConsts.LocalizationSourceName);
        }
    }
}
