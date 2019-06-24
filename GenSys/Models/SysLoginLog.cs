using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class SysLoginLog
    {
        public int Id { get; set; }
        public DateTime? Createtime { get; set; }
        public string Ip { get; set; }
        public string LogName { get; set; }
        public string Message { get; set; }
        public string Succeed { get; set; }
        public int? UserId { get; set; }
    }
}
