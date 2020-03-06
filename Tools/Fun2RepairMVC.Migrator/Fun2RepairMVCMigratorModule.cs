using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Fun2RepairMVC.EntityFramework;

namespace Fun2RepairMVC.Migrator
{
    [DependsOn(typeof(Fun2RepairMVCDataModule))]
    public class Fun2RepairMVCMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<Fun2RepairMVCDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}