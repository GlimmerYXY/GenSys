using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class DeviceManaController : Controller
    {
        // GET: DeviceManaController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSite()
        {

            return Json(null);
        }
    }
}