using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Localization;
using System.Threading.Tasks;

namespace Fun2RepairMVC.Common.Extras
{
  public  class TemplateManager : DomainService
    {
        private readonly IRepository<MailTemplate, int> _mailTemplateRepository;
        private readonly IRepository<ApplicationLanguage, int> _languagesRepository;
        private readonly IRepository<SMSTemplate, int> _smsTemplaterepository;
        private readonly IApplicationLanguageManager _applicationLanguageManager;
        private readonly IRepository<MailLog, long> _mailLogRepository; 
        private readonly IRepository<SMSLog, long>  _smsLogRepository;
        public TemplateManager(
            IRepository<MailTemplate, int> mailTemplateRepository,
            IRepository<ApplicationLanguage, int> languagesRepository,
            IRepository<SMSTemplate, int> smsTemplaterepository,
            IApplicationLanguageManager applicationLanguageManager,
            IRepository<MailLog, long> mailLogRepository,
            IRepository<SMSLog, long> smsLogRepository
            )
        {
            _mailTemplateRepository = mailTemplateRepository;
            _languagesRepository = languagesRepository;
            _smsTemplaterepository = smsTemplaterepository;
            _applicationLanguageManager = applicationLanguageManager;
            _mailLogRepository = mailLogRepository;
            _smsLogRepository = smsLogRepository;
        }

        public virtual IQueryable<MailTemplate> MailTemplates
        {
            get { return _mailTemplateRepository.GetAll(); }
        }

        public virtual IQueryable<SMSTemplate> SmsTemplates
        {
            get { return _smsTemplaterepository.GetAll(); }
        }
        public virtual IQueryable<MailLog> MailLogs
        {
            get { return _mailLogRepository.GetAll(); }
        }
        public virtual IQueryable<SMSLog> SMSLogs
        {
            get { return _smsLogRepository.GetAll(); }
        }
        public virtual IQueryable<ApplicationLanguage> Languageges
        {
            get { return _languagesRepository.GetAll(); }
        }

        public SMSTemplate GetSMSById(int id)
        {
            return _smsTemplaterepository.FirstOrDefault(x => x.Id == id);
        }
        public MailTemplate  GetMailById(int id)
        {
            return _mailTemplateRepository.FirstOrDefault(x => x.Id == id);
        }
        public async Task InsertOrUpdateEmail(MailTemplate input)
        {
            await _mailTemplateRepository.InsertOrUpdateAsync(input);
        }
        /// <summary>
        /// 獲取當前語言ID
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetLanguageByName(string langName)
        {
            var info = (await _applicationLanguageManager.GetLanguagesAsync(null)).FirstOrDefault(l => l.Name == langName);
            return info.Id;
        }
        public void InsertEmailLog(MailLog input)
        {
             _mailLogRepository.Insert(input);
        }
        public void InsertSMSLog(SMSLog input)
        {
            _smsLogRepository.Insert(input);
        }
    }
}
