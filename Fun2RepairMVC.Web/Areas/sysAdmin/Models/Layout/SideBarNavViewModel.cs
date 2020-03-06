using Abp.Application.Navigation;

namespace Fun2RepairMVC.Web.Areas.sysAdmin.Models.Layout
{
    public class SideBarNavViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemName { get; set; }
    }
}