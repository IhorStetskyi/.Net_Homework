using System;


namespace JSONSerialization
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
