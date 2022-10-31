using NUnit.Framework;
using System.Collections.Generic;
namespace OopsProjectTesting.Tests
{
    public class Test 
    {
        [Test]
        public void TestClass()
        {
            //Students s = new Students();
            //Teachers t = new Teachers();
            //Subjects su = new Subjects();

            List<Students> Studentslist = new List<Students>();
            Studentslist.Add(new Students() { StudentName = "Sahid", StudentClass = 10, StudentSection = "A" });
            Studentslist.Add(new Students() { StudentName = "Manoj", StudentClass = 11, StudentSection = "C" });

            List<Teachers> Teacherslist = new List<Teachers>();
            Teacherslist.Add(new Teachers() { TeacherName = "Rhea", TeacherClass = 10, TeacherSection = "A", TeachingSubject = "Physics" });
            Teacherslist.Add(new Teachers() { TeacherName = "Ramesh", TeacherClass = 11, TeacherSection = "C", TeachingSubject = "Maths" });

            List<Subjects> Subjectlist = new List<Subjects>();
            Subjectlist.Add(new Subjects() { SubjectName = "Maths", SubjectCode = "101A"});
            Subjectlist.Add(new Subjects() { SubjectName = "Physics", SubjectCode = "991B" });
        }
    }
}

