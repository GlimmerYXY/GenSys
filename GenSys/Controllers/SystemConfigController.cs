using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using GenSys.Models;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class SystemConfigController : Controller
    {
        



        public JsonResult GetDevice() //设备配置页面表格内容获取
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
        public ActionResult AddType(FormCollection formcollection) //设备配置页面的添加条目
        {
            string dev_type = formcollection["type"];
            string settable = formcollection["settable"];
            

            if (dev_type != "" && settable != "" )
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
                var script = String.Format("<script>alert('输入字段为空！');location.href='{0}'</script>", Url.Action("DeviceSettable", "SystemConfig"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }



            return RedirectToAction("DeviceSettable");
        }

        [HttpPost]
        public ActionResult DeleteDevType(int ID) //设备配置页面的删除按钮
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




        //----------------------------------------权限管理---------------------------------------------

        public JsonResult GetPermission() //权限管理的表格内容加载
        {

            gensysEntities gensysdb = new gensysEntities();
            /*
            var model = gensysdb.sys_relation.Include().Select(m => new
            {
                id = m.id,
                Position = m.type,
                AccessiblePage = m.settable,

            });
            */

            /*
            var data = from u in gensysdb.sys_role
                       join r in gensysdb.sys_relation on u.id equals r.role_id
                       join m in gensysdb.sys_menu on r.menu_id equals m.id
                       
                       select new
                       {
                           id = u.id,
                           Position = u.name,
                           AccessiblePage = m.name
                           
                       };*/
            /*某种方法
            var query = db.YourTable.ToList().GroupBy(t => new { t.FROM, t.To, t.Time })
            .Select(g => new { FROM = g.Key.From, TO = g.Key.To, NUM = g.Count(), Time = g.Key.Time, Body = string.Join(",", g.Select(s => s.Body).ToArray()) })
            */
            /*
            var query = from role in gensysdb.sys_role
                        let menuIDs = (from o in gensysdb.sys_relation.Where(w => w.sys_role.id == role.id)
                                       select o.sys_menu.name).OrderBy(x => x)
                        select new { role, menuIDs };
            */
            
            var roles = (from rol in gensysdb.sys_role
                           join rel in gensysdb.sys_relation on rol.id equals rel.role_id 
                           //from subRole in subRoles.DefaultIfEmpty()
                           join men in gensysdb.sys_menu on rel.menu_id equals men.id 
                           //from subTag in subTags.DefaultIfEmpty()
                           orderby rol.name
                   select new
                   {
                       rol.id,
                       rol.name,
                       Access=men.name
                       
                   }).ToList()
                   .GroupBy(x => new { x.id, x.name }).Select(x => new
                   {
                       x.Key.id,
                       Position=x.Key.name,
                       AccessiblePage = string.Join("," ,x.Select(y => $"{y.Access} ").Distinct()),
                       
                   }).ToList();

            return new JsonResult { Data = roles, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            

            



            //return Json(data.ToList(), JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public ActionResult AddPermission(FormCollection formcollection)
        {
            string pos = formcollection["position"];
            string home = formcollection["Home"];
            string systemconfig = formcollection["SystemConfig"];
            string devicemena = formcollection["DeviceMena"];
            string linkageconfig = formcollection["LinkageConfig"];
            string report = formcollection["Report"];
            string log = formcollection["Log"];
            string usermena = formcollection["UserMena"];
            string digitalmap = formcollection["DigitalMap"];
            string ticket = formcollection["Ticket"];

            if (pos != "")
            {
                gensysEntities gensysdb = new gensysEntities();
                var distinctPosition = (from rol in gensysdb.sys_role
                                        join rel in gensysdb.sys_relation on rol.id equals rel.role_id
                                        where rol.name == pos
                                        select rel
                                      );
                if (distinctPosition.Count() == 0)
                {
                    
                    sys_role roleadd = new sys_role();
                    roleadd.name = pos;
                    gensysdb.sys_role.Add(roleadd);
                    int newroleid = roleadd.id;

                    
                    if (home == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 1;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (systemconfig == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 2;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (devicemena == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 3;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (linkageconfig == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 4;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (report == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 5;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (log == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 6;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (usermena == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 7;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (digitalmap == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 8;
                        gensysdb.sys_relation.Add(relationadd);
                    }
                    if (ticket == "1")
                    {
                        sys_relation relationadd = new sys_relation();
                        relationadd.role_id = newroleid;
                        relationadd.menu_id = 9;
                        gensysdb.sys_relation.Add(relationadd);
                    }


                    gensysdb.SaveChanges();
                }
                else
                {
                    var script = String.Format("<script>alert('职务名称重复！');location.href='{0}'</script>", Url.Action("Permission", "SystemConfig"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }
            }
            else
            {
                var script = String.Format("<script>alert('职务名称为空！');location.href='{0}'</script>", Url.Action("Permission", "SystemConfig"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }


            return RedirectToAction("Permission"); 
        }



        [HttpPost]
        public ActionResult DeletePermission(int ID, string position) //设备配置页面的删除按钮
        {
            int tag = 0;
            gensysEntities gensysdb = new gensysEntities();

            //sys_relation rel = gensysdb.sys_relation.Where(c => c.role_id == ID).First
            //sys_relation rel = new sys_relation() { role_id = ID };
            //sys_relation rel = from u in gensysdb.sys_relation where u.role_id select u;
            //gensysdb.sys_relation.Attach(rel);
            //gensysdb.sys_relation.Remove(rel);
            //gensysdb.SaveChanges();
            var sql = @"delete from sys_relation WHERE role_id = @Id";

            gensysdb.Database.ExecuteSqlCommand(
                sql,

                new MySqlParameter("@Id", ID));

            gensysEntities gensysdb2 = new gensysEntities();
            sys_role del = gensysdb2.sys_role.Find(ID);
            if (del == null)
            {
                return HttpNotFound();
            }
            gensysdb2.sys_role.Remove(del);

           

            gensysdb2.SaveChanges();

            

            tag = 1; /*操作完成之后，传参到前端，前端得到了就刷新页面*/
            //return Response.Redirect("Index");
            //return RedirectToRoute(new { controller="Home" ,action="Index"});
            //return Index();
            //return RedirectToAction("Index");
            return Content(tag.ToString());
        }



        [HttpPost]
        public ActionResult Apply(FormCollection formcollection) //基本设置的应用按钮
        {
            string name = formcollection["Name"];
            string logo = HttpContext.Server.MapPath(Request.Form["logo"].ToString()); ;//logo
            string uitype = formcollection["OptionsUI"];
            string app = formcollection["Appsupport"];
            string beep = HttpContext.Server.MapPath(Request.Form["beep"].ToString());//beep
            string video = formcollection["videosource"];
            string picpath = formcollection["PrtScPath"];
            string videopath = formcollection["VideoPath"];//路径
            
            if(name!=""&& logo!=""&& uitype != "" && app != "" && beep != "" && video != "" && picpath != "" && videopath != "")
            {
                gensysEntities gensysdb = new gensysEntities();
                
                sys_basicconfig purge = new sys_basicconfig() { id = 1 };
                gensysdb.sys_basicconfig.Attach(purge);
                gensysdb.sys_basicconfig.Remove(purge);

                gensysdb.SaveChanges();

                string stralterSQL = @"ALTER TABLE `sys_basicconfig` DROP `id`; 
                                    ALTER TABLE `sys_basicconfig` ADD `id` int NOT NULL FIRST;
                                    ALTER TABLE `sys_basicconfig` MODIFY COLUMN `id` int NOT NULL AUTO_INCREMENT,ADD PRIMARY KEY(id);";
                /*重新使数据库的id归零*/
                gensysdb.Database.ExecuteSqlCommand(stralterSQL);

                sys_basicconfig config_add = new sys_basicconfig();//新表存储这些
                config_add.name = name;
                config_add.logo = logo;
                config_add.ui_type = uitype;
                config_add.app_support = app;
                config_add.beep = beep;
                config_add.video_src = video;
                config_add.prtsc_path = picpath;
                config_add.video_path = videopath;

                gensysdb.sys_basicconfig.Add(config_add);

                gensysdb.SaveChanges();
            }
            else
            {
                var script = String.Format("<script>alert('请输入完整！');location.href='{0}'</script>", Url.Action("Index", "SystemConfig"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }

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