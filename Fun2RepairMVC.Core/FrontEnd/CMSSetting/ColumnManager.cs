using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Fun2RepairMVC.Common.PublicCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    public class ColumnManager: Fun2RepairMVCDomainService
    {

        #region 注入
        private readonly IRepository<Module> _moduleRepository;
        private readonly IRepository<Column> _columnRepository;
        private readonly IRepository<ColumnBanner> _columnBannerRepository;
        private readonly ParametersManager _parametersManager;
        public ColumnManager(
        IRepository<Module> moduleRepository,
        IRepository<Column> columnRepository, 
        ParametersManager parametersManager,
        IRepository<ColumnBanner> columnBannerRepository)
        {
            _moduleRepository = moduleRepository;
            _columnRepository = columnRepository;
            _parametersManager = parametersManager;
            _columnBannerRepository = columnBannerRepository;
    }
        #endregion
        #region 後台

        #region 模塊管理
        //無語言限制全部參數
        public virtual IQueryable<Module> ModulesAll
        {
            get { return _moduleRepository.GetAll(); }
        }
        #endregion

        #region 欄目管理
        public virtual IQueryable<Column> ColumnAll
        {
            get { return _columnRepository.GetAll(); }
        }
        public async Task CreateOrUpdateColumnAsync(Column columnd)
        {
            await _columnRepository.InsertOrUpdateAndGetIdAsync(columnd);
        }
        public async Task<Column> GetColumnById(int id)
        {
            var result = await _columnRepository.FirstOrDefaultAsync(id);
            return result;
        }
        //刪除欄目信息
        public async Task DeleteColumnAsync(int id)
        {
            await _columnRepository.DeleteAsync(id);
        }
        #endregion

        #endregion

        #region 前台
        /// <summary>
        /// 獲取有效的可見的菜單列表
        /// </summary>
        /// <returns></returns>
        public virtual List<Column> GetFrontMenus()
        {
            //獲取在頂部導航展示且為可見的菜單
            return _columnRepository.Query(
                q => q.Where(f => f.IsDisplay&& f.IsActive).Where(f => f.ShowType.Code == "0" || f.ShowType.Code == "2")
                    .OrderBy(f => f.OrderNo)
                    .ToList()
                );
        }
        /// <summary>
        /// 获取指定一级菜单下的在底部显示的子菜单
        /// </summary>
        /// <param name="bigClassId">一级菜单</param>
        /// <returns></returns>
        public virtual IQueryable<Column> GetFrontFooterMenus(int bigClassId)
        {
            //獲取在頂部導航展示且為可見的菜單
            return _columnRepository.Query(
                q => q.Where(f => f.IsDisplay && f.IsActive).Where(f => f.ShowType.Code == "1" || f.ShowType.Code == "2").Where(f=>f.BigClassId== bigClassId)
                    .OrderBy(f => f.OrderNo)
                );
        }
        public virtual IQueryable<ColumnBanner> GetBannerInfoForColumn(int id)
        {
          return  _columnBannerRepository.GetAll().Where(x => x.ColumnId == id);
        }

        public virtual IQueryable<ColumnBanner> GetBannerInfoForColumn(string columnName)
        {
            return _columnBannerRepository.GetAll().Where(x => x.Column.Name == columnName);
        }
        public virtual Column GetColumnByName(string columnName)
        {
            return _columnRepository.FirstOrDefault(x => x.Name == columnName);
        }

        #endregion
    }
}
