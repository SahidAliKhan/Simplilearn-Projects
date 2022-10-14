using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Lib;

namespace BLL_Lib
{
    public class EmployeeProfile
    {
        MyContext context = null;
        public EmployeeProfile()
        {
            context = new MyContext();

        }
        public bool AddEmp(EmpProfile p)
        {
            try
            {
                context.EmpProfiles.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteEmployeeDetails(int id)
        {
            try
            {

                List<EmpProfile> s = context.EmpProfiles.ToList();
                EmpProfile r = s.Find(pr => pr.EmpCode == id);

                context.EmpProfiles.Remove(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public EmpProfile GetAllEmployeeDetailsByCode(int id)
        {
            List<EmpProfile> s = context.EmpProfiles.ToList();
            EmpProfile r = s.Find(pr => pr.EmpCode == id);
            return r;
        }
        public List<EmpProfile> GetAllEmployeeDetails()
        {
            return context.EmpProfiles.ToList();
        }
        public bool UpdateEmployeeDetails(int id, EmpProfile p)
        {
            try
            {

                List<EmpProfile> s = context.EmpProfiles.ToList();
                EmpProfile k = s.Find(pr => pr.EmpCode == id);

                k.EmpCode= p.EmpCode;
                k.DateOfBirth = p.DateOfBirth;
                k.EmpName = p.EmpName;
                k.Email = p.Email;
                k.DeptCode = p.DeptCode;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;


            }
        }
    }
}
