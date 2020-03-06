using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS
{
   public class BannerManger : Fun2RepairMVCDomainService
    {
        #region 注入
        private readonly IRepository<Banner> _bannerRepository;
        private readonly IRepository<ColumnBanner> _columnBannerReposity;

        public BannerManger(
            IRepository<Banner> bannerRepository,
            IRepository<ColumnBanner> columnBannerReposity
            )
        {
            _bannerRepository = bannerRepository;
            _columnBannerReposity = columnBannerReposity;
        }
        #endregion
        public virtual IQueryable<Banner> BannerAll
        {
            get { return _bannerRepository.GetAll(); }
        }
        public async Task CreateOrUpdateBannerAsync(Banner banner)
        {
            await _bannerRepository.InsertOrUpdateAndGetIdAsync(banner);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }
        public async Task DeleteBannerAsync(int id)
        {
            await _bannerRepository.DeleteAsync(id);
        }
        public  Banner  GetBannerById(int id)
        {
            var result =  _bannerRepository.FirstOrDefault(id);
            return result;
        }
        public virtual IQueryable<ColumnBanner> ColumnBannerAll
        {
            get { return _columnBannerReposity.GetAll(); }
        }
        public async Task CreateOrUpdateBannerListAsync(List<int> bannerList,int bannerId)
        {
            await _columnBannerReposity.DeleteAsync(x => x.BannerId == bannerId);
            foreach(var c in bannerList)
            {
                var bannerColumn = new ColumnBanner();
                bannerColumn.BannerId = bannerId;
                bannerColumn.ColumnId = c;
               await _columnBannerReposity.InsertOrUpdateAsync(bannerColumn);
            }
        }
    }
}
