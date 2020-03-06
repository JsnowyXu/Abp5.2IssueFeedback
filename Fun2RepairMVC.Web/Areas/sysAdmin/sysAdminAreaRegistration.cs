using System.Web.Mvc;

namespace Fun2RepairMVC.Web.Areas.sysAdmin
{
    public class sysAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "sysAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "sysAdmin_default",
                "sysAdmin/{controller}/{action}/{id}",
                new { controller="Account", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}