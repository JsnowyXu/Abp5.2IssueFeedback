using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using Fun2RepairMVC.EntityFramework;

namespace Fun2RepairMVC
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(Fun2RepairMVCCoreModule))]
    public class Fun2RepairMVCDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Fun2RepairMVCDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
