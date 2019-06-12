using AspDotNetMVCBootstrapTable.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetMVCBootstrapTable.Controllers
{
    public class HomeController : Controller
    {
        public JObject RecvRegister()
        {
            Request.InputStream.Position = 0;
            using (StreamReader inputStream = new StreamReader(Request.InputStream))
            {
                String str = inputStream.ReadToEnd();
                JObject jo = (JObject)JsonConvert.DeserializeObject(str);

                string deviceID = null;
                string p2pID = null;
                
                try { deviceID = jo["deviceID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { p2pID = jo["p2pID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                
                JObject postedJObject = new JObject();
                if ((deviceID == null || deviceID == "") && (p2pID == null || p2pID == ""))
                {
                    postedJObject.Add("err", 410);
                    postedJObject.Add("errMsg", "设备ID/P2PID不能为空");
                }
                else
                {
                    TokenGenerator tokenGenerator = new TokenGenerator();
                    String token = tokenGenerator.NewToken();
                    postedJObject.Add("err", 0);
                    postedJObject.Add("errMsg", "ok");
                    postedJObject.Add("token", token);
                }

                return postedJObject;
            }
        }

        public JObject RecvAlarm()
        {
            Request.InputStream.Position = 0;
            using (StreamReader inputStream = new StreamReader(Request.InputStream))
            {
                String str = inputStream.ReadToEnd();
                JObject jo = (JObject)JsonConvert.DeserializeObject(str);

                string deviceID = null;
                string p2pID = null;
                string token = null;
                string algID = null;
                string timestamp = null;
                string image = null;
                string msg = null;
                string appendix = null;

                try { deviceID = jo["deviceID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { p2pID = jo["p2pID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { token = jo["token"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { algID = jo["algID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { timestamp = jo["timestamp"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { image = jo["image"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { msg = jo["msg"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { appendix = jo["appendix"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                JObject postedJObject = new JObject();
                if (token == null || token == "")
                {
                    postedJObject.Add("err", 411);
                    postedJObject.Add("errMsg", "token错误");
                }
                else
                {
                    postedJObject.Add("err", 0);
                    postedJObject.Add("errMsg", "ok");
                }

                return postedJObject;
            }
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        private class Product
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
        }

        public JsonResult GetData()
        {
            var products = new[] {
                new Product { ID = "1", Name = "Item 1", Price = "$1" },
                new Product { ID = "2", Name = "Item 2", Price = "$1" },
                new Product { ID = "3", Name = "Item 3", Price = "$1" },
                new Product { ID = "4", Name = "Item 4", Price = "$4" },
                new Product { ID = "5", Name = "Item 5", Price = "$5" },
                new Product { ID = "6", Name = "Item 6", Price = "$6" },
                new Product { ID = "7", Name = "Item 7", Price = "$7" },
                new Product { ID = "8", Name = "Item 8", Price = "$8" },
                new Product { ID = "9", Name = "Item 9", Price = "$9" },
                new Product { ID = "10", Name = "Item 10", Price = "$10" },
                new Product { ID = "11", Name = "Item 11", Price = "$11" },
                new Product { ID = "12", Name = "Item 12", Price = "$12" },
                new Product { ID = "13", Name = "Item 13", Price = "$13" },
                new Product { ID = "14", Name = "Item 14", Price = "$14" },
                new Product { ID = "15", Name = "Item 15", Price = "$15" },
                new Product { ID = "16", Name = "Item 16", Price = "$16" },
                new Product { ID = "17", Name = "Item 17", Price = "$17" },
                new Product { ID = "18", Name = "Item 18", Price = "$18" },
                new Product { ID = "19", Name = "Item 19", Price = "$19" },
                new Product { ID = "20", Name = "Item 20", Price = "$20" },
                new Product { ID = "21", Name = "Item 21", Price = "$21" },
                new Product { ID = "22", Name = "Item 22", Price = "$22" },
                new Product { ID = "23", Name = "Item 23", Price = "$23" },
                new Product { ID = "24", Name = "Item 24", Price = "$24" },
                new Product { ID = "25", Name = "Item 25", Price = "$25" },
                new Product { ID = "26", Name = "Item 26", Price = "$26" },
                new Product { ID = "27", Name = "Item 27", Price = "$27" },
                new Product { ID = "28", Name = "Item 28", Price = "$28" },
                new Product { ID = "29", Name = "Item 29", Price = "$29" },
                new Product { ID = "30", Name = "Item 30", Price = "$30" },
            };

            return Json(products.ToList(), JsonRequestBehavior.AllowGet);

        }
        
    }
}