using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_BAL;
using School_DAL;

namespace School_Helper
{
    public class ClassHelper
    {
        ClassDAL dal = null;
        public ClassHelper()
        {
            dal = new ClassDAL();
        }
        public bool AddClass(ClassBAL Class)
        {
            return dal.InsertClass(Class);
        }
        public bool EditClass(ClassBAL Class)
        {
            return dal.UpdateClass(Class);
        }
        public bool RemoveClass(int classid)
        {
            return dal.DeleteClass(classid);
        }
        public ClassBAL SearchClass(int classid)
        {
            return dal.FindClass(classid);
        }
        public void SearchClass(int classid, out ClassBAL data)
        {

            dal.FindClass(classid, out data);
        }
        public int countClass()
        {
            return dal.ClassCount();

        }
        public List<ClassBAL> ShowClassList()
        {
            return dal.ClassList();
        }
    }


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


    public class SubjectsHelper
    {
        SubjectsDAL dal = null;
        public SubjectsHelper()
        {
            dal = new SubjectsDAL();
        }
        public bool AddSubject(SubjectsBAL s)
        {
            return dal.InsertSubjects(s);
        }
        public bool EditSubject(SubjectsBAL s)
        {
            return dal.UpdateSubjects(s);
        }
        public bool RemoveSubject(int id)
        {
            return dal.DeleteSubjects(id);
        }
        public SubjectsBAL SearchSubject(int id)
        {
            return dal.FindSubjects(id);
        }
        public void SearchSubjects(int id, out SubjectsBAL data)
        {

            dal.FindSubjects(id, out data);
        }
        public int countSubject()
        {
            return dal.SubjectsCount();

        }
        public List<SubjectsBAL> ShowSubjectList()
        {
            return dal.SubjectsList();
        }
    }
}
