using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Helper;
using School_BAL;
using SchoolMVC.Models;

namespace SchoolMVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        StudentsHelper helper = null;
        public StudentsController()
        {
            helper = new StudentsHelper();
        }
        public ActionResult Index()
        {
            var list = helper.ShowStudentList();
            List<StudentsModel> modelsList = new List<StudentsModel>();
            foreach (var item in list)
            {
                modelsList.Add(new StudentsModel { StudentID = item.StudentID, StudentName = item.StudentName, ClassID = item.ClassID });
            }
            return View(modelsList);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var data = helper.SearchStudent(id);
            StudentsModel model = new StudentsModel();
            model.StudentID = id;
            model.StudentName = data.StudentName;
            model.ClassID = data.ClassID;

            return View(model);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                StudentsBAL bal = new StudentsBAL();
                bal.StudentID = Convert.ToInt32(Request["StudentID"]);
                bal.StudentName = Request["StudentName"].ToString();
                bal.ClassID = Convert.ToInt32(Request["ClassID"]);

                bool ans = helper.AddStudent(bal);
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

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var c = helper.SearchStudent(id);
            StudentsModel model = new StudentsModel();
            model.StudentID = id;
            model.StudentName = c.StudentName;
            model.ClassID = c.ClassID;

            return View(model);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var c = helper.SearchStudent(id);
                c.StudentID = Convert.ToInt32(Request["StudentID"]);
                c.StudentName = Request["StudentName"].ToString();
                c.ClassID = Convert.ToInt32(Request["ClassID"]);

                bool ans = helper.EditStudent(c);

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

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var c = helper.SearchStudent(id);
            StudentsModel model = new StudentsModel();
            model.StudentID = id;
            model.StudentName= c.StudentName;
            model.ClassID = c.ClassID;

            return View(model);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dataFound = helper.SearchStudent(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveStudent(id);
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
