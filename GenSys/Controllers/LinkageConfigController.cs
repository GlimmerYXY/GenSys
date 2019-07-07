using AspDotNetMVCBootstrapTable.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;


namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class LinkageConfigController : Controller
    {
        
        public JsonResult GetData() //数据库待确定
        {
            gensysEntities gensysdb = new gensysEntities();
            var model = gensysdb.sys_link.OrderBy(m => m.id).Select(m => new
            {
                id = m.id,     //前者是对应表格的field名称，后者是数据结构里的属性名
                Site = m.site,
                ServerIP = m.ip,
                FileName = m.filename,
                UpdateTime = m.update_time
            });
            if (model.Count() > 0)
            {

                ViewBag.database = model.First().id ;
            }
            return Json(model.ToList(), JsonRequestBehavior.AllowGet);

        }
        // GET: LinkageConfig

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Add(FormCollection formcollection)
        {
            string site = formcollection["Site"];
            
            System.DateTime time = new DateTime();
            time = DateTime.Now;


            /*属性剩余id ip 文件名三个属性，id自增 ip和文件名读取文件*/
            
            if (site != "") //后续加入联动规则文件不为空
            {
                

                gensysEntities gensysdb = new gensysEntities();
                sys_link configadd = new sys_link();

                configadd.site = site;
                configadd.update_time = time;

                gensysdb.sys_link.Add(configadd);

                gensysdb.SaveChanges();
            }
            else
            {
                ViewBag.SubmitForm = "输入数据有误";
                var script = String.Format("<script>alert('输入数据有误！');location.href='{0}'</script>", Url.Action("Index", "LinkageConfig"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }


            //List<sys_user> list = gensysdb.sys_link.ToList();


            //return Json(newproduct.ToList(), JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            int tag = 0;
            
            gensysEntities gensysdb = new gensysEntities();
            sys_link configdelete = new sys_link() { id = ID };
            gensysdb.sys_link.Attach(configdelete);
            gensysdb.sys_link.Remove(configdelete);

            gensysdb.SaveChanges();

            string stralterSQL = @"ALTER TABLE `sys_link` DROP `id`; 
                                    ALTER TABLE `sys_link` ADD `id` int NOT NULL FIRST;
                                    ALTER TABLE `sys_link` MODIFY COLUMN `id` int NOT NULL AUTO_INCREMENT,ADD PRIMARY KEY(id);";
            //重新使数据库的id连续
            gensysdb.Database.ExecuteSqlCommand(stralterSQL);

            tag = 1; /*操作完成之后，传参到前端，前端得到了就刷新页面*/
            //return Response.Redirect("Index");
            //return RedirectToRoute(new { controller="Home" ,action="Index"});
            //return Index();
            //return RedirectToAction("Index");
            return Content(tag.ToString());
        }
    }
}