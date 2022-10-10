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
    public class SubjectsController : Controller
    {
        // GET: Subjects
        SubjectsHelper helper = null;
        public SubjectsController()
        {
            helper = new SubjectsHelper();
        }
        public ActionResult Index()
        {
            var list = helper.ShowSubjectList();
            List<SubjectsModel> modelsList = new List<SubjectsModel>();
            foreach (var item in list)
            {
                modelsList.Add(new SubjectsModel { SubjectID = item.SubjectID, SubjectName = item.SubjectName, ClassID = item.ClassID });
            }
            return View(modelsList);
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int id)
        {
            var data = helper.SearchSubject(id);
            SubjectsModel model = new SubjectsModel();
            model.SubjectID = id;
            model.SubjectName = data.SubjectName;
            model.ClassID = data.ClassID;

            return View(model);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                SubjectsBAL bal = new SubjectsBAL();
                bal.SubjectID = Convert.ToInt32(Request["SubjectID"]);
                bal.SubjectName = Request["SubjectName"].ToString();
                bal.ClassID = Convert.ToInt32(Request["ClassID"]);

                bool ans = helper.AddSubject(bal);
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

        // GET: Subjects/Edit/5
        public ActionResult Edit(int id)
        {
            var c = helper.SearchSubject(id);
            SubjectsModel model = new SubjectsModel();
            model.SubjectID = id;
            model.SubjectName = c.SubjectName;
            model.ClassID = c.ClassID;

            return View(model);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var c = helper.SearchSubject(id);
                c.SubjectID = Convert.ToInt32(Request["SubjectID"]);
                c.SubjectName= Request["SubjectName"].ToString();
                c.ClassID = Convert.ToInt32(Request["ClassID"]);

                bool ans = helper.EditSubject(c);

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

        // GET: Subjects/Delete/5
        public ActionResult Delete(int id)
        {
            var c = helper.SearchSubject(id);
            SubjectsModel model = new SubjectsModel();
            model.SubjectID= id;
            model.SubjectName = c.SubjectName;
            model.ClassID = c.ClassID;

            return View(model);
        }

        // POST: Subjects/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var dataFound = helper.SearchSubject(id);
                if (dataFound != null)
                {
                    bool ans = helper.RemoveSubject(id);
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
