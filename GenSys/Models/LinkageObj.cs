using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenSys.Models
{
    
    public class LinkageObj
    {
        public string trigger { get; set; }
        public int delay { get; set; }
        public string repeat { get; set; }
        public Sequence sequence;
    }

    public class Sequence
    {
        public int num { get; set; }
        public List<Instruction> instruction;
    }

    public class Instruction
    {
        public string operation { get; set; }
        public string uuid { get; set; }
        public string detail { get; set; }
    }
}