using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.DataClasses
{
    interface IDataClasses
    {
        void AddNewEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int empId);
        List<Employee> GetAllEmployee();
        List<Dept> GetAllDept();
        Employee FindEmp(int id);
    }
}
