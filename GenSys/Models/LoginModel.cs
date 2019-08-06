using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace GenSys.Models
{
    public class LoginModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名不能为空")]
        public string username { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码不能为空")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^\w+$", ErrorMessage = "密码格式有误,只能是字母数字或者下划线")]
        public string password { get; set; }
        
        //[Display(Name = "记住登陆?")]
        //public bool rememberme { get; set; }

        public String Login()
        {
            gensysEntities db = new gensysEntities();
            var userResult = db.sys_user.Where(u => u.username == username).ToList();

            if (userResult.Count <= 0)
            {
                return "该用户名不存在！";
            }
            else if (userResult[0].password != password)
            {
                return "密码错误！";
            }
            else
                return "验证通过！";
        }

    }
}