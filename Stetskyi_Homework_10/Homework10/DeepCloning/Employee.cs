using System;


namespace DeepCloning
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
