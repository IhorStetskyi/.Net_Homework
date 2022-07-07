using Sources;
using System;

namespace BinarySerialization
{
    class Program
    {
        private const string binaryPath = @"../../../../FolderToSaveFile/Binary.txt";

        static void Main(string[] args)
        {
            Department department = new Department("Binary Department");

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");
            
            department.employees.Add(emp1);
            department.employees.Add(emp2);
            department.employees.Add(emp3);

            DataSerializer dataSerializer = new DataSerializer();

            dataSerializer.BinarySerialize(department, binaryPath);

            Department department_deserialized = dataSerializer.BinaryDeserialize<Department>(binaryPath);

            Console.WriteLine($"Name: {department_deserialized.DepartmentName}");
            foreach (Employee emp in department_deserialized.employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }

        }
    }
}
