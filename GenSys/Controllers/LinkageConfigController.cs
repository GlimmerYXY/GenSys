using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenSys.Models;
using System.Net;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace GenSys.Controllers
{
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
            //var uuidJson = linkageUuid.ToJson();
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
            //生成repeat
            var Mon = collection["Mon"];
            var Tues = collection["Tues"];
            var Wed = collection["Wed"];
            var Thur = collection["Thur"];
            var Fri = collection["Fri"];
            var Sat = collection["Sat"];
            var Sun = collection["Sun"];
            //过滤 hidden false
            var repeat = "";
            if (Mon.Contains("true")) repeat += "1";
            else repeat += "0";
            if (Tues.Contains("true")) repeat += "1";
            else repeat += "0";
            if (Wed.Contains("true")) repeat += "1";
            else repeat += "0";
            if (Thur.Contains("true")) repeat += "1";
            else repeat += "0";
            if (Fri.Contains("true")) repeat += "1";
            else repeat += "0";
            if (Sat.Contains("true")) repeat += "1";
            else repeat += "0";
            if (Sun.Contains("true")) repeat += "1";
            else repeat += "0";

            //生成trigger
            var trigger = collection["eventList"];
            //name转value
            var triggerList = db.linkage_event.Where(u => u.name == trigger).Select(u => u.value).ToList();
            trigger = "";//.ToJson();
            if (triggerList.Count > 0)
                trigger = triggerList[0];//.ToJson();

            //生成instruction
            var instruction = collection["instruction"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Instruction> instructionObj = js.Deserialize<List<Instruction>>(instruction);
            //name转value
            var operationDict = (from linkage_operation in db.linkage_operation
                                 select new { linkage_operation.name, linkage_operation.value }).ToDictionary(a => a.name, a => a.value);
            var uuid = (from linkage_operation in db.linkage_operation
                            select new { linkage_operation.name, linkage_operation.value });
            var algorithmDict = (from linkage_algorithm in db.linkage_algorithm
                                 select new { linkage_algorithm.name, linkage_algorithm.value }).ToDictionary(a => a.name, a => a.value);
            var positionDict = (from linkage_position in db.linkage_position
                                select new { linkage_position.name, linkage_position.value }).ToDictionary(a => a.name, a => a.value);
            foreach (var item in instructionObj)
            {
                item.operation = operationDict[item.operation];
                if (! Regex.IsMatch(item.detail, @"^[+-]?\d*[.]?\d*$")) //判断是否为数字字符串注意斜杠转义
                {
                    try
                    {
                        item.detail = algorithmDict[item.detail];
                    }
                    catch (Exception ex)    //替换算法名失败，则应替换预置位编号
                    {
                        item.detail = positionDict[item.detail];
                    }
                }
            }

            //int numInt = (instruction.Length - instruction.Replace("detail", "").Length) / "detail".Length;

            //整合为联动对象
            LinkageObj linkageObj = new LinkageObj();
            linkageObj.repeat = repeat;
            linkageObj.trigger = trigger;
            linkageObj.delay = collection["delay"];
            linkageObj.sequence = new Sequence();
            linkageObj.sequence.num = instructionObj.Count;
            linkageObj.sequence.instruction = instructionObj;
            linkageObj.ToJson();

            //整合json字符串
            //StringBuilder linkageJson = new StringBuilder();
            //linkageJson.Append("{\"repeat\":" + repeat);
            //linkageJson.Append(",\"trigger\":" + trigger);
            //linkageJson.Append(",\"delay\":" + delay);
            //linkageJson.Append(",\"sequence\":{\"num\":" + num);
            //linkageJson.Append(",\"instructin\": " + instruction + "}}");

            //将linkageJson发送到genbox接口
            MyLinkage(js.Serialize(linkageObj));    //linkageJson.ToString()

            return RedirectToAction("Index");
        }

        public void MyLinkage(string linkageJson)
        {
            ////保存目录
            //string dir = "Public\\Linkage\\";
            ////站点文件目录
            //string fileDir = HttpRuntime.AppDomainAppPath + dir;

            //if (!Directory.Exists(fileDir))
            //    Directory.CreateDirectory(fileDir);

            ////文件名称
            //string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_linkage.json";
            ////保存文件所在站点位置
            //string filePath = Path.Combine(fileDir, fileName);

            try
            {
                using (StreamWriter sw = new StreamWriter("D:\\linkage.json"))
                {
                    sw.WriteLine(linkageJson);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }

        }
    }
}