using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;

namespace GenSys.Controllers
{
    public class dev_dictController : Controller
    {
        private gensysEntities db = new gensysEntities();

        // GET: dev_dict
        public ActionResult Index()
        {
            return View(db.dev_dict.ToList());
        }

        // GET: dev_dict/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dev_dict dev_dict = db.dev_dict.Find(id);
            if (dev_dict == null)
            {
                return HttpNotFound();
            }
            return View(dev_dict);
        }

        // GET: dev_dict/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dev_dict/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,settable")] dev_dict dev_dict)
        {
            if (ModelState.IsValid)
            {
                db.dev_dict.Add(dev_dict);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dev_dict);
        }

        // GET: dev_dict/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dev_dict dev_dict = db.dev_dict.Find(id);
            if (dev_dict == null)
            {
                return HttpNotFound();
            }
            return View(dev_dict);
        }

        // POST: dev_dict/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,settable")] dev_dict dev_dict)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dev_dict).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dev_dict);
        }

        // GET: dev_dict/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dev_dict dev_dict = db.dev_dict.Find(id);
            if (dev_dict == null)
            {
                return HttpNotFound();
            }
            return View(dev_dict);
        }

        // POST: dev_dict/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dev_dict dev_dict = db.dev_dict.Find(id);
            db.dev_dict.Remove(dev_dict);
            db.SaveChanges();
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
    }
}
