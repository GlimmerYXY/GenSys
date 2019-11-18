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
            List<string> siteList1 = new List<string>(site.Distinct()).ToList();
            siteList1.Insert(0, "站点");
            ViewBag.sitename = siteList1;

            var dev_type = from dev_dict in db.dev_dict
                           select dev_dict.type;
            List<SelectListItem> dev_typeList = new SelectList(dev_type.Distinct()).ToList();
            dev_typeList.Insert(0, new SelectListItem { Text = "设备类型", Selected = true, Disabled = true });
            ViewData["dev_typeList"] = dev_typeList;
            List<string> dev_typeList1 = new List<string>(dev_type.Distinct()).ToList();
            dev_typeList1.Insert(0, "设备类型");
            ViewBag.devname = dev_typeList1;

            var dev_model = from device in db.device
                            select device.dev_model;
            List<SelectListItem> dev_modelList = new SelectList(dev_model.Distinct()).ToList();
            dev_modelList.Insert(0, new SelectListItem { Text = "设备型号", Selected = true, Disabled = true });
            ViewData["dev_modelList"] = dev_modelList;
            List<string> dev_modelList1 = new List<string>(dev_model.Distinct()).ToList();
            dev_modelList1.Insert(0, "设备型号");
            ViewBag.devmodelname = dev_modelList1;


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
                if (device.uuid == null)
                {
                    var script = string.Format("<script>alert('识别编号未填写！');location.href='{0}'</script>", Url.Action("Index", "DeviceMana"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }
                else {
                    var distinctdev = (from d in db.device
                                         where d.uuid == device.uuid
                                         select d);
                    if (distinctdev.Count() != 0)
                    {
                        var script = string.Format("<script>alert('识别编号重复！');location.href='{0}'</script>", Url.Action("Index", "DeviceMana"));
                        //Url.Action()用于指定跳转的路径             
                        return Content(script, "text/html");
                    }
                    else
                    {
                        //添加到device
                        int count = db.device.Count();
                        //device.id = count + 1;
                        db.device.Add(device);

                        if (device.dev_type != "GenBox" && device.dev_type != "声波盾")
                        {
                            AddIpcam(device.uuid, device.rtsp_url, device.account, device.password);
                        }
                        db.SaveChanges();
                        //GenboxHelper.ipcam_setup_set(db);
                    }
                }
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
            cam.ebd_cpu = 0;
            cam.fsd_cpu = 0;
            cam.opa4t_cpu = 0;
            cam.pfr_cpu = 0;
            cam.ssc_cpu = 0;
            cam.wca_cpu = 0;

            db.ipcam.Add(cam);
            //db.SaveChanges();
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

                //GenboxHelper.ipcam_setup_set(db);
            }
            return RedirectToAction("Index");//return Redirect("index");//return Json("fsdfds");// return JavaScript("location.reload()");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateGB(FormCollection formcollection, device device)    //[Bind(Include = "alias, site, dev_type, dev_model, uuid, rtsp_url, account, password")
        {
            gensysEntities gensysdb = new gensysEntities();
            if (ModelState.IsValid)
            {

                device device_old = gensysdb.device.Find(device.uuid);
                if (device == null)
                {
                    return HttpNotFound();
                }
                gensysdb.device.Remove(device_old);
                gensysdb.device.Add(device);

            }

            string camuuid1 = formcollection["cam_uuid1"];
            string algo1 = formcollection["algo1"];
            string cpunum1 = formcollection["cpu_num1"];

            string camuuid2 = formcollection["cam_uuid2"];
            string algo2 = formcollection["algo2"];
            string cpunum2 = formcollection["cpu_num2"];

            string camuuid3 = formcollection["cam_uuid3"];
            string algo3 = formcollection["algo3"];
            string cpunum3 = formcollection["cpu_num3"];

            device availableuuid1 = gensysdb.device.Find(camuuid1);
            device availableuuid2 = gensysdb.device.Find(camuuid2);
            device availableuuid3 = gensysdb.device.Find(camuuid3);

            ipcam cam1, cam2, cam3;
            //判断，如果三个输入的uuid不是空，且查询device表，不存在这个uuid或者不是ipcam的话就不添加
            if (camuuid1 != "" && (availableuuid1 == null || availableuuid1.dev_type == "GenBox" || availableuuid1.dev_type == "声波盾")
                || camuuid2 != "" && (availableuuid2 == null || availableuuid2.dev_type == "GenBox" || availableuuid2.dev_type == "声波盾")
                || camuuid3 != "" && (availableuuid3 == null || availableuuid3.dev_type == "GenBox" || availableuuid3.dev_type == "声波盾"))
            {
                var script = string.Format("<script>alert('添加的uuid有问题，请检查后重新输入！');location.href='{0}'</script>", Url.Action("Index", "DeviceMana"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }
            else
            {
                if (camuuid1 != "" && cpunum1 != "")
                {
                    genbox_cpu add1 = new genbox_cpu();
                    add1.ipcam_uuid = camuuid1;
                    add1.genbox_uuid = device.uuid;
                    add1.algo_value = algo1;
                    add1.cpu_num = cpunum1;
                    gensysdb.genbox_cpu.Add(add1);

                    cam1 = gensysdb.ipcam.Find(camuuid1);   //要和数据库字段的类型一致
                    if (cam1 == null)
                    {
                        return HttpNotFound();
                    }
                    switch (algo1)
                    {
                        case "ebd":
                            cam1.ebd_cpu = int.Parse(cpunum1); break;
                        case "fsd":
                            cam1.fsd_cpu = int.Parse(cpunum1); break;
                        case "opa4t":
                            cam1.opa4t_cpu = int.Parse(cpunum1); break;
                        case "pfr":
                            cam1.pfr_cpu = int.Parse(cpunum1); break;
                        case "ssc":
                            cam1.ssc_cpu = int.Parse(cpunum1); break;
                        case "wca":
                            cam1.wca_cpu = int.Parse(cpunum1); break;
                    }
                    gensysdb.Entry(cam1).State = System.Data.Entity.EntityState.Modified;
                    gensysdb.SaveChanges();
                }
                else if (camuuid1 == "" && cpunum1 == "") { }
                else
                {
                    var script = string.Format("<script>alert('有表格项未填写完整！');location.href='{0}'</script>", Url.Action("Index", "DeviceMana"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }
                if (camuuid2 != "" && cpunum2 != "")
                {
                    genbox_cpu add2 = new genbox_cpu();
                    add2.ipcam_uuid = camuuid2;
                    add2.genbox_uuid = device.uuid;
                    add2.algo_value = algo2;
                    add2.cpu_num = cpunum2;
                    gensysdb.genbox_cpu.Add(add2);

                    cam2 = gensysdb.ipcam.Find(camuuid2);   //要和数据库字段的类型一致
                    if (cam2 == null)
                    {
                        return HttpNotFound();
                    }
                    switch (algo2)
                    {
                        case "ebd":
                            cam2.ebd_cpu = int.Parse(cpunum2); break;
                        case "fsd":
                            cam2.fsd_cpu = int.Parse(cpunum2); break;
                        case "opa4t":
                            cam2.opa4t_cpu = int.Parse(cpunum2); break;
                        case "pfr":
                            cam2.pfr_cpu = int.Parse(cpunum2); break;
                        case "ssc":
                            cam2.ssc_cpu = int.Parse(cpunum2); break;
                        case "wca":
                            cam2.wca_cpu = int.Parse(cpunum2); break;
                    }
                    //gensysdb.Entry(cam2).State = System.Data.Entity.EntityState.Modified;
                    gensysdb.SaveChanges();
                }
                else if (camuuid2 == "" && cpunum2 == "") { }
                else
                {
                    var script = string.Format("<script>alert('有表格项未填写完整！');location.href='{0}'</script>", Url.Action("Index", "DeviceMana"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }
                if (camuuid3 != "" && cpunum3 != "")
                {
                    genbox_cpu add3 = new genbox_cpu();
                    add3.ipcam_uuid = camuuid3;
                    add3.genbox_uuid = device.uuid;
                    add3.algo_value = algo3;
                    add3.cpu_num = cpunum3;
                    gensysdb.genbox_cpu.Add(add3);

                    cam3 = gensysdb.ipcam.Find(camuuid3);   //要和数据库字段的类型一致
                    if (cam3 == null)
                    {
                        return HttpNotFound();
                    }
                    switch (algo3)
                    {
                        case "ebd":
                            cam3.ebd_cpu = int.Parse(cpunum3); break;
                        case "fsd":
                            cam3.fsd_cpu = int.Parse(cpunum3);break;
                        case "opa4t":
                            cam3.opa4t_cpu = int.Parse(cpunum3); break;
                        case "pfr":
                            cam3.pfr_cpu = int.Parse(cpunum3); break;
                        case "ssc":
                            cam3.ssc_cpu = int.Parse(cpunum3); break;
                        case "wca":
                            cam3.wca_cpu = int.Parse(cpunum3); break;
                    }
                    //gensysdb.Entry(cam3).State = System.Data.Entity.EntityState.Modified;
                    gensysdb.SaveChanges();
                }
                else if (camuuid3 == "" && cpunum3 == "") { }
                else
                {
                    var script = string.Format("<script>alert('有表格项未填写完整！');location.href='{0}'</script>", Url.Action("Index", "DeviceMana"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }
            }
            gensysdb.SaveChanges();
            
            GenboxHelper.ipcam_setup_set(db, device);

            return RedirectToAction("Index");//return Redirect("index");//return Json("fsdfds");// return JavaScript("location.reload()");
        }

        [HttpPost]
        public ActionResult Delete(string id,string type)   
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

            if(type=="HIK IPC")
            {
                ipcam ipcam = db.ipcam.Find(id);
                if (ipcam == null)
                {
                    return HttpNotFound();
                }
                db.ipcam.Remove(ipcam);
            }
            else if (type == "GenBox")
            {
                var sql = @"delete from genbox_cpu WHERE genbox_uuid = @Id";

                db.Database.ExecuteSqlCommand(
                    sql,

                    new MySqlParameter("@Id", id));
            }

            db.SaveChanges();

            //GenboxHelper.ipcam_setup_set(db);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete_tbcpu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var sql = @"delete from genbox_cpu WHERE genbox_uuid = @Id";

            db.Database.ExecuteSqlCommand(
                sql,

                new MySqlParameter("@Id", id));
            
            db.SaveChanges();

            //GenboxHelper.ipcam_setup_set(db);

            return RedirectToAction("Index");
        }

        public JsonResult GenboxDetail(string id)
        {
            var detailquery = (from t in db.genbox_cpu
                               where t.genbox_uuid == id
                               select /*t.ipcam_uuid + t.algo_value + t.cpu_num*/
                               new
                               {
                                   a = t.ipcam_uuid,
                                   b = t.algo_value,
                                   c = t.cpu_num
                               }).ToList();

            return Json(detailquery.ToJson(), JsonRequestBehavior.AllowGet);
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