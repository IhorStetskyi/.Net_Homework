using System;
using System.Collections.Generic;


namespace DeepCloning
{
    [Serializable]
    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> employees { get; set; }
        public Department(string departmentName)
        {
            DepartmentName = departmentName;
            employees = new List<Employee>();
        }
        public Department()
        {
            DepartmentName = String.Empty;
            employees = new List<Employee>();
        }
    }
}
