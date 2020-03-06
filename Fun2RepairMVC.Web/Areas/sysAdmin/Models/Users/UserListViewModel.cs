using System.Collections.Generic;
using Fun2RepairMVC.Roles.Dto;
using Fun2RepairMVC.Users.Dto;

namespace Fun2RepairMVC.Web.Areas.sysAdmin.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}