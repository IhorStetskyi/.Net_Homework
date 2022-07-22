using System;
using Sources;

namespace XMLSerialization
{
    class Program
    {
        private const string XmlPath = @"../../../../FolderToSaveFile/XML.txt";
        static void Main(string[] args)
        {
            Department department = new Department("XML Department");

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");

            department.Employees.Add(emp1);
            department.Employees.Add(emp2);
            department.Employees.Add(emp3);

            DataSerializer dataSerializer = new DataSerializer();

            dataSerializer.XMLSerialize(department, XmlPath);

            Department departmentDeserialized = dataSerializer.XMLDeserialize<Department>(XmlPath);

            Console.WriteLine($"Name: {departmentDeserialized.DepartmentName}");
            foreach (Employee emp in departmentDeserialized.Employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }
        }
    }
}
