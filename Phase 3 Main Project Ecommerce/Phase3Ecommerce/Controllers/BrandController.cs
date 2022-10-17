using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DAL;
using Phase3Ecommerce.Models;

namespace Phase3Ecommerce.Controllers
{
    public class BrandController : Controller
    {
        brandmethods ms = null;
        // GET: Brand
        public BrandController()
        {
            ms = new brandmethods();
        }
        public List<lapmodel> ls()
        {
            List<lapmodel> ls = new List<lapmodel>();
            List<lapbrand> kl = ms.listallbrands();
            foreach (var item in kl)
            {
                ls.Add(new lapmodel
                {
                    lapid = item.brandid,
                    lapname = item.brandname

                });
            }
            return ls;
        }
        public ActionResult Index()
        {
            List<lapmodel> kt = ls();
            return View(kt);
        }

        // GET: Brand/Details/5
        public ActionResult Details(int id)
        {
            lapbrand ts = ms.findbrand(id);
            lapmodel m = new lapmodel();
            m.lapid = ts.brandid;
            m.lapname = ts.brandname;
            return View(m);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                lapbrand m = new lapbrand();
                m.brandid = Convert.ToInt32(Request["lapid"]);
                m.brandname = Request["lapname"].ToString();
                bool k = ms.addbrand(m);
                if (k)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int id)
        {
            lapbrand m = ms.findbrand(id);
            lapmodel t = new lapmodel();
            t.lapid = m.brandid;
            t.lapname = m.brandname;
            return View(t);
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                lapbrand m = new lapbrand();
                m.brandid = Convert.ToInt32(Request["lapid"]);
                m.brandname = Request["lapname"].ToString();
                bool k = ms.editbrand(id, m);
                if (k)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int id)
        {
            lapbrand m = ms.findbrand(id);
            lapmodel t = new lapmodel();
            t.lapid = m.brandid;
            t.lapname = m.brandname;
            return View(t);
        }

        // POST: Brand/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                int m = id;
                bool t = ms.removebrand(m);
                if (t)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
