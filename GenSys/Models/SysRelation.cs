using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class SysRelation
    {
        public int Id { get; set; }
        public long? MenuId { get; set; }
        public int? RoleId { get; set; }
    }
}
