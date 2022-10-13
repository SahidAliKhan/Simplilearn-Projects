using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using School_Helper;
using School_BAL;
using SchoolWebAPI.Models;

namespace SchoolWebAPI.Controllers
{
    public class SchoolController : ApiController
    {
        // GET api/<controller>
        StudentsHelper helper = null;
        public SchoolController()
        {
            helper = new StudentsHelper();
        }
        public List<StudentModel> GetStudentMarks()
        {
            List<StudentsBAL> bal = new List<StudentsBAL>();
            bal = helper.ShowStudentList();
            List<StudentModel> list = new List<StudentModel>();
            foreach (var item in bal)
            {
                //Employees emp = new Employees();
                list.Add(new StudentModel
                {
                    StudentID = item.StudentID,
                    StudentName = item.StudentName,
                    ClassID = item.ClassID,
                    SubjectName = item.SubjectName,
                    Marks = Convert.ToInt32(item.Marks)
                }) ;
            }
            return list;
        }

        // GET api/<controller>/5
        public StudentModel GetStudentMarksByID(int id)
        {
            StudentsBAL bal = new StudentsBAL();
            bal = helper.SearchStudent(id);
            StudentModel emp = new StudentModel();
            emp.StudentID = bal.StudentID;
            emp.StudentName = bal.StudentName;
            emp.ClassID = bal.ClassID;
            emp.SubjectName = bal.SubjectName;
            emp.Marks = Convert.ToInt32(bal.Marks);
            return emp;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] StudentModel bal)
        {
            StudentsBAL emp = new StudentsBAL();
            emp.StudentID = bal.StudentID;
            emp.StudentName = bal.StudentName;
            emp.ClassID = bal.ClassID;
            emp.SubjectName = bal.SubjectName;
            emp.Marks = bal.Marks;


            bool ans = helper.AddStudent(emp);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] StudentModel bal)
        {
            StudentsBAL emp = new StudentsBAL();
            emp.StudentID = bal.StudentID;
            emp.StudentName = bal.StudentName;
            emp.ClassID = bal.ClassID;
            emp.SubjectName = bal.SubjectName;
            emp.Marks = bal.Marks;

            bool ans = helper.EditStudent(emp);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        //DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            bool ans = helper.RemoveStudent(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}