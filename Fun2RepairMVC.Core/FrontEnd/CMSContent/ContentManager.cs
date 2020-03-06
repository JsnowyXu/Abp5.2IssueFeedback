using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    public class ContentManager: Fun2RepairMVCDomainService
    {
        #region 注入
        private readonly IRepository<Article, long> _articleRepository;
        private readonly IRepository<Module> _moduleRepository;
        private readonly IRepository<ModuleTranslation> _moduleTranslationRepository;
        private readonly IRepository<CmsParameter, long> _cmsParameterRepository;
        private readonly IRepository<CmsOption, long> _cmsOptionRepository;
        private readonly IRepository<CmsParameterList, long> _cmsParameterListRepository;
        public ContentManager(
        IRepository<Module> moduleRepository,
        IRepository<Article, long> articleRepository,
        IRepository<Column> columnRepository,
            IRepository<CmsParameter, long> cmsParameterRepository,
            IRepository<CmsOption, long> cmsOptionRepository,
            IRepository<CmsParameterList, long> cmsParameterListRepository)
        {

            _articleRepository = articleRepository;
            _cmsParameterRepository = cmsParameterRepository;
            _cmsOptionRepository = cmsOptionRepository;
            _cmsParameterListRepository = cmsParameterListRepository;
        }
        #endregion

        #region 內容管理
        //獲取文章內容list
        public virtual IQueryable<Article> ArticleAll
        {
            get { return _articleRepository.GetAll(); }
        }
        public async Task CreateOrUpdateArticleAsync(Article article)
        {
            await _articleRepository.InsertOrUpdateAndGetIdAsync(article);
        }
        public void  BatchUpdateArticle(Article article)
        {
              _articleRepository.Update(article);
        }
        public async Task<Article> GetArticleById(long id)
        {
            var result = await _articleRepository.FirstOrDefaultAsync(id);
            return result;
        }
        public async Task DeleteArticleAsync(long id)
        {
            await _articleRepository.DeleteAsync(id);
        }
        public void  DeleteArticle(long id)
        {
              _articleRepository.Delete(id);
        }
        #endregion
    }
}
