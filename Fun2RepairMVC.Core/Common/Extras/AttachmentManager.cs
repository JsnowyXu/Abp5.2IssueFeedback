
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.Common.Extras
{
    public class AttachmentManager : DomainService
    {
        private readonly IRepository<Attachment, long> _attachmentRepository;
        public AttachmentManager(IRepository<Attachment, long> attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }
        public virtual async Task CreateAsync(Attachment files)
        {
            await _attachmentRepository.InsertAsync(files);
        }
        public virtual async Task UpdateAttachAsync(Attachment files)
        {
            await _attachmentRepository.UpdateAsync(files);
        }
        public virtual async Task DeleteAsync(Attachment files)
        {
            await _attachmentRepository.DeleteAsync(files);
        }
        public IQueryable<Attachment> GetAttachListByFileId(long fileId)
        {
            return _attachmentRepository.Query(
                query => from p in query
                         where p.Id == fileId
                         select p
                       );
        }
        public virtual IQueryable<Attachment> GetAllAttachement
        {
            get { return _attachmentRepository.GetAll(); }
        }
        public async Task<Attachment> GetAttachmentById(long Id)
        {
          return await _attachmentRepository.FirstOrDefaultAsync(Id);
        }
    }
}
