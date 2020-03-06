using Fun2RepairMVC.Configuration;
using Fun2RepairMVC.Web.Models.FLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fun2RepairMVC.Web.Controllers
{
    public class FLayoutController : Fun2RepairMVCControllerBase
    {
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// SEO標題
        /// </summary>
        /// <param name="activeMenu"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult Title(string activeMenu = "")
        {
            //讀取column的內容
            var DefaultName = SettingManager.GetSettingValue(AppSettingNames.WebSiteName);
            var DefaultTitle = SettingManager.GetSettingValue(AppSettingNames.WebSiteKeywords);
            var DefaultKeywords = SettingManager.GetSettingValue(AppSettingNames.WebSiteKeywords);
            var DefaultDescription = SettingManager.GetSettingValue(AppSettingNames.WebSiteDecription);
            var model = new TitleViewModel()
            {
                Title = DefaultTitle,
                KeyWords = DefaultKeywords,
                Description = DefaultDescription,
                Author = DefaultName
            };
            return PartialView("_SEOTitle", model);
        }
    }
}