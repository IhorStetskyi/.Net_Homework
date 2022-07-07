using Sources;
using System;

namespace JSONSerialization
{
    class Program
    {
        private const string newtonJsonPath = @"../../../../FolderToSaveFile/JSON.txt";
        private const string jsonPath = @"../../../../FolderToSaveFile/JSON_Bad.txt";
        static void Main(string[] args)
        {
            Department department = new Department("JSON Department");

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");

            department.employees.Add(emp1);
            department.employees.Add(emp2);
            department.employees.Add(emp3);

            DataSerializer dataSerializer = new DataSerializer();

            dataSerializer.JSONSerializeNewtonsoft(department, newtonJsonPath);
            dataSerializer.JSONSerialize(department, jsonPath);  //works fine now

            Department department_deserialized = dataSerializer.JSONDeserializeNewtonsoft<Department>(newtonJsonPath);
            Department department_deserialized2 = dataSerializer.JSONDeserialize<Department>(jsonPath);  //works fine now

            Console.WriteLine($"Name: {department_deserialized.DepartmentName}");
            foreach (Employee emp in department_deserialized.employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }

            Console.WriteLine("\nNow works fine:\n");
            Console.WriteLine($"Name: {department_deserialized2.DepartmentName}");
            foreach (Employee emp in department_deserialized2.employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }
        }
    }
}
