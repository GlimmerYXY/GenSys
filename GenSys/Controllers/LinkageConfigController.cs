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
using System.Data.Entity;

namespace GenSys.Controllers
{
    public class LinkageConfigController : Controller
    {
        private gensysEntities db = new gensysEntities();

        public ActionResult Index0()
        {
            return View();
        }

        public ActionResult Index()
        {
            var linkageEvent = from linkage_event in db.linkage_event
                               select linkage_event.name;
            List<SelectListItem> eventList = new SelectList(linkageEvent).ToList();
            eventList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewData["eventList"] = eventList;

            var linkageUuid = from device in db.device
                              select device.alias;
            List<SelectListItem> uuidList = new SelectList(linkageUuid).ToList();
            uuidList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewData["uuidList"] = uuidList;

            var linkageOperation = from linkage_operation in db.linkage_operation
                                   select linkage_operation.name;
            List<SelectListItem> operationList = new SelectList(linkageOperation).ToList();
            operationList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewData["operationList"] = operationList;

            var linkageAlgorithm = from linkage_algorithm in db.linkage_algorithm
                                   select linkage_algorithm.name;
            List<SelectListItem> algorithmList = new SelectList(linkageAlgorithm).ToList();
            algorithmList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            ViewData["detailList"] = algorithmList;
            
            //var linkageEvent = from linkage_event in db.linkage_event
            //                   select new SelectListItem
            //                   {
            //                       Text = linkage_event.name,
            //                       Value = linkage_event.name
            //                   };
            //var eventList = linkageEvent.ToList();
            //eventList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            //ViewBag.eventList = eventList;

            //var linkageUuid = from device in db.device
            //                  select new SelectListItem
            //                  {
            //                      Text = device.alias,
            //                      Value = device.alias
            //                  };
            //var uuidList = linkageUuid.ToList();
            //uuidList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            //ViewBag.uuidList = uuidList;

            //var linkageOperation = (from linkage_operation in db.linkage_operation
            //                        select linkage_operation).Select(linkage_operation => new SelectListItem
            //                        {
            //                            Value = linkage_operation.name,
            //                            Text = linkage_operation.name
            //                        });
            //var operationList = linkageOperation.ToList();
            //operationList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            //ViewBag.operationList = operationList;//opeJson;//string.Join(", ", operationList);

            //var linkageAlgorithm = (from linkage_algorithm in db.linkage_algorithm
            //                        select linkage_algorithm).Select(linkage_algorithm => new SelectListItem
            //                        {
            //                            Value = linkage_algorithm.name,
            //                            Text = linkage_algorithm.name
            //                        });
            ////ViewBag.algorithm = linkageAlgorithm;

            ////var linkagePosition = (from linkage_position in db.linkage_position
            ////                       select linkage_position).Select(linkage_position => new SelectListItem
            ////                       {
            ////                            Value = linkage_position.value,
            ////                            Text = linkage_position.name
            ////                       });
            ////ViewBag.position = linkagePosition;

            ////var linkageDetail = linkageAlgorithm.Union(linkagePosition);
            //var detailList = linkageAlgorithm.ToList(); // linkageDetail.ToList();
            //detailList.Insert(0, new SelectListItem { Text = " ", Selected = true, Disabled = true });
            //ViewBag.detailList = detailList;// linkageDetail;

            return View();
        }

        public JsonResult GetTrg()
        {
            //var eventDict = (from linkage_event in db.linkage_event
            //                 select new { linkage_event.value, linkage_event.name }
            //         ).ToDictionary(a => a.value, a => a.name);

            List<linkage_trigger> trgList = db.linkage_trigger.ToList();
            //foreach (var item in trgList)
            //{
            //    item.trigger = eventDict[item.trigger];
            //}

            return Json(trgList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIstr()
        {
            //var eventDict = (from linkage_event in db.linkage_event
            //                 select new { linkage_event.value, linkage_event.name }
            //                ).ToDictionary(a => a.value, a => a.name);
            //var operationDict = (from linkage_operation in db.linkage_operation
            //                     select new { linkage_operation.value, linkage_operation.name }
            //                    ).ToDictionary(a => a.value, a => a.name);
            //var uuidDict = (from device in db.device
            //                select new { device.uuid, device.alias }
            //                ).ToDictionary(a => a.uuid, a => a.alias);
            //var algorithmDict = (from linkage_algorithm in db.linkage_algorithm
            //                     select new { linkage_algorithm.value, linkage_algorithm.name }
            //                     ).ToDictionary(a => a.value, a => a.name);

            List<linkage_instruction> istrList = db.linkage_instruction.ToList();
            //foreach (var item in istrList)
            //{
            //    item.trigger = eventDict[item.trigger];
            //    item.operation = operationDict[item.operation];
            //    if (!Regex.IsMatch(item.detail, @"^[+-]?\d*[.]?\d*$")) //判断是否为数字字符串注意斜杠转义
            //        item.detail = algorithmDict[item.detail];
            //    item.uuid = uuidDict[item.uuid];
            //}

            return Json(istrList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddTrg(FormCollection collection)
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

            linkage_trigger trg = new linkage_trigger();
            trg.delay = int.Parse(collection["delay1"]);
            trg.repeat = repeat;
            trg.trigger = collection["trigger1"];

            db.linkage_trigger.Add(trg);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult AddIstr(FormCollection collection)
        {
            linkage_instruction istr = new linkage_instruction();

            //var detailName = collection["detail"];    //LINQ里不能直接用collection[]
            //var detail = from linkage_algorithm in db.linkage_algorithm
            //             where linkage_algorithm.name == detailName
            //             select linkage_algorithm.value;
            //var detailList = detail.ToList();
            //if(detailList.Count > 0)
            //    istr.detail = detailList[0];
            //else
            //    istr.detail = collection["detail"];

            //var operationName = collection["operation"];    //LINQ里不能直接用collection[]
            //var operation = from linkage_operation in db.linkage_operation
            //                where linkage_operation.name == operationName
            //                select linkage_operation.value;
            //var operationList = operation.ToList();
            //istr.operation = operationList[0];

            //var triggerName = collection["trigger2"];    //LINQ里不能直接用collection[]
            //var trigger = from linkage_event in db.linkage_event
            //              where linkage_event.name == triggerName
            //              select linkage_event.value;
            //var triggerList = trigger.ToList();
            //istr.trigger = triggerList[0];

            //var uuidName = collection["uuid"];    //LINQ里不能直接用collection[]
            //var uuid = from device in db.device
            //           where device.alias == uuidName
            //           select device.uuid;
            //var uuidList = uuid.ToList();
            //istr.uuid = uuidList[0];

            istr.detail = collection["detail3"];
            istr.operation = collection["operation3"];
            istr.trigger = collection["trigger3"];
            istr.uuid = collection["uuid3"];

            db.linkage_instruction.Add(istr);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditTrg(FormCollection collection)
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

            linkage_trigger trg = new linkage_trigger();
            trg.id = int.Parse(collection["id2"]);
            trg.delay = int.Parse(collection["delay2"]);
            trg.repeat = repeat;
            trg.trigger = collection["trigger2"];

            db.Entry<linkage_trigger>(trg).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditIstr(FormCollection collection)
        {
            linkage_instruction istr = new linkage_instruction();

            istr.id = int.Parse(collection["id4"]);
            istr.detail = collection["detail4"];
            istr.operation = collection["operation4"];
            istr.trigger = collection["trigger4"];
            istr.uuid = collection["uuid4"];

            db.Entry<linkage_instruction>(istr).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string kind, string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (kind == "trgTable")
            {
                linkage_trigger trigger = db.linkage_trigger.Find(int.Parse(id));
                if (trigger == null)
                {
                    return HttpNotFound();
                }
                db.linkage_trigger.Remove(trigger);

                db.SaveChanges();
            }
            else if (kind == "istrTable")
            {
                linkage_instruction instruction = db.linkage_instruction.Find(int.Parse(id));
                if (instruction == null)
                {
                    return HttpNotFound();
                }
                db.linkage_instruction.Remove(instruction);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult ExportCfg()
        {
            var uuidDict = (from device in db.device
                            select new { device.alias, device.uuid }
                            ).ToDictionary(a => a.alias, a => a.uuid);
            var eventDict = (from linkage_event in db.linkage_event
                             select new { linkage_event.name, linkage_event.value }
                            ).ToDictionary(a => a.name, a => a.value);
            var operationDict = (from linkage_operation in db.linkage_operation
                                 select new { linkage_operation.name, linkage_operation.value }
                                ).ToDictionary(a => a.name, a => a.value);
            var algorithmDict = (from linkage_algorithm in db.linkage_algorithm
                                 select new { linkage_algorithm.name, linkage_algorithm.value }
                                 ).ToDictionary(a => a.name, a => a.value);

            var trgList = (from linkage_trigger in db.linkage_trigger
                           select linkage_trigger).ToList();
            for (int i = 0; i < trgList.Count; i++)
            {
                try
                {
                    var trigger = trgList[i].trigger;
                    //整合为联动对象
                    LinkageObj linkageObj = new LinkageObj();

                    linkageObj.trigger = eventDict[trigger];
                    linkageObj.delay = (int)trgList[i].delay;
                    linkageObj.repeat = trgList[i].repeat;
                    linkageObj.sequence = new Sequence();

                    var istrList = (from linkage_instruction in db.linkage_instruction
                                    where linkage_instruction.trigger == trigger
                                    select new Instruction
                                    {
                                        operation = linkage_instruction.operation,
                                        detail = linkage_instruction.detail,
                                        uuid = linkage_instruction.uuid
                                    }).ToList();
                    linkageObj.sequence.num = istrList.Count;

                    foreach (var item in istrList)
                    {
                        item.operation = operationDict[item.operation];
                        if (!Regex.IsMatch(item.detail, @"^[+-]?\d*[.]?\d*$")) //判断是否为数字字符串注意斜杠转义
                            item.detail = algorithmDict[item.detail];
                        item.uuid = uuidDict[item.uuid];
                    }
                    linkageObj.sequence.instruction = istrList;

                    linkageObj.ToJson();
                    //将linkageJson发送到genbox接口
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    MyLinkage(linkageObj.trigger, js.Serialize(linkageObj));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ex.StackTrace);
                }
            }

            return RedirectToAction("Index");
        }

        public void MyLinkage(string trigger, string linkageJson)
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
                using (StreamWriter sw = new StreamWriter("D:\\GensysLinkage\\" + trigger + "_linkage.json"))
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
