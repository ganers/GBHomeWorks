using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    public class EmployeeController : ApiController
    {
        GetData getEmployees = new GetData();
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return getEmployees.GetEmployees(-1);
        }

        // GET: api/Employee/5
        public List<Employee> Get(int id)
        {
            return getEmployees.GetEmployees(id);
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
