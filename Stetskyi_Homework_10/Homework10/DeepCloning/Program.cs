using System;
using Sources;

namespace DeepCloning
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("Not Changed Department");

            Employee emp1 = new Employee("Employee 1");
            Employee emp2 = new Employee("Employee 2");
            Employee emp3 = new Employee("Employee 3");

            department.Employees.Add(emp1);
            department.Employees.Add(emp2);
            department.Employees.Add(emp3);

            //Cloning
            Department clone = department.DeepClone();

            //Changing old class
            department.DepartmentName = "Changed Department";
            department.Employees.Add(new Employee("Employee 4"));
            department.Employees.Add(new Employee("Employee 5"));

            //Show Results in Clone
            Console.WriteLine($"Name: {clone.DepartmentName}");
            foreach (Employee emp in clone.Employees)
            {
                Console.WriteLine($"Employee: {emp.EmployeeName}");
            }
        }
    }
}
