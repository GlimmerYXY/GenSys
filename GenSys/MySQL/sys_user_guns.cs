//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenSys.MySQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class sys_user_guns
    {
        public int id { get; set; }
        public string avatar { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public Nullable<int> sex { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string roleid { get; set; }
        public Nullable<int> deptid { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<System.DateTime> createtime { get; set; }
        public Nullable<int> version { get; set; }
    }
}
