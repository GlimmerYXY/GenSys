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
            var site = from device in db.device
                           select device.site;
            List<SelectListItem> siteList = new SelectList(site.Distinct()).ToList();
            siteList.Insert(0, new SelectListItem { Text = "请选择/输入站点", Selected = true, Disabled = true });
            ViewData["siteList"] = siteList;

            var dev_type = from device in db.device
                           select device.dev_type;
            List<SelectListItem> dev_typeList = new SelectList(dev_type.Distinct()).ToList();
            dev_typeList.Insert(0, new SelectListItem { Text = "请选择/输入设备类型",  Selected = true, Disabled = true });
            ViewData["dev_typeList"] = dev_typeList;

            var dev_model = from device in db.device
                            select device.dev_model;
            List<SelectListItem> dev_modelList = new SelectList(dev_model.Distinct()).ToList();
            dev_modelList.Insert(0, new SelectListItem { Text = "请选择/输入设备型号", Selected = true, Disabled = true });
            ViewData["dev_modelList"] = dev_modelList;
            
            ViewData["device"] = db.device.ToList();
            return View();
        }

        // POST: /DeviceMana/AddDevice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDevice([Bind(Include = "site, dev_type, dev_model, alias, ip, media_port, username, password")] device device)
        {
            if (ModelState.IsValid)
            {
                int count = db.device.Count();
                device.id = count + 1;
                db.device.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
        
    }
}