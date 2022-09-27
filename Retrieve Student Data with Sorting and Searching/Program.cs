using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Retrieve_Student_Data_with_Sorting_and_Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ps = @"S:\Apps\Dot Net\Retrieve Student Data with Sorting and Searching\StudentsData.txt";
            String[] lines = File.ReadAllLines(ps);

            List<Student> list = new List<Student>();
            for (int i = 0; i < lines.Length; i++)
            {
                string k = lines[i];
                char[] c = new char[] { '\t', ' ' };
                string[] man = k.Split(c, StringSplitOptions.RemoveEmptyEntries);
                Student s = new Student();
                s.Name = man[0];
                s.Class = Convert.ToInt32(man[1]);
                list.Add(s);
            }
        start:
            Console.Write("Menu: \n 1.Sort by Class\n 2.Sort by Name\n 3.Search by Name\n 4.Search By Class\n 5.Display Student Data\n 6.Exit \n");
            Console.WriteLine("Enter Choice:");
            int ch = Convert.ToInt32(Console.ReadLine());
           
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Sort by Class");
                    var par = list.OrderBy(q => q.Class).ToList();
                    foreach (Student s in par)
                    {
                        Console.Write($"{s.Name} studying in {s.Class}\n");
                    }
                    break;
                case 2:
                    Console.WriteLine("Sort by Name");
                    var par1 = list.OrderBy(q => q.Name).ToList();
                    foreach (Student s in par1)
                    {
                        Console.Write($"{s.Name} studying in {s.Class}\n");
                    }
                    break;
                case 3:
                    Console.WriteLine("Search by Name");
                    foreach (Student s in list)
                    {
                        Console.Write($"{s.Name} studying in {s.Class} \n");
                    }
                    Console.WriteLine("Enter Name to search");
                    string pr = Console.ReadLine();
                    var pit = list.Where(q => q.Name == pr).ToList();
                    if (pit != null)
                    {
                        foreach (Student s in pit)
                        {
                            Console.Write($"{s.Name} studying in {s.Class} \n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No students name found");
                    }
                    break;
                case 4:
                    Console.WriteLine("Search By Class");
                    foreach (Student s in list)
                    {
                        Console.Write($"{s.Name} studying in {s.Class} \n");
                    }
                    Console.WriteLine("Enter Class to search");
                    int pr1 = Convert.ToInt32(Console.ReadLine());
                    var pit1 = list.Where(q => q.Class == pr1).ToList();
                    if (pit1 != null)
                    {
                        foreach (Student s in pit1)
                        {
                            Console.Write($"{s.Name} studying in {s.Class}\n");
                        }

                    }
                    else
                    {
                        Console.WriteLine("No students in Class");
                    }
                    break;
                case 5:
                    Console.WriteLine("Display");
                    foreach (Student s in list)
                    {
                        Console.Write($"{s.Name} studying in {s.Class}  \n");
                    }
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter 'Y' or 'y' to Continue..");
            string pnt = Console.ReadLine();
            if (pnt == "Y" || pnt == "y")
            {
                goto start;
            }
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Class { get; set; }
    }
}
