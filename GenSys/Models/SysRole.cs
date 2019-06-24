using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class SysRole
    {
        public int Id { get; set; }
        public int? DeptId { get; set; }
        public string Name { get; set; }
        public int? Num { get; set; }
        public int? Pid { get; set; }
        public string Tips { get; set; }
        public int? Version { get; set; }
    }
}
