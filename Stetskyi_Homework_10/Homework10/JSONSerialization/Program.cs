using Sources;
using System;

namespace JSONSerialization
{
    class Program
    {
        private const string NewtonJsonPath = @"../../../../FolderToSaveFile/JSON.txt";
        private const string JsonPath = @"../../../../FolderToSaveFile/JSON_Bad.txt";
        static void Main(string[] args)
        {
            Department department = new Department("JSON Department");

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");

            department.Employees.Add(emp1);
            department.Employees.Add(emp2);
            department.Employees.Add(emp3);

            DataSerializer dataSerializer = new DataSerializer();

            dataSerializer.JSONSerializeNewtonsoft(department, NewtonJsonPath);
            dataSerializer.JSONSerialize(department, JsonPath);  //works fine now

            Department departmentDeserialized = dataSerializer.JSONDeserializeNewtonsoft<Department>(NewtonJsonPath);
            Department departmentDeserialized2 = dataSerializer.JSONDeserialize<Department>(JsonPath);  //works fine now

            Console.WriteLine($"Name: {departmentDeserialized.DepartmentName}");
            foreach (Employee emp in departmentDeserialized.Employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }

            Console.WriteLine("\nNow works fine:\n");
            Console.WriteLine($"Name: {departmentDeserialized2.DepartmentName}");
            foreach (Employee emp in departmentDeserialized2.Employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }
        }
    }
}
