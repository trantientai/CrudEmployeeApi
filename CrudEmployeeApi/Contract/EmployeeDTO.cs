using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudEmployeeApi.Contract
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}