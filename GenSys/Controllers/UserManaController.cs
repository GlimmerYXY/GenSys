using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;


namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class UserManaController : Controller
    {

        public JsonResult GetData()
        {
            /*var products = new[] {
                new UserInfo { Num = 1, UserType = "超级管理员", UserID = "sa", Password = "sa", Remove = "不可删除/修改" },
                new UserInfo { Num = 2, UserType = "管理员", UserID = "zhangsan", Password = "123456" },
                new UserInfo { Num = 3, UserType = "操作员", UserID = "lisi", Password = "654321" }
            };*/

            gensysEntities gensysdb = new gensysEntities();
            var model = gensysdb.sys_user.OrderBy(m => m.id).Select(m => new
            {
                id = m.id,
                username = m.username,
                name = m.name,
                password = m.password,
                //salt = m.salt,
                role_id = m.role_id,

                dept_id = m.dept_id,
                position = m.position,
                qualification = m.qualification,
                id_number = m.id_number,
                phone_number = m.phone_number,
                photo = m.photo,
                register_date = m.register_date

            });
            if (model.Count() > 0)
            {

                ViewBag.database = model.First().id + model.First().username + model.First().name;
            }
            return Json(model.ToList(), JsonRequestBehavior.AllowGet);

        }
        // GET: UserMana

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection formcollection)
        {
            string usertype = formcollection["role_id"];
            string userid = formcollection["username"];
            string password = formcollection["password"];
            string name = formcollection["name"];
            string department = formcollection["dept_id"];
            string position = formcollection["position"];
            string qualification = formcollection["qualification"];
            string idnum = formcollection["id_number"];
            string phone = formcollection["phone_number"];
            System.DateTime time = new DateTime();
            time = DateTime.Now;

            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[36];
            rng.GetBytes(saltBytes);
            string salt = Convert.ToBase64String(saltBytes);
            //string salt = ToHexString(saltBytes);   
            //ViewBag.salt = salt;
            /*属性剩余id photo salt三个属性，id自增 salt随机生成 photo路径*/

            if (usertype != "" && userid != "" && password != "" && name != "" && department != "" &&
                position != "" && qualification != "" && idnum != "" && phone != "")
            {
                ViewBag.SubmitForm = usertype + " " + userid + " " + password + " " + name + " " +
                  department + " " + position + " " + qualification + " " + idnum + " " + phone + " " + time;

                gensysEntities gensysdb = new gensysEntities();
                var distinctUser = (from d in gensysdb.sys_user
                                    where d.username == userid
                                    select d);
                if (distinctUser.Count() == 0)
                {
                    sys_user useradd = new sys_user();

                    useradd.role_id = usertype;
                    useradd.username = userid;
                    useradd.password = password;
                    useradd.salt = salt;
                    useradd.name = name;
                    useradd.dept_id = department;
                    useradd.position = position;
                    useradd.qualification = qualification;
                    useradd.id_number = idnum;
                    useradd.phone_number = phone;
                    useradd.register_date = time;

                    gensysdb.sys_user.Add(useradd);

                    gensysdb.SaveChanges();
                }
                else
                {
                    var script = String.Format("<script>alert('用户名重复！');location.href='{0}'</script>", Url.Action("Index", "UserMana"));
                    //Url.Action()用于指定跳转的路径             
                    return Content(script, "text/html");
                }

            }
            else
            {
                ViewBag.SubmitForm = "输入数据有误";
                var script = String.Format("<script>alert('输入数据有误！');location.href='{0}'</script>", Url.Action("Index", "UserMana"));
                //Url.Action()用于指定跳转的路径             
                return Content(script, "text/html");
            }


            //List<sys_user> list = gensysdb.sys_user.ToList();


            //return Json(newproduct.ToList(), JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult FileImport(FormCollection filecollection) /*导入用户信息，此功能待后续部分完成*/
        {

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Delete(int ID)
        {
            int tag = 0;
            gensysEntities gensysdb = new gensysEntities();
            sys_user userdelete = new sys_user() { id = ID };
            gensysdb.sys_user.Attach(userdelete);
            gensysdb.sys_user.Remove(userdelete);

            gensysdb.SaveChanges();

            string stralterSQL = @"ALTER TABLE `sys_user` DROP `id`; 
                                    ALTER TABLE `sys_user` ADD `id` int NOT NULL FIRST;
                                    ALTER TABLE `sys_user` MODIFY COLUMN `id` int NOT NULL AUTO_INCREMENT,ADD PRIMARY KEY(id);";
            /*重新使数据库的id连续*/
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