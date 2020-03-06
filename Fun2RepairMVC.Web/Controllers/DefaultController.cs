using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fun2RepairMVC.Web.Controllers
{
    public class DefaultController : Fun2RepairMVCControllerBase
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}