﻿using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class SysDept
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Fullname { get; set; }
        public int? Num { get; set; }
        public int? Pid { get; set; }
        public string Pids { get; set; }
        public string Tips { get; set; }
        public int? Version { get; set; }
    }
}
