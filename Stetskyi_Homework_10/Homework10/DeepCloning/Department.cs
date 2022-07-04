using System;
using System.Collections.Generic;


namespace DeepCloning
{
    [Serializable]
    class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> employees;

        public Department(string name)
        {
            DepartmentName = name;
            employees = new List<Employee>();
        }
    }
}
