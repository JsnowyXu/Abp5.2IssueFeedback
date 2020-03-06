using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Fun2RepairMVC.Common.PublicCode;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fun2RepairMVC.FrontEnd.CMS
{
    public class FriendLinkManager : Fun2RepairMVCDomainService
    {
        private readonly IRepository<FriendLink> _friendLinkRepository;
        public FriendLinkManager(
        IRepository<FriendLink> friendLinkRepository)
        {
            _friendLinkRepository = friendLinkRepository;
        }
        //無語言限制全部參數
        public virtual IQueryable<FriendLink> FriendLinksAll
        {
            get { return _friendLinkRepository.GetAll(); }
        }

        public virtual IQueryable<BaseCodeCommonView> FriendLinksAllWithName(bool IsAddActive=true)
        {
           var query=from f in _friendLinkRepository.GetAll().WhereIf(IsAddActive,x=>x.IsActive==true)
                     orderby f.OrderNo
                     select new BaseCodeCommonView
                     { 
                          Id=f.Id,
                          Name = f.Name,
                          Code =f.TargetUrl,
                          Description=f.Kerwords,
                     };
            return query;
        }

        public virtual IQueryable<BaseCodeCommonView> FriendLinksAllWithNameByLan(string Lang)
        {
            var query = from f in _friendLinkRepository.GetAll()
                    
                        orderby f.OrderNo
                        select new BaseCodeCommonView
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Code = f.TargetUrl,
                            Description = f.Kerwords,
                        };
            return query;
        }
        public async Task CreateFriendLinkAsync(FriendLink link, string TextValue, string LanguageCode)
        {
          
            await _friendLinkRepository.InsertAsync(link);
        }
        public async Task<FriendLink> CreateFriendLinkAsync(FriendLink flinkInput, string TextValue, string LanguageCode, string text)
        {
            Guid Name = Guid.NewGuid();
          
            //判斷Name是否存在，如果存在則將原來的Name拷貝過來
            if (flinkInput.Id != 0)
            {
                var flink = _friendLinkRepository.Get(flinkInput.Id);
                flink.Name = flinkInput.Name;
                flink.IsActive = flinkInput.IsActive;
                flink.OrderNo = flinkInput.OrderNo;
                await _friendLinkRepository.UpdateAsync(flink);
                return await _friendLinkRepository.GetAsync(flinkInput.Id);
            }
            else
            {
            
                return await _friendLinkRepository.GetAsync(flinkInput.Id);
            }
        }
        public async Task<int> CreateFriendLinkLAsync(FriendLink flinkInput, string TextValue, string LanguageCode, string text)
        {
            //判斷Name是否存在，如果存在則將原來的Name拷貝過來
            if (flinkInput.Id != 0)
            {
                var flinks = _friendLinkRepository.Get(flinkInput.Id);

                flinks.Name = flinkInput.Name;
                flinks.IsActive = flinkInput.IsActive;
                flinks.OrderNo = flinkInput.OrderNo;
                flinks.TargetLogo = flinkInput.TargetLogo;
                flinks.TargetUrl = flinkInput.TargetUrl;
                flinks.LinkContact = flinkInput.LinkContact;
                flinks.Kerwords = flinkInput.Kerwords;
                //語言表中存在則進行更新，不存在則進行插入.基礎代碼更新。             
                await _friendLinkRepository.UpdateAsync(flinks);
                return flinkInput.Id;
            }
            else
            {
                await _friendLinkRepository.InsertAsync(flinkInput);
                await CurrentUnitOfWork.SaveChangesAsync();  
                return flinkInput.Id;
            }
        }
        public async Task UpdateFriendLinkAsync(FriendLink link)
        {
            await _friendLinkRepository.UpdateAsync(link);
        }
        public FriendLink GetFriendLinkById(int id)
        {
            return _friendLinkRepository.FirstOrDefault(
              query => query.Id == id
                     );
        }
        //刪除數據同時刪除語言表
        public async Task DeleteAsync(int id)
        {
            var link = await _friendLinkRepository.FirstOrDefaultAsync(id);
         
            await _friendLinkRepository.DeleteAsync(id);
        }
        //by Id獲取信息
        public async Task<FriendLink> GetFlinkById(int id)
        {
            var result = await _friendLinkRepository.FirstOrDefaultAsync(id);
            return result;
        }
    }
}