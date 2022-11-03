using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDAL
{
    public class ValidateUsers
    {
        CustomerDBEntities Context = null;
        public ValidateUsers()
        {
            Context = new CustomerDBEntities();
        }
        public bool ValidateUser(int userid, string password)
        {
            bool ans = false;
            var find = Context.UserInfoes.ToList();
            var find2 = find.Find(x => x.UserID == userid);

            if (find2 != null)
            {
                if (find2.Password == password)
                {
                    ans = true;
                }
            }
            return ans;
        }
        public bool Insert(CustLogInfo c)
        {
            bool ans = true;
            try
            {
                Context.CustLogInfoes.Add(c);
                Context.SaveChanges();
                return ans;
            }
            catch (Exception)
            {
                ans = false;
                return ans;
            }
        }
    }
}
