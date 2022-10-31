using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsProjectTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no of Students:");
            int n = Convert.ToInt32(Console.ReadLine());
            Students[] s1 = new Students[n];

            Console.WriteLine("Enter no of Teachers:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Teachers[] t1 = new Teachers[n1];

            Console.WriteLine("Enter no of Subjects:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Subjects[] su1 = new Subjects[n2];

            Console.WriteLine("----");
            for (int i = 0; i < n; i++)
            {
                Students s = new Students();
                s.AcceptStudentsData();
                s1[i] = s;
                Console.WriteLine("----");
            }

            for (int i = 0; i < n1; i++)
            {
                Teachers t = new Teachers();
                t.AcceptTeachersData();
                t1[i] = t;
                Console.WriteLine("----");
            }
            for (int i = 0; i < n2; i++)
            {
                Subjects su = new Subjects();
                su.AcceptSubjectsData();
                su1[i] = su;
                Console.WriteLine("----");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter 'Y' or 'y'to Display Data:  ");
            string s2 = Console.ReadLine();
            if (s2 == "y" || s2 == "Y")
            {
                for (int i = 0; i < n; i++)
                {
                    s1[i].DisplayStudentsData();
                    Console.WriteLine("----");
                }
                for (int i = 0; i < n1; i++)
                {
                    t1[i].DisplayTeachersData();
                    Console.WriteLine("----");
                }
                for (int i = 0; i < n2; i++)
                {
                    su1[i].DisplaySubjectsData();
                    Console.WriteLine("----");
                }
            }
            else
            {
                Console.WriteLine("Please enter Y or y only....");
            }


            Console.ReadLine();
        }
    }
    public class Students
    {
        public string StudentName { get; set; }
        public int StudentClass { get; set; }
        public string StudentSection { get; set; }
        public void AcceptStudentsData()
        {
            Console.WriteLine("Enter Student Name: ");
            StudentName = Console.ReadLine();
            Console.WriteLine("Enter Student Class: ");
            StudentClass = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Section: ");
            StudentSection = Console.ReadLine();
        }
        public void DisplayStudentsData()
        {
            Console.WriteLine("Student Name: " + StudentName);
            Console.WriteLine("Student Class: " + StudentClass);
            Console.WriteLine("Student Section : " + StudentSection);
        }
    }
    public class Teachers
    {
        public string TeacherName { get; set; }
        public int TeacherClass { get; set; }
        public string TeacherSection { get; set; }
        public string TeachingSubject { get; set; }
        public void AcceptTeachersData()
        {
            Console.WriteLine("Enter Teacher Name: ");
            TeacherName = Console.ReadLine();
            Console.WriteLine("Enter Teaching Class: ");
            TeacherClass = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Teaching Section: ");
            TeacherSection = Console.ReadLine();
            Console.WriteLine("Enter Teaching Subject: ");
            TeachingSubject = Console.ReadLine();
        }
        public void DisplayTeachersData()
        {
            Console.WriteLine("Teacher Name: " + TeacherName);
            Console.WriteLine("Teacher Class: " + TeacherClass);
            Console.WriteLine("Teacher Section: " + TeacherSection);
            Console.WriteLine("Teaching Subject: " + TeachingSubject);
        }
    }
    public class Subjects
    {
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public void AcceptSubjectsData()
        {
            Console.WriteLine("Enter Subject Name:");
            SubjectName = Console.ReadLine();
            Console.WriteLine("Enter Subject Code:");
            SubjectCode = Console.ReadLine();
        }
        public void DisplaySubjectsData()
        {
            Console.WriteLine("Subject Name: " + SubjectName);
            Console.WriteLine("Subject Code: " + SubjectCode);
        }
    }
}
