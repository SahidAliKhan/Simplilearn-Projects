using CustomerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerLoggerSupport.Controllers
{
    public class CustomerController : Controller
    {
        ValidateUsers user = null;
        public CustomerController()
        {
            user = new ValidateUsers();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            bool valid = user.ValidateUser(Convert.ToInt32(Request["userid"]),Request["password"]);
            if (valid)
            {
                return RedirectToAction("CustomerLogger");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult CustomerLogger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogger(FormCollection collection)
        {
            CustLogInfo c = new CustLogInfo();
            c.LogID = Int32.Parse(Request["LogID"]);
            c.CustEmail = Request["CustEmail"];
            c.CustName = Request["CustName"];
            c.LogStatus = Request["LogStatus"];
            c.UserID = Int32.Parse(Request["UserId"]);
            c.Description = Request["Description"];
            user.Insert(c);
            ViewBag.Message = "Complaint is Registered Succesfully";
            return View();
            //return RedirectToAction("Index");
        }
    }
}