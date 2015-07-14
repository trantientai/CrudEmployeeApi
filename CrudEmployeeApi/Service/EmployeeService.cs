using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudEmployeeApi.Repository;
using CrudEmployeeApi.Models;

namespace CrudEmployeeApi.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeeService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.Get();
            if (employees.Any())
            {
                return employees;
            }
            return null;
        }

        public Employee GetByID(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByID(id);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        public int Insert(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Insert(employee);
            _unitOfWork.Save();
            return employee.EmployeeID;
        }

        public bool Update(int id, Employee employee)
        {
            if (employee != null)
            {
                var employeeItem = _unitOfWork.EmployeeRepository.GetByID(id);
                if (employeeItem != null)
                {
                    employeeItem.FirstName = employee.FirstName;
                    employeeItem.LastName = employee.LastName;
                    employeeItem.Address = employee.Address;
                    employeeItem.Phone = employee.Phone;
                    employeeItem.Email = employee.Email;
                    _unitOfWork.EmployeeRepository.Update(employeeItem);
                    _unitOfWork.Save();
                    return true;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetByID(id);
            if (employee != null)
            {
                _unitOfWork.EmployeeRepository.Delete(employee);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}