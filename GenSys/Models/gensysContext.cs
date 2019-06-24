using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GenSys.Models
{
    public partial class gensysContext : DbContext
    {
        public virtual DbSet<Alarm> Alarm { get; set; }
        public virtual DbSet<DevDict> DevDict { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<SysDept> SysDept { get; set; }
        public virtual DbSet<SysDict> SysDict { get; set; }
        public virtual DbSet<SysLoginLog> SysLoginLog { get; set; }
        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysOperationLog> SysOperationLog { get; set; }
        public virtual DbSet<SysRelation> SysRelation { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserGuns> SysUserGuns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"server=10.108.64.170;user id=xingchen;pwd=123456Abc!;database=gensys");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarm>(entity =>
            {
                entity.ToTable("alarm");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AlgorithmId)
                    .HasColumnName("algorithm_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Appendix)
                    .HasColumnName("appendix")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("device_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.P2pId)
                    .HasColumnName("p2p_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("bigint(50)");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DevDict>(entity =>
            {
                entity.ToTable("dev_dict");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("device");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Alias)
                    .HasColumnName("alias")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DevModel)
                    .HasColumnName("dev_model")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DevType)
                    .HasColumnName("dev_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("ip")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MediaPort)
                    .HasColumnName("media_port")
                    .HasColumnType("int(50)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Site)
                    .HasColumnName("site")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SysDept>(entity =>
            {
                entity.ToTable("sys_dept");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Abbreviation)
                    .HasColumnName("abbreviation")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pids)
                    .HasColumnName("pids")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysDict>(entity =>
            {
                entity.ToTable("sys_dict");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SysLoginLog>(entity =>
            {
                entity.ToTable("sys_login_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(65)");

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LogName)
                    .HasColumnName("log_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.Succeed)
                    .HasColumnName("succeed")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(65)");
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.ToTable("sys_menu");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Ismenu)
                    .HasColumnName("ismenu")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Isopen)
                    .HasColumnName("isopen")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Levels)
                    .HasColumnName("levels")
                    .HasColumnType("int(65)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(65)");

                entity.Property(e => e.Pcode)
                    .HasColumnName("pcode")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Pcodes)
                    .HasColumnName("pcodes")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(65)");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SysOperationLog>(entity =>
            {
                entity.ToTable("sys_operation_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(65)");

                entity.Property(e => e.ClassName)
                    .HasColumnName("class_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.LogName)
                    .HasColumnName("log_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LogType)
                    .HasColumnName("log_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.Method)
                    .HasColumnName("method")
                    .HasColumnType("text");

                entity.Property(e => e.Succeed)
                    .HasColumnName("succeed")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(65)");
            });

            modelBuilder.Entity<SysRelation>(entity =>
            {
                entity.ToTable("sys_relation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("bigint(11)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.ToTable("sys_role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tips)
                    .HasColumnName("tips")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("sys_user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DeptId)
                    .HasColumnName("dept_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.IdNumber)
                    .HasColumnName("id_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Qualification)
                    .HasColumnName("qualification")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("register_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<SysUserGuns>(entity =>
            {
                entity.ToTable("sys_user_guns");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Avatar)
                    .HasColumnName("avatar")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deptid)
                    .HasColumnName("deptid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Roleid)
                    .HasColumnName("roleid")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("int(11)");
            });
        }
    }
}