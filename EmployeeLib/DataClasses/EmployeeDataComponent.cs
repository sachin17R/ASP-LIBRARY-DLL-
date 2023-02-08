using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.DataClasses
{
    public class EmployeeDataComponent : IDataClasses
    {

        private EmployeeDBEntities _context = new EmployeeDBEntities();
        public void AddNewEmployee(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int empId)
        {
            var selected = _context.Employees.FirstOrDefault((e) => e.EmpId == empId);
            if (selected != null)
            {
                _context.Employees.Remove(selected);
                _context.SaveChanges();
            }
            else
                throw new Exception("Employee Id Not Found To Delete");
        }

        public Employee FindEmp(int id)
        {
            var selected = _context.Employees.FirstOrDefault((p) => p.EmpId == id);
            return selected;
        }
        public List<Dept> GetAllDept()
        {
            return _context.Depts.ToList();
        }

        public List<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public void UpdateEmployee(Employee emp)
        {
            var selected = _context.Employees.FirstOrDefault((e) => e.EmpId == emp.EmpId);
            if (selected != null)
            {
                selected.EmpName = emp.EmpName;
                selected.Address = emp.Address;
                selected.Salary = emp.Salary;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Employee Id Not Found to Update");
            }
        }
    }
}
