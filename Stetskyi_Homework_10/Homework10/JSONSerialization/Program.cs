using Sources;
using System;

namespace JSONSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("JSON Department");
            string Path = @"../../../../FolderToSaveFile/JSON.txt";
            string Path2 = @"../../../../FolderToSaveFile/JSON_Bad.txt";

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");

            department.employees.Add(emp1);
            department.employees.Add(emp2);
            department.employees.Add(emp3);

            DataSerializer DS = new DataSerializer();

            DS.JSONSerializeNewtonsoft(department, Path);
            DS.JSONSerialize(department, Path2);  //works bad

            Department department_deserialized = DS.JSONDeserializeNewtonsoft<Department>(Path);
           // Department department_deserialized2 = DS.JSONDeserialize<Department>(Path2);  //works bad

            Console.WriteLine($"Name: {department_deserialized.DepartmentName}");
            foreach (Employee emp in department_deserialized.employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }

            //Console.WriteLine("\nNow bad part:\n");
            //Console.WriteLine($"Name: {department_deserialized2.DepartmentName}");
            //foreach (Employee emp in department_deserialized2.employees)
            //{
            //    Console.WriteLine($"Employee: {emp.EmployeeName}");
            //}
        }
    }
}
