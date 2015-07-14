using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudEmployeeApi.Models;
using System.Web.Http;
using System.Net;
using System.Data;
namespace CrudEmployeeApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EntityContext _context;
        public EmployeeRepository(EntityContext context)
        {
            this._context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Take(100);
        }

        public Employee GetByID(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return employee;
        }

        public Employee Insert(Employee employee)
        {
            _context.Employees.Add(employee);
            return employee;
        }

        public bool Update(Employee employee)
        {
            var getEmployee = _context.Employees.Where(w => w.EmployeeID == employee.EmployeeID);
            if (getEmployee == null)
            {
                return false;
            }
            _context.Entry(employee).State = EntityState.Modified;
            return true;
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Employees.Remove(employee);
        }
    }
}