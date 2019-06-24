using AspDotNetMVCBootstrapTable.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class LinkageConfigController : Controller
    {
        private class Product
        {
            public string Num { get; set; }
            public string Site { get; set; }
            public string ServerIP { get; set; }

        }

        public JsonResult GetData()
        {
            var products = new[] {
                new Product { Num = "1", Site = "磨溪", ServerIP = "192.168.0.1" }
            };

            return Json(products.ToList(), JsonRequestBehavior.AllowGet);

        }
        // GET: LinkageConfig

        public ActionResult Index()
        {
            return View();
        }
    }
}