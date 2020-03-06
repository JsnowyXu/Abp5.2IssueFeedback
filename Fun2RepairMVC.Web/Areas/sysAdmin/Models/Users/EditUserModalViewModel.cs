using System.Collections.Generic;
using System.Linq;
using Fun2RepairMVC.Roles.Dto;
using Fun2RepairMVC.Users.Dto;
namespace Fun2RepairMVC.Web.Areas.sysAdmin.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.Roles != null && User.Roles.Any(r => r == role.Name);
        }
    }
}