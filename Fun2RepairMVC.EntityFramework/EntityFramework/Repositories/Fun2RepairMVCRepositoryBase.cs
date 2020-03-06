using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Fun2RepairMVC.EntityFramework.Repositories
{
    public abstract class Fun2RepairMVCRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<Fun2RepairMVCDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected Fun2RepairMVCRepositoryBase(IDbContextProvider<Fun2RepairMVCDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class Fun2RepairMVCRepositoryBase<TEntity> : Fun2RepairMVCRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected Fun2RepairMVCRepositoryBase(IDbContextProvider<Fun2RepairMVCDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
