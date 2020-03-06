using Abp.Authorization;
using Fun2RepairMVC.Authorization.Roles;
using Fun2RepairMVC.Authorization.Users;

namespace Fun2RepairMVC.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
