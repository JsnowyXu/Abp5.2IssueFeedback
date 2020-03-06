using Fun2RepairMVC.EntityFramework;
using EntityFramework.DynamicFilters;
using Abp.Authorization.Functions;

namespace Fun2RepairMVC.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly Fun2RepairMVCDbContext _context;
        private readonly AbpFunctionManager _functionManager;

        public InitialHostDbBuilder(Fun2RepairMVCDbContext context, AbpFunctionManager functionManager)
        {
            _context = context;
            _functionManager = functionManager;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context, _functionManager).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
