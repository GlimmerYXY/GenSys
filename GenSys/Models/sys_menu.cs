//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenSys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sys_menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_menu()
        {
            this.sys_relation = new HashSet<sys_relation>();
        }
    
        public long id { get; set; }
        public string code { get; set; }
        public string pcode { get; set; }
        public string pcodes { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string url { get; set; }
        public Nullable<int> num { get; set; }
        public Nullable<int> levels { get; set; }
        public Nullable<int> ismenu { get; set; }
        public string tips { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> isopen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_relation> sys_relation { get; set; }
    }
}
