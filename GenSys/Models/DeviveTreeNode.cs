using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenSys.Models
{
    public class DeviveTreeNode
    {
        //public int id { get; set; }
        public string dev_type { get; set; }
        public string dev_model { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string uuid { get; set; }
        public string rtsp_url { get; set; }
        public string ip { get; set; }
        public Nullable<int> media_port { get; set; }
        //public string site { get; set; }
        //public string alias { get; set; }

        public string text { get; set; }
        
        //public bool @checked { get; set; }

        //public bool hasChildren { get; set; }

        public virtual List<DeviveTreeNode> children { get; set; }
    }
}