using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GenSys.MySQL;


namespace AspDotNetMVCBootstrapTable.Models
{
    public class UserInfo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string role_id { get; set; }
        public string name { get; set; }
        public string dept_id { get; set; }
        public string position { get; set; }
        public string qualification { get; set; }
        public string id_number { get; set; }
        public string phone_number { get; set; }
        public string photo { get; set; }
        public Nullable<System.DateTime> register_date { get; set; }
    }
    //public class 
}