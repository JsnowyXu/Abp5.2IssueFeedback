using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using Fun2RepairMVC.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using Abp.Authorization.Functions;

namespace Fun2RepairMVC.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<Fun2RepairMVC.EntityFramework.Fun2RepairMVCDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }
        private readonly AbpFunctionManager _functionManager;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Fun2RepairMVC";
        }
        public Configuration(AbpFunctionManager functionManager)
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Fun2RepairMVC";
            _functionManager = functionManager;
        }

        protected override void Seed(Fun2RepairMVC.EntityFramework.Fun2RepairMVCDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context, _functionManager).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1, _functionManager).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
