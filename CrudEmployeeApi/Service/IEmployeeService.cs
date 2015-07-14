using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudEmployeeApi.Models;
using CrudEmployeeApi.Repository;

namespace CrudEmployeeApi.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetByID(int id);
        int Insert(Employee employee);
        bool Update(int id, Employee employee);
        bool Delete(int id);
    }
}
