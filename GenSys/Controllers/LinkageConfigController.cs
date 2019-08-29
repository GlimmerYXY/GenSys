using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;
using System.Net;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace GenSys.Controllers
{
    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }
    }

    public class LinkageConfigController : Controller
    {
        private gensysEntities db = new gensysEntities();
        
        
        // GET: LinkageConfig
        public ActionResult Index()
        {
            var linkageEvent = from linkage_event in db.linkage_event
                               select linkage_event.name;
            List<SelectListItem> eventList = new SelectList(linkageEvent).ToList();
            eventList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewData["event"] = eventList;

            //List<string> colors = new List<string>();
            //colors.Add("red");
            //colors.Add("green");
            //colors.Add("blue");
            //ViewData["color"] = colors;

            //var linkageUuid = from device in db.device
            //                  select new {
            //                      device.alias,
            //                      device.uuid
            //                  };
            //var uuidJson = linkageUuid.ToJSON();
            //ViewBag.uuid = uuidJson;

            var linkageUuid = from device in db.device
                              select new SelectListItem
                              {
                                  Text = device.alias,
                                  Value = device.uuid
                              };
            var uuidList = linkageUuid.ToList();
            uuidList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewBag.uuid = uuidList;

            var linkageOperation = (from linkage_operation in db.linkage_operation
                                    select linkage_operation).Select(linkage_operation => new SelectListItem
                                    {
                                        Value = linkage_operation.value,
                                        Text = linkage_operation.name
                                    });
            var operationList = linkageOperation.ToList();
            operationList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewBag.operation = operationList;//opeJson;//string.Join(", ", operationList);

            var linkageAlgorithm = (from linkage_algorithm in db.linkage_algorithm
                                    select linkage_algorithm).Select(linkage_algorithm => new SelectListItem
                                    {
                                        Value = linkage_algorithm.value,
                                        Text = linkage_algorithm.name
                                    });
            ViewBag.algorithm = linkageAlgorithm;

            var linkagePosition = (from linkage_position in db.linkage_position
                                   select linkage_position).Select(linkage_position => new SelectListItem
                                   {
                                        Value = linkage_position.value,
                                        Text = linkage_position.name
                                   });
            ViewBag.position = linkagePosition;

            var linkageDetail = linkageAlgorithm.Union(linkagePosition);
            //var detailList = linkageDetail.ToList();
            //detailList.Insert(0, new SelectListItem { Text = "请选择", Selected = true, Disabled = true });
            ViewBag.detail = linkageDetail;

            return View();
        }

        public ActionResult Generate(FormCollection collection)
        {
            var Mon = collection["Mon"];
            var Tues = collection["Tues"];
            var Wed = collection["Wed"];
            var Thur = collection["Thur"];
            var Fri = collection["Fri"];
            var Sat = collection["Sat"];
            var Sun = collection["Sun"];
            var Mon0 = collection["table_data"];
            var Mon1 = collection["uuid"];
            var Mon2 = collection["option"];
            var Mon3 = collection["detail"];
            
            return RedirectToAction("Index");
        }
        
    }
}