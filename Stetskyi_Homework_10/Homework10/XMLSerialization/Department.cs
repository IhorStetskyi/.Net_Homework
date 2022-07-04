using System;
using System.Collections.Generic;


namespace XMLSerialization
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> employees;

        public Department(string name)
        {
            DepartmentName = name;
            employees = new List<Employee>();
        }
        public Department()
        {
            
        }

    }
}
