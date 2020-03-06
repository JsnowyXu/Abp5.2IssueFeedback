using Abp.Application.Navigation;
namespace Fun2RepairMVC.Web.Models.FLayout
{
    public class TopMenuViewModel
    {
        public UserMenu FrontMenu { get; set; }
        public string ActiveMenuItemName { get; set; }
    }
}