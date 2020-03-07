using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;
using Abp.UI;
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
    public class AdminController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly RoleManager _roleManager;
        private readonly IRoleAppService _roleAppService;
        private readonly ITenantAppService _tenantAppService;
        public AdminController(
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

    }
}