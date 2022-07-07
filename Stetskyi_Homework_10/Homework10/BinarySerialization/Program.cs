using Sources;
using System;

namespace BinarySerialization
{
    class Program
    {
        private const string BinaryPath = @"../../../../FolderToSaveFile/Binary.txt";

        static void Main(string[] args)
        {
            Department department = new Department("Binary Department");

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");
            
            department.Employees.Add(emp1);
            department.Employees.Add(emp2);
            department.Employees.Add(emp3);

            DataSerializer dataSerializer = new DataSerializer();

            dataSerializer.BinarySerialize(department, BinaryPath);

            Department departmentDeserialized = dataSerializer.BinaryDeserialize<Department>(BinaryPath);

            Console.WriteLine($"Name: {departmentDeserialized.DepartmentName}");
            foreach (Employee emp in departmentDeserialized.Employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }

        }
    }
}
