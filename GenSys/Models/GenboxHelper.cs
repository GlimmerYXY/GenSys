using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;


namespace GenSys.Models
{
    public static class GenboxHelper
    {
        public static string ToJson(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJson(object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }

        public static string HttpPost(string url, string content, string contentType)
        {
            //配置Http协议头
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = contentType;

            //发送数据
            byte[] data = Encoding.UTF8.GetBytes(content);  //在转换字节时指定编码格式
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            string result = "";
            //获取响应内容
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static string HttpGet(string url)
        {
            //配置Http协议头
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            string result = "";
            //获取响应内容
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static void ipcam_setup_set(gensysEntities db, device  genbox)
        {
            var partIpcam = from ipcam in db.ipcam
                       where (from genbox_cpu in db.genbox_cpu
                              where genbox_cpu.genbox_uuid == genbox.uuid
                              select genbox_cpu.ipcam_uuid).Contains(ipcam.uuid)
                       select ipcam;

            //生成json格式参数
            var ipcamJson = partIpcam.ToList().ToJson();
            ipcamJson = "{\"ipcams\":" + ipcamJson + "}";

            //发送给genbox
            string result = "";
            try
            {
                while ((result = HttpPost("http://" + genbox.ip + ":9999/cgi-bin/ipcam_setup_set.cgi", ipcamJson, "application/json")) == "fail<br/>")
                {
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                //return ex.Message + ex.StackTrace;
            }

        }
    }

}