using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class Alarm
    {
        public int Id { get; set; }
        public string AlgorithmId { get; set; }
        public string Appendix { get; set; }
        public string DeviceId { get; set; }
        public string Image { get; set; }
        public string Ip { get; set; }
        public string Message { get; set; }
        public string P2pId { get; set; }
        public long? Timestamp { get; set; }
        public string Token { get; set; }
    }
}
