using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetMVCBootstrapTable.Models
{
    public class Alarm
    {
        public string deviceID { get; set; }
        public string p2pID { get; set; }       //P2PID
        public string token { get; set; }
        public string algID { get; set; }       //算法ID
        public Int64 timestamp { get; set; }
        public string image { get; set; }       //图片数据，base64编码
        public string msg { get; set; }         //信息数据
        public string appendix { get; set; }    //附加数据
        
        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }
    }
}