using GenSys.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
 
namespace GenSys.Controllers
{
    public class HomeController : Controller
    {
        private gensysEntities db = new gensysEntities();


        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult test()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            ViewData["alarm"] = db.alarm.ToList();
            return View();
        }


        /* 报警信息列表 */
        public JsonResult GetAlarm()
        {
            return Json(db.alarm.ToList(), JsonRequestBehavior.AllowGet);
        }
 

        /* 树形菜单 */
        public JsonResult GetTree()
        {
            List<device> raw;
            List<DeviveTreeNode> records;

            raw = db.device.ToList();
            
            records = raw.GroupBy(l => l.site).Select(l => l.Key).Select(l => new DeviveTreeNode
            {
                id = -1,
                ip = null,
                media_port = -1,
                username = null,
                password = null,
                dev_type = null,
                dev_model = null,
                text = l,
                children = GetChildren(raw, l)
            }).ToList();

            return Json(records, JsonRequestBehavior.AllowGet);
        }

        private List<DeviveTreeNode> GetChildren(List<device> raw, string siteKey)
        {
            return raw.Where(l => l.site == siteKey).Select(l => new DeviveTreeNode
            {
                id = l.id,
                ip = l.ip,
                media_port = l.media_port,
                username = l.username,
                password = l.password,
                dev_type = l.dev_type,
                dev_model = l.dev_model,
                text = l.alias,
                children = null
            }).ToList();
        }


        /* 相机报警接口 */
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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JObject RecvAlarm()
        {
            /* 获取报警信息 */
            var ip = Request.UserHostAddress;

            string deviceID = null;
            string p2pID = null;
            string token = null;
            string algID = null;
            long timestamp = 0;
            string image = null;
            string msg = null;
            string appendix = null;

            Request.InputStream.Position = 0;
            using (StreamReader inputStream = new StreamReader(Request.InputStream))
            {
                String str = inputStream.ReadToEnd();
                JObject jo = (JObject)JsonConvert.DeserializeObject(str);

                try { deviceID = jo["deviceID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { p2pID = jo["p2pID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { token = jo["token"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { algID = jo["algID"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { timestamp = long.Parse(jo["timestamp"].ToString()); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { image = jo["image"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { msg = jo["msg"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                try { appendix = jo["appendix"].ToString(); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            /* 存储报警 */
            if (deviceID != null || p2pID != null)
            {
                //保存目录
                string dir = "Public/AlarmSnap/";
                //站点文件目录
                string fileDir = HttpRuntime.AppDomainAppPath + dir;   // HttpContext.Current.Server.MapPath("~" + dir);
                                                                       //文件名称
                string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + timestamp.ToString() + ".jpg";
                //保存文件所在站点位置
                string filePath = Path.Combine(fileDir, fileName);

                if (!Directory.Exists(fileDir))
                    Directory.CreateDirectory(fileDir);

                try
                {
                    if (image != null)  //保存报警截图
                    {
                        byte[] b = Convert.FromBase64String(image);
                        MemoryStream ms = new MemoryStream(b);
                        Bitmap bitmap = new Bitmap(ms);
                        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace + ex.Message);
                }

                try
                {
                    alarm alarm = new alarm();
                    //alarm.id = db.alarm.Count() + 1;
                    alarm.device_id = deviceID;
                    alarm.p2p_id = p2pID;
                    alarm.ip = ip;
                    alarm.token = token;
                    alarm.algorithm_id = algID;
                    alarm.timestamp = timestamp;
                    alarm.image = filePath;
                    alarm.message = msg;
                    alarm.appendix = appendix;

                    alarm.state = "red";
                    var query = from device in db.device
                                where device.ip == ip
                                select new
                                { device.site, device.alias };
                    var queryList = query.ToList();
                    if (queryList.Count > 0)
                    {
                        alarm.site = queryList[0].site;  //tostring
                        alarm.alias = queryList[0].alias;  //tostring
                    }
                    //alarm.type
                    DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                    TimeSpan toNow = new TimeSpan(timestamp);
                    alarm.datetime = dtStart.Add(toNow);
                    alarm.confirmed = 0;

                    db.alarm.Add(alarm);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace + ex.Message);
                }
            }

            /* 发送返回信息 */
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


        /* 测试数据 */
        private class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; }
        }

        public JsonResult GetData()
        {
            var products = new[] {
                new Product { Id = "1", Name = "Item 1", Price = "$1" },
                new Product { Id = "2", Name = "Item 2", Price = "$1" },
                new Product { Id = "3", Name = "Item 3", Price = "$1" },
                new Product { Id = "4", Name = "Item 4", Price = "$4" },
                new Product { Id = "5", Name = "Item 5", Price = "$5" },
                new Product { Id = "6", Name = "Item 6", Price = "$6" },
                new Product { Id = "7", Name = "Item 7", Price = "$7" },
                new Product { Id = "8", Name = "Item 8", Price = "$8" },
                new Product { Id = "9", Name = "Item 9", Price = "$9" },
                new Product { Id = "10", Name = "Item 10", Price = "$10" },
                new Product { Id = "11", Name = "Item 11", Price = "$11" },
                new Product { Id = "12", Name = "Item 12", Price = "$12" },
                new Product { Id = "13", Name = "Item 13", Price = "$13" },
                new Product { Id = "14", Name = "Item 14", Price = "$14" },
                new Product { Id = "15", Name = "Item 15", Price = "$15" },
                new Product { Id = "16", Name = "Item 16", Price = "$16" },
                new Product { Id = "17", Name = "Item 17", Price = "$17" },
                new Product { Id = "18", Name = "Item 18", Price = "$18" },
                new Product { Id = "19", Name = "Item 19", Price = "$19" },
                new Product { Id = "20", Name = "Item 20", Price = "$20" },
                new Product { Id = "21", Name = "Item 21", Price = "$21" },
                new Product { Id = "22", Name = "Item 22", Price = "$22" },
                new Product { Id = "23", Name = "Item 23", Price = "$23" },
                new Product { Id = "24", Name = "Item 24", Price = "$24" },
                new Product { Id = "25", Name = "Item 25", Price = "$25" },
                new Product { Id = "26", Name = "Item 26", Price = "$26" },
                new Product { Id = "27", Name = "Item 27", Price = "$27" },
                new Product { Id = "28", Name = "Item 28", Price = "$28" },
                new Product { Id = "29", Name = "Item 29", Price = "$29" },
                new Product { Id = "30", Name = "Item 30", Price = "$30" },
            };

            return Json(products.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}