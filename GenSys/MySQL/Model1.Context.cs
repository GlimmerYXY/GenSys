﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gensysEntities : DbContext
    {
        public gensysEntities()
            : base("name=gensysEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<alarm> alarm { get; set; }
        public virtual DbSet<dev_dict> dev_dict { get; set; }
        public virtual DbSet<device> device { get; set; }
        public virtual DbSet<site> site { get; set; }
        public virtual DbSet<sys_dept> sys_dept { get; set; }
        public virtual DbSet<sys_dict> sys_dict { get; set; }
        public virtual DbSet<sys_link> sys_link { get; set; }
        public virtual DbSet<sys_login_log> sys_login_log { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }
        public virtual DbSet<sys_operation_log> sys_operation_log { get; set; }
        public virtual DbSet<sys_relation> sys_relation { get; set; }
        public virtual DbSet<sys_role> sys_role { get; set; }
        public virtual DbSet<sys_user> sys_user { get; set; }
        public virtual DbSet<sys_user_guns> sys_user_guns { get; set; }
    }
}