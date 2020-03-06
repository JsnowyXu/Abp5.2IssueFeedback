using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.Users;

namespace Fun2RepairMVC.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
