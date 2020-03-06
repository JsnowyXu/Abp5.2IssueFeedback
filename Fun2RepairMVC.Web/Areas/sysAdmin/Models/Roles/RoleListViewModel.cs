using System.Collections.Generic;
using Fun2RepairMVC.Roles.Dto;

namespace Fun2RepairMVC.Web.Areas.sysAdmin.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}