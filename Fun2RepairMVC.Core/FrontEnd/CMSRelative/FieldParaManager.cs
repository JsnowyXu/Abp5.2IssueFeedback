using Abp.Domain.Repositories;
using Fun2RepairMVC.Common.PublicCode;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    public class FieldParaManager : Fun2RepairMVCDomainService
    {
        #region 注入服務
        private readonly IRepository<Module> _moduleRepository;
        private readonly IRepository<ModuleTranslation> _moduleTranslationRepository;
        private readonly IRepository<CmsParameter, long> _cmsParameterRepository;
        private readonly IRepository<CmsOption, long> _cmsOptionRepository;
        private readonly IRepository<CmsParameterList, long> _cmsParameterListRepository;
        public FieldParaManager(
            IRepository<Module> moduleRepository,
            IRepository<CmsParameter, long> cmsParameterRepository,
            IRepository<CmsOption, long> cmsOptionRepository,
            IRepository<CmsParameterList, long> cmsParameterListRepository)
        {
            _moduleRepository = moduleRepository;
            _cmsParameterRepository = cmsParameterRepository;
            _cmsOptionRepository = cmsOptionRepository;
            _cmsParameterListRepository = cmsParameterListRepository;
        }
        #endregion
        
        public virtual IQueryable<CmsParameterList> GetCMSParaList
        {
            get { return _cmsParameterListRepository.GetAll(); }
        }
        public virtual IQueryable<CmsOption> GetFieldOptionAll
        {
            get { return _cmsOptionRepository.GetAll(); }
        }
        public IQueryable<BaseCodeCommonView> GetModule()
        {
            var result = from m in _moduleRepository.GetAll().Where(x => x.IsActive == true)
                         join t in _moduleTranslationRepository.GetAll().Where(x=>x.Language== CultureInfo.CurrentCulture.Name)
                         on m.Id equals t.CoreId
                         orderby m.Code
                         select new BaseCodeCommonView
                         {
                             Code = m.Code,
                             Description = m.Description,
                             Id = m.Id,
                             Name =t.Name
                         };
            return result;
        }
        

        #region 屬性的增刪改查
        public virtual IQueryable<CmsParameter> GetPropertyList
        {
            get { return _cmsParameterRepository.GetAll(); }
        }
        public async Task<CmsParameter> GetPropertyById(long Id)
        {
            return await _cmsParameterRepository.FirstOrDefaultAsync(Id);
        }
        public async Task CreateOrUpdateProperty(CmsParameter input)
        {
            await _cmsParameterRepository.InsertOrUpdateAsync(input);
        }
        
        //會員屬性刪除會同步刪除 option數據，包括option中的多語言
        public async Task DeletePropertyById(int Id)
        {
            
        }
        #endregion
    }
}
