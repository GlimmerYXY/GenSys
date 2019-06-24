using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class SysDict
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Num { get; set; }
        public int? Pid { get; set; }
        public string Tips { get; set; }
    }
}
