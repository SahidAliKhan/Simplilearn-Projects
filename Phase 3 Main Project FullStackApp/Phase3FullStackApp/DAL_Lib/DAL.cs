using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Lib
{
    public class DeptMaster
    {
        [Required()]
        [Key]
        public int DeptCode { get; set; }
        public string DeptName { get; set; }
        public virtual ICollection<EmpProfile> EmpProfiles { get; set; }
    }

    public class EmpProfile
    {
        [Required()]
        [Key]
        public int EmpCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public int DeptCode { get; set; }
        public virtual DeptMaster DeptMaster { get; set; }
    }
    public class MyContext: DbContext
    {
        //public MyContext(): base("MyContext")
        //{
        //    Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        //}   
        public virtual DbSet<DeptMaster> DeptMasters { get; set; }
        public virtual DbSet<EmpProfile> EmpProfiles { get; set; }
    }
    public class DeptMasterDbInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var depts = new List<DeptMaster> {
                new DeptMaster { DeptCode = 1, DeptName = "Sales"},
                new DeptMaster { DeptCode = 2, DeptName = "Manager" },
                new DeptMaster { DeptCode = 3, DeptName = "HR" },

            };
            depts.ForEach(s => context.DeptMasters.Add(s));
            context.SaveChanges();
        }
    }
}
