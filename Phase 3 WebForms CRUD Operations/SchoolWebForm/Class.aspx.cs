using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using School_BAL;
using School_Helper;

namespace SchoolWebForm
{
    public partial class Class : System.Web.UI.Page
    {
        ClassHelper c = null;
        public Class()
        {
            c = new ClassHelper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ClassBAL> s = c.ShowClassList();
            GridView3.DataSource = s;
            GridView3.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClassBAL c1 = new ClassBAL();
            c1.ClassID = Convert.ToInt32(TextBox1.Text);
            c1.ClassName = TextBox2.Text.ToString();
            c.AddClass(c1);
            List<ClassBAL> s = c.ShowClassList();
            GridView3.DataSource = s;
            GridView3.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ClassBAL c1 = new ClassBAL();
            c1.ClassID = Convert.ToInt32(TextBox1.Text);
            c1.ClassName = TextBox2.Text.ToString();
            c.EditClass(c1);
            List<ClassBAL> s = c.ShowClassList();
            GridView3.DataSource = s;
            GridView3.DataBind();

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ClassBAL c1 = new ClassBAL();
            c1.ClassID = Convert.ToInt32(TextBox1.Text);
            c1.ClassName = TextBox2.Text.ToString();
            c.RemoveClass(c1.ClassID);
            List<ClassBAL> s = c.ShowClassList();
            GridView3.DataSource = s;
            GridView3.DataBind();

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}