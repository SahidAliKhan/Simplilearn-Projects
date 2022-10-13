using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_BAL;

namespace School_DAL
{
    public class StudentsDAL
    {
        public bool InsertStudent(StudentsBAL s)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);

            SqlCommand cmdInsert = new SqlCommand("insert into students(studentid,studentname,classid,subjectname,marks) values(@studentid,@studentname,@classid,@subjectname,@marks)", cn);
            cmdInsert.Parameters.AddWithValue("@studentid", s.StudentID);
            cmdInsert.Parameters.AddWithValue("@studentname", s.StudentName);
            cmdInsert.Parameters.AddWithValue("@classid", s.ClassID);
            cmdInsert.Parameters.AddWithValue("@subjectname", s.SubjectName);
            cmdInsert.Parameters.AddWithValue("@marks", s.Marks);

            cn.Open();
            int i = cmdInsert.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;
        }
        public int StudentCount()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);

            SqlCommand cmd = new SqlCommand("select count(*) from Students", cn);
            cn.Open();

            int cnt = (int)cmd.ExecuteScalar();
            cn.Close();
            cn.Dispose();
            return cnt;
        }
        public bool UpdateStudent(StudentsBAL s)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[sp_UpdateStudentMarks]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;

            cmdUpdate.Parameters.AddWithValue("@p_studentid", s.StudentID);
            cmdUpdate.Parameters.AddWithValue("@p_studentname", s.StudentName);
            cmdUpdate.Parameters.AddWithValue("@p_classid", s.ClassID);
            cmdUpdate.Parameters.AddWithValue("@p_subjectname", s.SubjectName);
            cmdUpdate.Parameters.AddWithValue("@p_marks", s.Marks);

            cn.Open();
            int i = cmdUpdate.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;
        }
        public bool DeleteStudent(int id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);

            SqlCommand cmdDelete = new SqlCommand("[dbo].[sp_DeleteStudents]", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_studentid", id);
            cn.Open();
            int i = cmdDelete.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            return status;
        }
        public StudentsBAL FindStudent(int id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_FindStudentsMarks", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_studentid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_studentname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 20;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_classid";
            p2.SqlDbType = System.Data.SqlDbType.NVarChar;
            p2.Size = 4;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@p_subjectname";
            p3.SqlDbType = System.Data.SqlDbType.NVarChar;
            p3.Size = 20;
            p3.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@p_marks";
            p4.SqlDbType = System.Data.SqlDbType.NVarChar;
            p4.Size = 4;
            p4.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p4);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            StudentsBAL f = new StudentsBAL();

            f.StudentName = p1.Value.ToString();
            f.ClassID = Convert.ToInt32(p2.Value);
            f.SubjectName = p3.Value.ToString();
            f.Marks = Convert.ToInt32(p4.Value);
            cn.Close();
            cn.Dispose();
            return f;
        }
        public void FindStudent(int id, out StudentsBAL data)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);
            SqlCommand cmdSelect = new SqlCommand("[dbo].sp_FindStudentsMarks", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_studentid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_studentname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 20;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_classid";
            p2.SqlDbType = System.Data.SqlDbType.NVarChar;
            p2.Size = 4;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "@p_subjectname";
            p3.SqlDbType = System.Data.SqlDbType.NVarChar;
            p3.Size = 20;
            p3.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "@p_marks";
            p4.SqlDbType = System.Data.SqlDbType.NVarChar;
            p4.Size = 4;
            p4.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p4);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            data = new StudentsBAL();

            data.StudentName = p1.Value.ToString();
            data.ClassID = Convert.ToInt32(p2.Value);
            data.SubjectName = p3.Value.ToString();
            data.Marks = Convert.ToInt32(p4.Value);

            StudentsBAL edata = new StudentsBAL();
            edata = data;

            cn.Close();
            cn.Dispose();
        }
        public List<StudentsBAL> StudentList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["RSCnString"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  [dbo].[fn_StudentsMarks]()", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<StudentsBAL> list = new List<StudentsBAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    StudentsBAL bal = new StudentsBAL();
                    bal.StudentID = Convert.ToInt32(dr["StudentID"]);
                    bal.StudentName= dr["StudentName"].ToString();
                    bal.ClassID = Convert.ToInt32(dr["ClassID"]);
                    bal.SubjectName = dr["SubjectName"].ToString();
                    //bal.Marks = Convert.ToInt32(dr["Marks"]);
                    //Convert.ToInt32(dr["Marks"]);

                    if (dr["Marks"] is DBNull)
                    {
                        bal.Marks = null;
                    }
                    else
                    {
                        bal.Marks = Convert.ToInt32(dr["Marks"]);
                    }

                    list.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return list;
        }
    }
}
