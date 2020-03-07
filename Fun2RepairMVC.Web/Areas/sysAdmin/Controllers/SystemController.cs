using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.Web.Mvc.Authorization;
using Fun2RepairMVC.Authorization;
using Fun2RepairMVC.Authorization.Roles;
using Fun2RepairMVC.MultiTenancy;
using Fun2RepairMVC.Roles;
using Fun2RepairMVC.Users;
using Fun2RepairMVC.Web.Areas.sysAdmin.Models.Roles;
using Fun2RepairMVC.Web.Areas.sysAdmin.Models.Users;

namespace Fun2RepairMVC.Web.Areas.sysAdmin.Controllers
{
    public class SystemController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;
        private readonly IRoleAppService _roleAppService;
        private readonly ITenantAppService _tenantAppService;
        public SystemController(
            IUserAppService userAppService,
            RoleManager roleManager,
            IRoleAppService roleAppService,
            ITenantAppService tenantAppService)
        {
            _userAppService = userAppService;
            _roleManager = roleManager;
            _roleAppService = roleAppService;
            _tenantAppService = tenantAppService;
        }
        // GET: sysAdmin/System
        public ActionResult Index()
        {
            return View();
        }

        #region user management     
        [AbpMvcAuthorize(PermissionNames.System_Tenants)]
        public async Task<ActionResult> Users()
        {
            var users = (await _userAppService.GetAllAsync(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items; //Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };
            return View("UserIndex",model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
        #endregion

        #region role management
        [AbpMvcAuthorize(PermissionNames.System_Tenants)]
        public async Task<ActionResult> Roles()
        {
            var roles = (await _roleAppService.GetAllAsync(new PagedAndSortedResultRequestDto())).Items;
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new RoleListViewModel
            {
                Roles = roles,
                Permissions = permissions
            };

            return View("RoleIndex",model);
        }

        public async Task<ActionResult> EditRoleModal(int roleId)
        {
            var role = await _roleAppService.GetAsync(new EntityDto(roleId));
            var permissions = (await _roleAppService.GetAllPermissions()).Items;
            var model = new EditRoleModalViewModel
            {
                Role = role,
                Permissions = permissions
            };
            return View("_EditRoleModal", model);
        }
        #endregion

        #region tenant Management
        [AbpMvcAuthorize(PermissionNames.System_Tenants)]
        public async Task<ActionResult> Tenants()
        {
            var output = await _tenantAppService.GetAllAsync(new PagedResultRequestDto { MaxResultCount = int.MaxValue }); //Paging not implemented yet
            return View("TenantIndex",output);
        }

        public async Task<ActionResult> EditTenantModal(int tenantId)
        {
            var tenantDto = await _tenantAppService.GetAsync(new EntityDto(tenantId));
            return View("_EditTenantModal", tenantDto);
        }
        #endregion
    }
}