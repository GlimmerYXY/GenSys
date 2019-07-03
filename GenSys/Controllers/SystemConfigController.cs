using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenSys.MySQL;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class SystemConfigController : Controller
    {
        public JsonResult GetDevice()
        {
            
            gensysEntities gensysdb = new gensysEntities();
            var model = gensysdb.dev_dict.OrderBy(m => m.id).Select(m => new
            {
                id = m.id,
                DeviceType = m.type,
                Settable = m.settable,
                
            });
            if (model.Count() > 0)
            {

                ViewBag.database = model.First().id + model.First().DeviceType + model.First().Settable;
            }
            return Json(model.ToList(), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetPermission()
        {

            gensysEntities gensysdb = new gensysEntities();
            var model = gensysdb.dev_dict.OrderBy(m => m.id).Select(m => new
            {
                id = m.id,
                Position = m.type,
                AccessiblePage = m.settable,

            });
            if (model.Count() > 0)
            {

                ViewBag.database = model.First().id + model.First().Position + model.First().AccessiblePage;
            }
            return Json(model.ToList(), JsonRequestBehavior.AllowGet);

        }

        // GET: SysConfig
        public ActionResult Index()
        {
            return View();
        }
    }
}