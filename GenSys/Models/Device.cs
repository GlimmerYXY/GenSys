using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class Device
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string DevModel { get; set; }
        public string DevType { get; set; }
        public string Ip { get; set; }
        public int MediaPort { get; set; }
        public string Password { get; set; }
        public string Site { get; set; }
        public string Username { get; set; }
    }
}
