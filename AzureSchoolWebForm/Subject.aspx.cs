using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using School_Helper;
using School_BAL;

namespace SchoolWebForm
{
    public partial class Subject : System.Web.UI.Page
    {
        SubjectsHelper cs = null;
        public Subject()
        {
            cs = new SubjectsHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SubjectsBAL> s = cs.ShowSubjectList();
            GridView1.DataSource = s;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SubjectsBAL s1 = new SubjectsBAL();
            s1.SubjectID = Convert.ToInt32(TextBox1.Text);
            s1.SubjectName = TextBox2.Text.ToString();
            s1.ClassID = Convert.ToInt32(TextBox3.Text);
            cs.AddSubject(s1);
            List<SubjectsBAL> s = cs.ShowSubjectList();
            GridView1.DataSource = s;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SubjectsBAL s1 = new SubjectsBAL();
            s1.SubjectID = Convert.ToInt32(TextBox1.Text);
            s1.SubjectName = TextBox2.Text.ToString();
            s1.ClassID = Convert.ToInt32(TextBox3.Text);
            cs.EditSubject(s1);
            List<SubjectsBAL> s = cs.ShowSubjectList();
            GridView1.DataSource = s;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SubjectsBAL s1 = new SubjectsBAL();
            s1.SubjectID = Convert.ToInt32(TextBox1.Text);
            s1.SubjectName = TextBox2.Text.ToString();
            s1.ClassID = Convert.ToInt32(TextBox3.Text);
            cs.RemoveSubject(s1.SubjectID);
            List<SubjectsBAL> s = cs.ShowSubjectList();
            GridView1.DataSource = s;
            GridView1.DataBind();

        }
    }
}