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
    public class ClassDAL
    {
        public bool InsertClass(ClassBAL Class)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdInsert = new SqlCommand("insert into class(classid,classname) values(@classid,@classname)", cn);
            cmdInsert.Parameters.AddWithValue("@classid", Class.ClassID);
            cmdInsert.Parameters.AddWithValue("@classname", Class.ClassName);

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
        public int ClassCount()
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmd = new SqlCommand("select count(*) from Class", cn);
            cn.Open();

            int cnt = (int)cmd.ExecuteScalar();
            cn.Close();
            cn.Dispose();
            return cnt;
        }
        public bool UpdateClass(ClassBAL Class)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[sp_UpdateClass]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.Parameters.AddWithValue("@p_classid", Class.ClassID);
            cmdUpdate.Parameters.AddWithValue("@p_classname", Class.ClassName);

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
        public bool DeleteClass(int classid)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdDelete = new SqlCommand("[dbo].[sp_DeleteClass]", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_classid", classid);
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
        public ClassBAL FindClass(int classid)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindClass]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_classid", classid);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_classname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 5;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            ClassBAL found = new ClassBAL();

            found.ClassName = p1.Value.ToString();
            cn.Close();
            cn.Dispose();
            return found;
        }
        public void FindClass(int classid, out ClassBAL data)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindClass]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_classid", classid);
            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_classname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 5;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            data = new ClassBAL();

           data.ClassName = p1.Value.ToString();

            ClassBAL edata = new ClassBAL();
            edata = data;

            cn.Close();
            cn.Dispose();
        }
        public List<ClassBAL> ClassList()
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            //SqlCommand cmdlist = new SqlCommand("select * from  [dbo].[fn_Classlist]()", cn);
            SqlCommand cmdlist = new SqlCommand("select * from Class", cn);

            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<ClassBAL> list = new List<ClassBAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ClassBAL bal = new ClassBAL();
                    bal.ClassID= Convert.ToInt32(dr["ClassID"]);
                    bal.ClassName = dr["ClassName"].ToString();

                   list.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return list;
        }
    }


    //==============================================================
    public class StudentsDAL
    {
        public bool InsertStudent(StudentsBAL s)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdInsert = new SqlCommand("insert into students(studentid,studentname,classid) values(@studentid,@studentname,@classid)", cn);
            cmdInsert.Parameters.AddWithValue("@studentid", s.StudentID);
            cmdInsert.Parameters.AddWithValue("@studentname", s.StudentName);
            cmdInsert.Parameters.AddWithValue("@classid", s.ClassID);

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
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmd = new SqlCommand("select count(*) from Students", cn);
            cn.Open();

            int cnt = (int)cmd.ExecuteScalar();
            cn.Close();
            cn.Dispose();
            return cnt;
        }
        public bool UpdateStudent(StudentsBAL s)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[sp_UpdateStudents]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;

            cmdUpdate.Parameters.AddWithValue("@p_studentid", s.StudentID);
            cmdUpdate.Parameters.AddWithValue("@p_studentname", s.StudentName);
            cmdUpdate.Parameters.AddWithValue("@p_classid", s.ClassID);

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
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

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
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindStudents]", cn);
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

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            StudentsBAL f = new StudentsBAL();

            f.StudentName = p1.Value.ToString();
            f.ClassID = Convert.ToInt32(p2.Value);
            cn.Close();
            cn.Dispose();
            return f;
        }
        public void FindStudent(int id, out StudentsBAL data)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindStudents]", cn);
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

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            data = new StudentsBAL();

            data.StudentName = p1.Value.ToString();
            data.ClassID = Convert.ToInt32(p2.Value);

            StudentsBAL edata = new StudentsBAL();
            edata = data;

            cn.Close();
            cn.Dispose();
        }
        public List<StudentsBAL> StudentList()
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdlist = new SqlCommand("select * from Students", cn);
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

                    list.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return list;
        }
    }
    //==============================================================

    public class SubjectsDAL
    {
        public bool InsertSubjects(SubjectsBAL s)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdInsert = new SqlCommand("insert into subjects(subjectid,subjectname,classid) values(@subjectid,@subjectname,@classid)", cn);
            cmdInsert.Parameters.AddWithValue("@subjectid", s.SubjectID);
            cmdInsert.Parameters.AddWithValue("@subjectname", s.SubjectName);
            cmdInsert.Parameters.AddWithValue("@classid", s.ClassID);

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
        public int SubjectsCount()
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmd = new SqlCommand("select count(*) from Subjects", cn);
            cn.Open();

            int cnt = (int)cmd.ExecuteScalar();
            cn.Close();
            cn.Dispose();
            return cnt;
        }
        public bool UpdateSubjects(SubjectsBAL s)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdUpdate = new SqlCommand("[dbo].[sp_UpdateSubjects]", cn);

            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;

            cmdUpdate.Parameters.AddWithValue("@p_subjectid", s.SubjectID);
            cmdUpdate.Parameters.AddWithValue("@p_subjectname", s.SubjectName);
            cmdUpdate.Parameters.AddWithValue("@p_classid", s.ClassID);

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
        public bool DeleteSubjects(int id)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdDelete = new SqlCommand("[dbo].[sp_DeleteSubjects]", cn);
            cmdDelete.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@p_subjectid", id);
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
        public SubjectsBAL FindSubjects(int id)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindSubjects]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_subjectid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_subjectname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 50;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_classid";
            p2.SqlDbType = System.Data.SqlDbType.NVarChar;
            p2.Size = 4;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            SubjectsBAL f = new SubjectsBAL();

            f.SubjectName = p1.Value.ToString();
            f.ClassID = Convert.ToInt32(p2.Value);
            cn.Close();
            cn.Dispose();
            return f;
        }
        public void FindSubjects(int id, out SubjectsBAL data)
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdSelect = new SqlCommand("[dbo].[sp_FindSubjects]", cn);
            cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("@p_subjectid", id);

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@p_subjectname";
            p1.SqlDbType = System.Data.SqlDbType.NVarChar;
            p1.Size = 50;
            p1.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@p_classid";
            p2.SqlDbType = System.Data.SqlDbType.NVarChar;
            p2.Size = 4;
            p2.Direction = System.Data.ParameterDirection.Output;
            cmdSelect.Parameters.Add(p2);

            cn.Open();
            cmdSelect.ExecuteNonQuery();

            data = new SubjectsBAL();

            data.SubjectName = p1.Value.ToString();
            data.ClassID = Convert.ToInt32(p2.Value);

            SubjectsBAL edata = new SubjectsBAL();
            edata = data;

            cn.Close();
            cn.Dispose();
        }
        public List<SubjectsBAL> SubjectsList()
        {
            SqlConnection cn = new SqlConnection("Server = tcp:schoolserver.database.windows.net,1433; Initial Catalog = Rainbow_School; Persist Security Info = False; User ID = sahidxb; Password = Hello@123456; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

            SqlCommand cmdlist = new SqlCommand("select * from Subjects", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<SubjectsBAL> list = new List<SubjectsBAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    SubjectsBAL bal = new SubjectsBAL();
                    bal.SubjectID = Convert.ToInt32(dr["SubjectID"]);
                    bal.SubjectName = dr["SubjectName"].ToString();
                    bal.ClassID = Convert.ToInt32(dr["ClassID"]);

                    list.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return list;
        }
    }


}
