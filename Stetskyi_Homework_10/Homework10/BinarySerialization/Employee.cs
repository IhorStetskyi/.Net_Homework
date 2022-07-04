using System;


namespace BinarySerialization
{
    [Serializable]
    class Employee
    {
        public string EmployeeName { get; set; }

        public Employee(string name)
        {
            EmployeeName = name;
        }
    }
}
