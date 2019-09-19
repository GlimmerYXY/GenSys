using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;
using Newtonsoft.Json;

namespace GenSys.Controllers
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
            siteList.Insert(0, new SelectListItem { Text = "站点", Selected = true, Disabled = true });
            ViewData["siteList"] = siteList;

            var dev_type = from dev_dict in db.dev_dict
                           select dev_dict.type;
            List<SelectListItem> dev_typeList = new SelectList(dev_type.Distinct()).ToList();
            dev_typeList.Insert(0, new SelectListItem { Text = "设备类型",  Selected = true, Disabled = true });
            ViewData["dev_typeList"] = dev_typeList;

            var dev_model = from device in db.device
                            select device.dev_model;
            List<SelectListItem> dev_modelList = new SelectList(dev_model.Distinct()).ToList();
            dev_modelList.Insert(0, new SelectListItem { Text = "设备型号", Selected = true, Disabled = true });
            ViewData["dev_modelList"] = dev_modelList;
            
            //ViewData["device"] = JsonConvert.SerializeObject(db.device.ToList());
            return View();
        }

        // POST: DeviceMana/AddDevice
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDevice(device device)    //[Bind(Include = "alias, site, dev_type, dev_model, uuid, rtsp_url, account, password")
        {
            if (ModelState.IsValid)
            {
                //添加到device
                int count = db.device.Count();
                //device.id = count + 1;
                db.device.Add(device);
                //db.SaveChanges();

                //添加到ipcam
                ipcam cam = new ipcam();
                cam.algo_h = 111;
                cam.uuid = device.uuid;
                cam.rtspurl = device.rtsp_url;
                cam.rtsp_account = device.account;
                cam.rtsp_passwd = device.password;
                db.ipcam.Add(cam);
                db.SaveChanges();

                GenboxHelper.ipcam_setup_set(db);
            }
            return RedirectToAction("Index");//return Redirect("index");//return Json("fsdfds");// return JavaScript("location.reload()");
        }

        // POST: DeviceMana/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            device device = db.device.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            db.device.Remove(device);

            ipcam ipcam = db.ipcam.Find(id);
            if (ipcam == null)
            {
                return HttpNotFound();
            }
            db.ipcam.Remove(ipcam);

            db.SaveChanges();

            GenboxHelper.ipcam_setup_set(db);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetData()
        {
            return Json(db.device.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}