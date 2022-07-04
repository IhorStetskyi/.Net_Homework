using System;


namespace JSONSerialization
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
