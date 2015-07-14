using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudEmployeeApi.Models;
namespace CrudEmployeeApi.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetByID(int id);
        Employee Insert(Employee result);
        bool Update(Employee result);
        void Delete(int id);
    }
}