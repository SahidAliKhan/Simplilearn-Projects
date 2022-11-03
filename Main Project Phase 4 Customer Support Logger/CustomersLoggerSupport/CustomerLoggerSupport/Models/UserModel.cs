using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerLoggerSupport.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}