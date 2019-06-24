using System;
using System.Collections.Generic;

namespace GenSys.Models
{
    public partial class SysUser
    {
        public int Id { get; set; }
        public string DeptId { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public string Position { get; set; }
        public string Qualification { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string RoleId { get; set; }
        public string Salt { get; set; }
        public string Username { get; set; }
    }
}
