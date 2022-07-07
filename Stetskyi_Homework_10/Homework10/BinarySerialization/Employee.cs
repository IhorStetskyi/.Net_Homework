using System;


namespace BinarySerialization
{
    [Serializable]
    class Employee
    {
        public string EmployeeName { get; set; }
        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }
        public Employee()
        {
            EmployeeName = String.Empty;
        }
    }
}
