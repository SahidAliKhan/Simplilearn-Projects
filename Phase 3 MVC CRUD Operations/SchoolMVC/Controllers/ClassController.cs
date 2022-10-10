using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Helper;
using School_BAL;
using SchoolMVC.Models;
using System.Linq.Expressions;

namespace SchoolMVC.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        ClassHelper helper = null;
        public ClassController()
        {
            helper = new ClassHelper();
        }

        public ActionResult Index()
        {
            var list = helper.ShowClassList();
            List<ClassModel> modelsList = new List<ClassModel>();
            foreach (var item in list)
            {
                modelsList.Add(new ClassModel { ClassID = item.ClassID, ClassName = item.ClassName });
            }
            return View(modelsList);
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            var data = helper.SearchClass(id);
            ClassModel model = new ClassModel();
            model.ClassID = id;
            model.ClassName = data.ClassName;

            return View(model);
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                ClassBAL bal = new ClassBAL();
                bal.ClassID = Convert.ToInt32(Request["ClassID"]);
                bal.ClassName = Request["ClassName"].ToString();
                
                bool ans = helper.AddClass(bal);
                if (ans)
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

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            var c = helper.SearchClass(id);
            ClassModel model = new ClassModel();
            model.ClassID = id;
            model.ClassName = c.ClassName;

            return View(model);
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var c = helper.SearchClass(id);
                c.ClassID = Convert.ToInt32(Request["ClassID"]);
                c.ClassName= Request["ClassName"].ToString();
               
                bool ans = helper.EditClass(c);

                if (ans)
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

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            var c = helper.SearchClass(id);
            ClassModel model = new ClassModel();
            model.ClassID = id;
            model.ClassName = c.ClassName;
        
            return View(model);
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dataFound = helper.SearchClass(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveClass(id);
                    if (ans)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
