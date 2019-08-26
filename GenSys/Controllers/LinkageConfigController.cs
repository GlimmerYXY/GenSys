using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenSys.Controllers
{
    public class LinkageConfigController : Controller
    {
        // GET: LinkageConfig
        public ActionResult Index()
        {
            //var site = from device in db.device
            //           select device.site;
            //List<SelectListItem> siteList = new SelectList(site.Distinct()).ToList();
            List<SelectListItem> siteList = new List<SelectListItem>();
            //siteList.Insert(0, new SelectListItem { Text = "请选择", Selected = true, Disabled = true });
            siteList.Insert(0, new SelectListItem { Text = "开门" });
            siteList.Insert(1, new SelectListItem { Text = "关门" });
            ViewData["event"] = siteList;

            return View();
        }

        public ActionResult Generate(FormCollection collection)
        {
            var Mon = collection["Mon"];
            var Tues = collection["Tues"];
            var Wed = collection["Wed"];
            var Thur = collection["Thur"];
            var Fri = collection["Fri"];
            var Sat = collection["Sat"];
            var Sun = collection["Sun"];

            //var Mon = collection["Mon"];
            //var Mon = collection["Mon"];
            //var Mon = collection["Mon"];
            
            return RedirectToAction("Index");
        }
    }
}