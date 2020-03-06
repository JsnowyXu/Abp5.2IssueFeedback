using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fun2RepairMVC.Web.Areas.sysAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: sysAdmin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}