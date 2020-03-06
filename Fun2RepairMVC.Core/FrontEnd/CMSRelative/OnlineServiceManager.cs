using Abp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    public class OthersManager : Fun2RepairMVCDomainService
    {
        private readonly IRepository<OnlineService> _onlineServiceRepository;

        public OthersManager(IRepository<OnlineService> onlineServiceRepository)
        {
            _onlineServiceRepository = onlineServiceRepository;
        }
        public virtual IQueryable<OnlineService> OnlineService
        {
            get { return _onlineServiceRepository.GetAll(); }
        }
        public OnlineService GetOnlineServiceById(int Id)
        {
            return _onlineServiceRepository.FirstOrDefault(Id);
        }
        public async Task CreatOrUpadateOnlineService(OnlineService input)
        {
            await _onlineServiceRepository.InsertOrUpdateAsync(input);
        }
        public async Task DeleteOnlineServiceById(int Id)
        {
            await _onlineServiceRepository.DeleteAsync(Id);
        }
    }
}
