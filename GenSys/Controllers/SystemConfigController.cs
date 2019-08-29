using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GenSys.Models;
using System.Threading;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class SystemConfigController : Controller
    {

        public JsonResult GetDevice()
        {
            /*
            var testdata = new[]
            {
                new dev_dict {id=1,type="GenBox",settable="可配置" },
                new dev_dict {id=2,type="HIK IPC",settable="可配置" },
                new dev_dict {id=3,type="声波盾",settable="可配置" },
            };
            return Json(testdata.ToList(), JsonRequestBehavior.AllowGet);
            */


            gensysEntities gensysdb = new gensysEntities();
            var model = gensysdb.dev_dict.OrderBy(m => m.id).Select(m => new
            {
                id = m.id,
                type = m.type,
                settable = m.settable,

            });
            if (model.Count() > 0)
            {

                ViewBag.database = model.First().id + model.First().type + model.First().settable;
            }
            return Json(model.ToList(), JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult AddType(FormCollection formcollection)
        {
            string dev_type = formcollection["type"];
            string settable = formcollection["settable"];


            if (dev_type != "" && settable != "")
            {

                gensysEntities gensysdb = new gensysEntities();
                var distinctDevType = (from d in gensysdb.dev_dict
                                       where d.type == dev_type
                                       select d);
                if (distinctDevType.Count() == 0)
                {

                    dev_dict devadd = new dev_dict();
                    devadd.type = dev_type;
                    devadd.settable = settable;


                    gensysdb.dev_dict.Add(devadd);

                    gensysdb.SaveChanges();
                }
                else
                {
                    var script = String.Format("<script>alert('用户名重复！');location.href='{0}'</script>", Url.Action("DeviceSettable", "SystemConfig"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }

            }
            else
            {
                ViewBag.SubmitForm = "输入数据有误";
                var script = String.Format("<script>alert('输入数据有误！');location.href='{0}'</script>", Url.Action("DeviceSettable", "SystemConfig"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }



            return RedirectToAction("DeviceSettable");
        }

        [HttpPost]
        public ActionResult DeleteDevType(int ID)
        {
            int tag = 0;
            gensysEntities gensysdb = new gensysEntities();
            dev_dict devtypedelete = new dev_dict() { id = ID };
            gensysdb.dev_dict.Attach(devtypedelete);
            gensysdb.dev_dict.Remove(devtypedelete);

            gensysdb.SaveChanges();

            string stralterSQL = @"ALTER TABLE `dev_dict` DROP `id`; 
                                    ALTER TABLE `dev_dict` ADD `id` int NOT NULL FIRST;
                                    ALTER TABLE `dev_dict` MODIFY COLUMN `id` int NOT NULL AUTO_INCREMENT,ADD PRIMARY KEY(id);";
            /*重新使数据库的id连续*/
            gensysdb.Database.ExecuteSqlCommand(stralterSQL);

            tag = 1; /*操作完成之后，传参到前端，前端得到了就刷新页面*/
            //return Response.Redirect("Index");
            //return RedirectToRoute(new { controller="Home" ,action="Index"});
            //return Index();
            //return RedirectToAction("Index");
            return Content(tag.ToString());
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

        [HttpPost]
        public ActionResult Apply(FormCollection formcollection)
        {
            string name = formcollection["Name"];
            //logo
            string uitype = formcollection["OptionsUI"];
            string app = formcollection["Appsupport"];
            //beep
            string video = formcollection["videosource"];
            //路径



            return RedirectToAction("Index");
        }





        // GET: SysConfig
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeviceSettable()
        {
            return View();
        }

        public ActionResult Permission()
        {
            return View();
        }
    }
}