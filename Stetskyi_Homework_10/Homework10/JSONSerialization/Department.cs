using System;
using System.Collections.Generic;


namespace JSONSerialization
{
    [Serializable]
    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
        public Department(string departmentName)
        {
            DepartmentName = departmentName;
            Employees = new List<Employee>();
        }
        public Department()
        {
            DepartmentName = String.Empty;
            Employees = new List<Employee>();
        }
    }
}
