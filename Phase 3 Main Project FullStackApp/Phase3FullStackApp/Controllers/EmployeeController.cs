using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL_Lib;
using BLL_Lib;
using Phase3FullStackApp.Models; 

namespace Phase3FullStackApp.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>
        EmployeeProfile ms = null;
        public EmployeeController()
        {
            ms = new EmployeeProfile();
        }
        List<EmployeeModel> s = new List<EmployeeModel>();
        [Route("GetAllEmployeeDetails")]
        public IEnumerable<EmployeeModel> Get()
        {
            List<EmpProfile> c = ms.GetAllEmployeeDetails();
            foreach (var item in c)
            {
                EmployeeModel v = new EmployeeModel();
                v.EmpCode= item.EmpCode;
                v.DateOfBirth = item.DateOfBirth;
                v.EmpName = item.EmpName;
                v.Email = item.Email;
                v.DeptCode = item.DeptCode;
                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        [Route("GetAllEmployeeDetailsByCode/{id}")]
        public EmployeeModel Get(int id)
        {
            EmployeeModel r = new EmployeeModel();
            EmpProfile p = new EmpProfile();
            p = ms.GetAllEmployeeDetailsByCode(id);

            r.EmpCode = Convert.ToInt32(p.EmpCode);
            r.DateOfBirth = Convert.ToDateTime(p.DateOfBirth);
            r.EmpName = p.EmpName.ToString();
            r.Email = p.Email.ToString();
            r.DeptCode = Convert.ToInt32(p.DeptCode);
            return r;
        }

        // POST api/<controller>
        [Route("SavingEmployeeDetails")]
        public HttpResponseMessage Post([FromBody] EmployeeModel value)
        {
            EmpProfile r = new EmpProfile();
            r.EmpCode = value.EmpCode;
            r.DateOfBirth = value.DateOfBirth;
            r.EmpName = value.EmpName;
            r.Email = value.Email;
            r.DeptCode = value.DeptCode;

            bool k = ms.AddEmp(r);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // PUT api/<controller>/5
        [Route("UpdateEmployeeDetails/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] EmployeeModel value)
        {
            EmpProfile r = new EmpProfile();
            r.EmpCode = value.EmpCode;
            r.DateOfBirth = value.DateOfBirth;
            r.EmpName = value.EmpName;
            r.Email = value.Email;
            r.DeptCode = value.DeptCode;
            bool k = ms.UpdateEmployeeDetails(id, r);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
        [Route("DeleteEmployeeDetails/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = ms.DeleteEmployeeDetails(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}