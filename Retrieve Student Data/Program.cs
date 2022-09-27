using System;
using File = System.IO.File;

namespace Retrieve_Student_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"S:\Apps\Dot Net\Retrieve Student Data\studentfile.txt";
            Console.WriteLine("Students data from a text file: ");
            if (File.Exists(path))
            {
                string str = File.ReadAllText(path);
                Console.WriteLine(str);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
