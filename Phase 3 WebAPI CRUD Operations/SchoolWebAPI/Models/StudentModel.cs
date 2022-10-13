using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace SchoolWebAPI.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int ClassID { get; set; }
        public string SubjectName { get; set; }
        public int? Marks { get; set; }
    }
}