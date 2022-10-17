using BAL;
using DAL;
using Phase3Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phase3Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        loginmethods ls = null;
        brandmethods ms = null;
        ordermethods os = null;

        public OrderController()
        {
            ls = new loginmethods();
            ms = new brandmethods();
            os = new ordermethods();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            logintable t = new logintable();
            t.customerid = Convert.ToInt32(Request["custid"]);
            t.customername = Request["custname"].ToString();
            TempData["Cid"] = t.customerid;
            bool k = ls.checklogin(t);
            if (k)
            {
                return RedirectToAction("Laplist");
            }
            else
            {
                return RedirectToAction("SignUp");
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection c)
        {
            logintable t = new logintable();
            t.customerid = Convert.ToInt32(Request["custid"]);
            t.customername = Request["custname"].ToString();
            bool k = ls.addlogin(t);
            if (k)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }

        }
        public ActionResult LapList()
        {
            List<lapbrand> mt = ms.listallbrands();
            List<lapmodel> tm = new List<lapmodel>();
            foreach (var item in mt)
            {
                tm.Add(new lapmodel
                {
                    lapid = item.brandid,
                    lapname = item.brandname
                });
            }
            return View(tm);

        }
        public ActionResult Previousorders()
        {
            int k = Convert.ToInt32(TempData["Cid"]);
            TempData["Cid"] = k;
            List<ordermodel> lt = new List<ordermodel>();
            List<placedorder> lm = os.listbycustid(k);
            foreach (var item in lm)
            {
                ordermodel k1 = new ordermodel();
                k1.orderid = Convert.ToInt32(item.issueid);
                k1.lapid = Convert.ToInt32(item.brandid);
                k1.custid = Convert.ToInt32(item.customerid);
                k1.orderdate = Convert.ToDateTime(item.orderdate);
                if (item.receiveddate != null)
                {
                    k1.receivedate = Convert.ToDateTime(item.receiveddate);
                }
                else
                {
                    k1.receivedate = null;
                }
                k1.comments = item.comments;

                lt.Add(k1);
            }
            return View(lt);

        }
        public ActionResult AddtoCart(int id)
        {
            ordermodel m = new ordermodel();
            m.custid = Convert.ToInt32(TempData["Cid"]);
            TempData["Cid"] = m.custid;
            m.lapid = id;

            return View(m);
        }
        [HttpPost]
        public ActionResult AddtoCart(FormCollection c)
        {
            placedorder m = new placedorder();
            m.issueid = Convert.ToInt32(Request["orderid"]);
            m.customerid = Convert.ToInt32(Request["custid"]);
            m.brandid = Convert.ToInt32(Request["lapid"]);
            m.orderdate = Convert.ToDateTime(Request["orderdate"]);
            if (Request["receivedate"] == "")
            {
                m.receiveddate = null;
            }
            else
            {
                m.receiveddate = Convert.ToDateTime(Request["receivedate"]);

            }
            m.comments = Request["comments"].ToString();
            bool k = os.addorder(m);
            if (k)
            {
                return RedirectToAction("Previousorders");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            bool k = os.removeorder(id);
            return RedirectToAction("Previousorders");
        }

    }
}
