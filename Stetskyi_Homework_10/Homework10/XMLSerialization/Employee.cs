using System;


namespace XMLSerialization
{
    [Serializable]
    public class Employee
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
