using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using Fun2RepairMVC.Authorization;
using Fun2RepairMVC.Authorization.Roles;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.Configuration;
using Fun2RepairMVC.MultiTenancy;

namespace Fun2RepairMVC
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class Fun2RepairMVCCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = Fun2RepairMVCConsts.MultiTenancyEnabled;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    Fun2RepairMVCConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Fun2RepairMVC.Localization.Source"
                        )
                    )
                );

            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Navigation.Providers.Add<Fun2RepairMVCNavigationProvider>();

            Configuration.Authorization.Providers.Add<Fun2RepairMVCAuthorizationProvider>();
            
           

            Configuration.Settings.Providers.Add<AppSettingProvider>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
