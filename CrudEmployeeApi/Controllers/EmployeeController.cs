using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudEmployeeApi.Models;
using CrudEmployeeApi.Service;
namespace CrudEmployeeApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        public HttpResponseMessage Get()
        {
            var employees = _employeeService.GetAll();
            if (employees.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, employees);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employees not found");
        }

        public HttpResponseMessage Get(int id)
        {
            var employee = _employeeService.GetByID(id);
            if (employee != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, employee);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No employee found for this id");
        }

        public int Post([FromBody] Employee employee)
        {
            return _employeeService.Insert(employee);
        }

        public bool Put(int id, [FromBody] Employee employee)
        {
            if (id > 0)
            {
                return _employeeService.Update(id, employee);
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (id>0)
            {
                return _employeeService.Delete(id);
            }
            return false;
        }
    }
}
