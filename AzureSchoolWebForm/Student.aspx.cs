using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using School_BAL;
using School_Helper;

namespace SchoolWebForm
{
    public partial class Student : System.Web.UI.Page
    {
        StudentsHelper cs = null;
        public Student()
        {
            cs = new StudentsHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<StudentsBAL> s = cs.ShowStudentList();
            GridView1.DataSource = s;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            StudentsBAL s = new StudentsBAL();
            s.StudentID= Convert.ToInt32(TextBox1.Text);
            s.StudentName = TextBox2.Text.ToString();
            s.ClassID = Convert.ToInt32(TextBox3.Text);
            cs.AddStudent(s);
            List<StudentsBAL> sq = cs.ShowStudentList();
            GridView1.DataSource = sq;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            StudentsBAL s = new StudentsBAL();
            s.StudentID = Convert.ToInt32(TextBox1.Text);
            s.StudentName = TextBox2.Text.ToString();
            s.ClassID = Convert.ToInt32(TextBox3.Text);
            cs.EditStudent(s);
            List<StudentsBAL> sq = cs.ShowStudentList();
            GridView1.DataSource = sq;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            StudentsBAL s = new StudentsBAL();
            s.StudentID = Convert.ToInt32(TextBox1.Text);
            s.StudentName = TextBox2.Text.ToString();
            s.ClassID = Convert.ToInt32(TextBox3.Text);
            cs.RemoveStudent(s.StudentID);
            List<StudentsBAL> sq = cs.ShowStudentList();
            GridView1.DataSource = sq;
            GridView1.DataBind();

        }
    }
}