using Employees.Business;
using Employees.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiEmployees.Controllers
{
    public class EmployeeMaintenanceController : ApiController
    {
        [HttpGet]
        [Route("Saludo")]
        public string Hola()
        {
            return "Hola mundo";
        }
        public IEnumerable<string> GetVersionApp()
        {
            return new string[] { "version1.0" };
        }

        // GET: api/Employee/5
        [HttpGet]
        [Route("GetListEmployee")]
        public async Task<HttpResponseMessage> GettEmployee(int employeenumber)
        {
            var response = await new LogicEmployees().GetEmployee(employeenumber);
            return Request.CreateResponse((HttpStatusCode)response.Code, response);
        }

        // POST: api/Employee
        [HttpPost]
        [Route("Post/Employee")]
        public async Task<HttpResponseMessage> AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var response = await new LogicEmployees().AddEmployee(employee);
                return Request.CreateResponse((HttpStatusCode)response.Code, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is required from the new employee");
            }
        }


        [HttpPut]
        [Route("Update/Employee")]
        public async Task<HttpResponseMessage> UpdateEmployee(Employee employee)
        {
            var response = await new LogicEmployees().UpdateEmployee(employee);
            return Request.CreateResponse((HttpStatusCode)response.Code, response);
        }
        [HttpDelete]
        [Route("Delete/Employee")]
        public async Task<HttpResponseMessage> DeleteEmployee(int employeenumber)
        {
            var response = await new LogicEmployees().DeleteEmployee(employeenumber);
            return Request.CreateResponse((HttpStatusCode)response.Code, response);
        }
    }
}
