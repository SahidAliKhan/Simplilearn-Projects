using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_BAL;
using School_DAL;

namespace School_Helper
{
    public class StudentsHelper
    {
        StudentsDAL dal = null;
        public StudentsHelper()
        {
            dal = new StudentsDAL();
        }
        public bool AddStudent(StudentsBAL s)
        {
            return dal.InsertStudent(s);
        }
        public bool EditStudent(StudentsBAL s)
        {
            return dal.UpdateStudent(s);
        }
        public bool RemoveStudent(int id)
        {
            return dal.DeleteStudent(id);
        }
        public StudentsBAL SearchStudent(int id)
        {
            return dal.FindStudent(id);
        }
        public void SearchStudent(int id, out StudentsBAL data)
        {

            dal.FindStudent(id, out data);
        }
        public int countStudent()
        {
            return dal.StudentCount();

        }
        public List<StudentsBAL> ShowStudentList()
        {
            return dal.StudentList();
        }
    }
}
