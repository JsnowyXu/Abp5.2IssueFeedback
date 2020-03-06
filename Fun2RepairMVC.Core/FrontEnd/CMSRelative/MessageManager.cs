using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Fun2RepairMVC;
using Fun2RepairMVC.FrontEnd.CMS;
using Fun2RepairMVC.Common.PublicCode;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.Others
{
    public class MessageManager : Fun2RepairMVCDomainService
    {
        private readonly IRepository<Message, long> _messageServiceRepository;
        private readonly ParametersManager _parametersManager;
        public MessageManager(
            IRepository<Message, long> messageServiceRepository,
            ParametersManager parametersManager
            )
        {
            _messageServiceRepository = messageServiceRepository;
            _parametersManager = parametersManager;
        }
        public virtual IQueryable<Message> MessageGetAll
        {
            get { return _messageServiceRepository.GetAll(); }
        }
        public Message GetMessageById(long Id)
        {
            return _messageServiceRepository.FirstOrDefault(Id);
        }
        public async Task CreatOrUpadateMessage(Message input)
        {
            await _messageServiceRepository.InsertOrUpdateAsync(input);
        }
        public async Task DeleteMessageById(int Id)
        {
            await _messageServiceRepository.DeleteAsync(Id);
        }

 
    }
}
