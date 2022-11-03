using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerLoggerSupport.Models
{
    public class CustLogInfoModel
    {
        public int LogID{ get; set; }
        public string CustEmail { get; set; }
        public string CustName { get; set; }
        public string LogStatus { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
    }
}