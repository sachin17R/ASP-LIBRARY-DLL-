//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeLib.DataClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
    
        public virtual Dept Dept { get; set; }
    }
}
