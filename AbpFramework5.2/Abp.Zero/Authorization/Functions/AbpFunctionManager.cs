using Abp;
using Abp.Domain.Services;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;

namespace Abp.Authorization.Functions
{
    public class AbpFunctionManager : ITransientDependency
    {
        public readonly IRepository<AbpFunction> _functionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkRepository;
        public AbpFunctionManager(IRepository<AbpFunction> functionRepository, IUnitOfWorkManager unitOfWorkRepository)  
        {
            _functionRepository = functionRepository;
            _unitOfWorkRepository = unitOfWorkRepository;

        }
        /// <summary>
        /// 獲取有效的可見的菜單列表
        /// </summary>
        /// <returns></returns>
        public virtual List<AbpFunction> GetMenus()
        {
           var test= _functionRepository.GetAll();
            return _functionRepository.Query(
                q => q.Where(f => f.IsMenu).Where(f => f.IsEnable).Where(f => f.IsVisible)
                    .OrderBy(f => f.Sequence)
                    .ToList()
                );
        }
        /// <summary>
        /// 獲取需要權限驗證的所有有效此單
        /// </summary>
        /// <returns></returns>        
        public virtual List<AbpFunction> GetPermissons()
        {
            var test = _functionRepository.FirstOrDefault(1);
            return _functionRepository.Query(
                   q => q.Where(f => f.RequiresAuthentication)
                       .OrderBy(f => f.Sequence)
                       .ToList()
                   );
        }
        /// <summary>
        /// 獲取所有菜單項，主要用於功能管理
        /// </summary>
        /// <returns></returns>
        public IQueryable<AbpFunction> GetAll()
        {
            return _functionRepository.GetAll();
        }
        /// <summary>
        /// 新增一個功能菜單
        /// </summary>
        /// <param name="function">菜單對象</param>
        /// <returns></returns>
        public async Task<AbpFunction> CreateAsync(AbpFunction function)
        {
            return await _functionRepository.InsertAsync(function);
        }
        /// <summary>
        /// 更新菜單
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public async Task<AbpFunction> UpdateAsync(AbpFunction function)
        {
            return await _functionRepository.UpdateAsync(function);
        }
        /// <summary>
        /// 刪除一個功能菜單，如果有子項則先刪除子項在進行刪除
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public async Task Delteasync(AbpFunction function)
        {
            var children = _functionRepository.GetAllList(f => f.ParentId.HasValue && f.ParentId == function.Id);
            if (children != null && children.Count > 0)
            {
                foreach (AbpFunction item in children)
                {
                    await _functionRepository.DeleteAsync(item.Id);
                }
            }
            await _functionRepository.DeleteAsync(function);
        }
        /// <summary>
        /// 根據菜單的ID獲取一個菜單對象
        /// </summary>
        /// <param name="functionId">ID</param>
        /// <returns>AbpFunction</returns>
        ///  <exception cref="AbpException">未找到時拋出異常</exception>
        public virtual async Task<AbpFunction> GetFunctionByIdAsync(int? functionId)
        {
            var function = await _functionRepository.FirstOrDefaultAsync(f => f.Id == functionId);
            return function;
        }

        /// <summary>
        /// 根據菜單的名稱獲取一個菜單對象
        /// </summary>
        /// <param name="functionId">ID</param>
        /// <returns>AbpFunction</returns>
        ///  <exception cref="AbpException">未找到時拋出異常</exception>
        public virtual async Task<AbpFunction> GetFunctionByIdAsync(string functionName)
        {
            var function = await _functionRepository.FirstOrDefaultAsync(f => f.Name == functionName);
            if (function == null)
            {
                throw new AbpException("未找到該名稱的菜單項");
            }
            return function;
        }

        /// <summary>
        /// Gets a function by given name.
        /// Throws exception if no function with given functionName.
        /// </summary>
        /// <param name="functionName">Function name</param>
        /// <returns>Function</returns>
        /// <exception cref="AbpException">Throws exception if no function with given functionName</exception>
        public async Task<AbpFunction> GetFunctionByNameAsync(string functionName)
        {
            var function = await _functionRepository.FirstOrDefaultAsync(f => f.Name == functionName);
            if (function == null)
            {
                throw new AbpException("There is no function with name: " + functionName);
            }

            return function;
        }

        /// <summary>
        /// Gets a function by given name.
        /// Throws exception if no function with given functionName.
        /// </summary>
        /// <param name="functionName">Function name</param>
        /// <returns>Function</returns>
        /// <exception cref="AbpException">Throws exception if no function with given functionName</exception>
        public async Task<AbpFunction> GetFunctionByNameExistAsync(string functionName)
        {
            var function = await _functionRepository.FirstOrDefaultAsync(f => f.Name == functionName);
            return function;
        }

    }
}
