using System;
using Sources;

namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("XML Department");
            string Path = @"../../../../FolderToSaveFile/XML.txt";

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");

            department.employees.Add(emp1);
            department.employees.Add(emp2);
            department.employees.Add(emp3);

            DataSerializer DS = new DataSerializer();

            DS.XMLSerialize(department, Path);

            Department department_deserialized = DS.XMLDeserialize<Department>(Path);

            Console.WriteLine($"Name: {department_deserialized.DepartmentName}");
            foreach (Employee emp in department_deserialized.employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }
        }
    }
}
