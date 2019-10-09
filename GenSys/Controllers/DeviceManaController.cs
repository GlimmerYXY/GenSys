using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;
using MySql.Data.MySqlClient;
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

                AddIpcam(device.uuid, device.rtsp_url, device.account, device.password);
                GenboxHelper.ipcam_setup_set(db);
            }
            return RedirectToAction("Index");//return Redirect("index");//return Json("fsdfds");// return JavaScript("location.reload()");
        }
       
        public void AddIpcam(string uuid, string rtspurl, string rtspaccount, string rtsppasswd)
        {
            //添加到ipcam
            ipcam cam = new ipcam();
            cam.algo_h = 240;
            cam.algo_w = 320;
            cam.alias_name = "";
            cam.ebd_ebikeThre = 0.5;
            cam.ebd_enable = 0;
            cam.ebd_fps = 2;
            cam.ebd_fri = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ebd_mon = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ebd_personThre = 0.5;
            cam.ebd_sat = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ebd_sun = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ebd_trigmodel = 2;
            cam.ebd_tue = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ebd_tur = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ebd_wed = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_enable = 0;
            cam.fsd_fps = 2;
            cam.fsd_fri = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_mon = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_sat = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_sun = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_tue = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_tur = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.fsd_wed = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.manual = 1;
            cam.opa4t_enable = 0;
            cam.opa4t_fps = 2;
            cam.opa4t_fri = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.opa4t_mon = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.opa4t_roi0_enable = 0;
            cam.opa4t_roi0_id = 0;
            cam.opa4t_roi0_pt0_x = 1;
            cam.opa4t_roi0_pt0_y = 1;
            cam.opa4t_roi0_pt1_x = 319;
            cam.opa4t_roi0_pt1_y = 1;
            cam.opa4t_roi0_pt2_x = 319;
            cam.opa4t_roi0_pt2_y = 239;
            cam.opa4t_roi0_pt3_x = 1;
            cam.opa4t_roi0_pt3_y = 239;
            cam.opa4t_roi0_ptnum = 4;
            cam.opa4t_roi0_sensitivity = -1;
            cam.opa4t_roi_num = 1;
            cam.opa4t_sat = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.opa4t_sun = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.opa4t_trigmodel = 2;
            cam.opa4t_tue = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.opa4t_tur = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.opa4t_wed = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_enable = 0;
            cam.pfr_fps = 2;
            cam.pfr_fri = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_mon = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_sat = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_sun = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_tue = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_tur = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.pfr_wed = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.post_alarm = 15;
            cam.pre_alarm = 15;
            cam.rtspurl = rtspurl;
            cam.rtsp_account = rtspaccount;
            cam.rtsp_passwd = rtsppasswd;
            cam.ssc_abnormalthr = 0.69999999999999996;
            cam.ssc_enable = 0;
            cam.ssc_fps = 2;
            cam.ssc_fri = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ssc_mon = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ssc_roi0_enable = 0;
            cam.ssc_roi0_pt0_x = 1;
            cam.ssc_roi0_pt0_y = 1;
            cam.ssc_roi0_pt1_x = 319;
            cam.ssc_roi0_pt1_y = 1;
            cam.ssc_roi0_pt2_x = 319;
            cam.ssc_roi0_pt2_y = 239;
            cam.ssc_roi0_pt3_x = 1;
            cam.ssc_roi0_pt3_y = 239;
            cam.ssc_roi0_ptnum = 4;
            cam.ssc_roi_num = 1;
            cam.ssc_sat = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ssc_sun = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ssc_tue = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ssc_tur = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.ssc_wed = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.uuid = uuid;
            cam.wca_enable = 0;
            cam.wca_fps = 1 ;
            cam.wca_fri = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.wca_mon = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.wca_sat = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.wca_sun = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.wca_tue = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.wca_tur = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.wca_wed = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
            cam.whitelist = 1;

            db.ipcam.Add(cam);
            db.SaveChanges();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDev(device device)    //[Bind(Include = "alias, site, dev_type, dev_model, uuid, rtsp_url, account, password")
        {
            if (ModelState.IsValid)
            {
                device device_old = db.device.Find(device.uuid);
                if (device == null)
                {
                    return HttpNotFound();
                }
                db.device.Remove(device_old);
                db.device.Add(device);

                if(device.account != device_old.account || device.password != device_old.password || device.rtsp_url != device_old.rtsp_url)
                {
                    var sql = @"update ipcam set rtsp_account='" + device.account + "', rtsp_passwd='"+ device.password + "', rtspurl='"+ device.rtsp_url + "' where uuid='"+device.uuid+"';";
                    db.Database.ExecuteSqlCommand(sql);
                }
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