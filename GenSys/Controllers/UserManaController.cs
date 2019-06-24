﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspDotNetMVCBootstrapTable.Models;
using GenSys.MySQL;

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
                password =m.password,
                salt = m.salt,
                role_id = m.role_id,
                
                dept_id = m.dept_id,
                position = m.position,
                qualification = m.qualification,
                id_number = m.id_number,
                phone_number = m.phone_number,
                photo=m.photo,
                register_date=m.register_date

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
        public ActionResult Index(FormCollection formcollection)
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
            /*属性剩余id photo salt三个属性，id自增 salt随机生成 photo路径*/

            if (usertype!="" && userid!= "" && password != "" && name != "" && department != "" && 
                position != "" && qualification != "" && idnum != "" && phone != "")
            {   ViewBag.SubmitForm = usertype + " " + userid + " " + password + " " + name + " " +
                  department + " " + position + " " + qualification + " " + idnum + " " + phone + " "+ time;

                gensysEntities gensysdb = new gensysEntities();
                sys_user useradd = new sys_user();

                useradd.role_id = usertype;
                useradd.username = userid;
                useradd.password = password;
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
                ViewBag.SubmitForm = "输入数据有误";
            }

            

            //List<sys_user> list = gensysdb.sys_user.ToList();

            
            //return Json(newproduct.ToList(), JsonRequestBehavior.AllowGet);
            return View();
        }
    }
}