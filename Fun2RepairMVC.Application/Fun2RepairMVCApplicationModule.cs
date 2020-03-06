using System.Linq;
using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Fun2RepairMVC.Authorization.Roles;
using Fun2RepairMVC.Authorization.Users;
using Fun2RepairMVC.Roles.Dto;
using Fun2RepairMVC.Users.Dto;
using Fun2RepairMVC.Common.AutoMapping;
using Abp.Configuration;

namespace Fun2RepairMVC
{
    [DependsOn(typeof(Fun2RepairMVCCoreModule), typeof(AbpAutoMapperModule))]
    public class Fun2RepairMVCApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
                    opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                CustomDtoMapper.CreateMappings(cfg, new MultiLingualMapContext(IocManager.Resolve<ISettingManager>()));
            });
        }
    }
}
