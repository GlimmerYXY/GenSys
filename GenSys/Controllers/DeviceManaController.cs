using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class DeviceManaController : Controller
    {
        private gensysEntities db = new gensysEntities();

        // GET: DeviceManaController
        public ActionResult Index()
        {
            List<SelectListItem> siteList = new SelectList(db.site, "name", "name").ToList();
            siteList.Insert(0, new SelectListItem { Text = "请选择/输入站点", Value = "yxy", Selected = true, Disabled = true });
            ViewData["siteList"] = siteList;

            var dev_type = from device in db.device
                           select device.dev_type;
            List<SelectListItem> dev_typeList = new SelectList(dev_type, "dev_type", "dev_type").ToList();
            dev_typeList.Insert(0, new SelectListItem { Text = "请选择设备类型", Value = "yxy", Selected = true, Disabled = true });
            ViewData["dev_typeList"] = dev_typeList;

            var dev_model = from device in db.device
                           select device.dev_model;
            List<SelectListItem> dev_modelList = new SelectList(dev_model, "dev_model", "dev_model").ToList();
            dev_modelList.Insert(0, new SelectListItem { Text = "请选择设备类型", Value = "yxy", Selected = true, Disabled = true });
            ViewData["dev_modelList"] = dev_modelList;

            return View();
        }
        
        // POST: /DeviceMana/AddDevice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,model")] device device)
        {
            if (ModelState.IsValid)
            {
                db.device.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(device);
        }
        
    }
}