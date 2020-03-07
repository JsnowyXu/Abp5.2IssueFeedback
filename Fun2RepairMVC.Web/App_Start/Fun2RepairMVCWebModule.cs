using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Auditing;
using Abp.Dependency;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.Zero.Configuration;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Web.SignalR;
using Fun2RepairMVC.Api;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Hangfire;
using Microsoft.Owin.Security;
using Abp.Configuration.Startup;

namespace Fun2RepairMVC.Web
{
    [DependsOn(
        typeof(Fun2RepairMVCDataModule),
        typeof(Fun2RepairMVCApplicationModule),
        typeof(Fun2RepairMVCWebApiModule),
        typeof(AbpWebSignalRModule),
        //typeof(AbpHangfireModule), - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
        typeof(AbpWebMvcModule))]
    public class Fun2RepairMVCWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu  

            //Configuration.Navigation.Providers.Add<Fun2RepairMVCFrontNavigationProvider>();

            //Configure Hangfire - ENABLE TO USE HANGFIRE INSTEAD OF DEFAULT JOB MANAGER
            //Configuration.BackgroundJobs.UseHangfire(configuration =>
            //{
            //    configuration.GlobalConfiguration.UseSqlServerStorage("Default");
            //});
            Configuration.Modules.AbpWeb().AntiForgery.IsEnabled = false;

            Configuration.ReplaceService(typeof(IClientInfoProvider), () =>
            {
                Configuration.IocManager.Register<IClientInfoProvider, AbpZeroTemplateClientInfoProvider>(DependencyLifeStyle.Transient);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(
                Component
                    .For<IAuthenticationManager>()
                    .UsingFactoryMethod(() => HttpContext.Current.GetOwinContext().Authentication)
                    .LifestyleTransient()
            );

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
