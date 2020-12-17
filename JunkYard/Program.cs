using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JunkYard
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(1, "Bob");
            Employee employee2 = new Employee(01, "Greg");
            Employee employee3 = new Employee(100, "Megan");
            Employee employee4 = new Employee(10000, "Phil");
            Employee employee5 = new Employee(7, "Bobby");

            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            employees.Add(1,employee1);
            employees.Add(2,employee2);
            employees.Add(3,employee3);
            employees.Add(4,employee4);
            employees.Add(5,employee5);

          
            
            foreach (var pair in employees)
            {
                Console.WriteLine($"Key:{pair.Key}");
                Console.WriteLine($"EmployeeId:{pair.Value.Id}");
                Console.WriteLine($"EmployeeName:{pair.Value.Name}");
            }

            foreach (var key in employees.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (var value in employees.Values)
            {
                Console.WriteLine(value.Name);
                Console.WriteLine(value.Id);
            }


            Console.ReadKey();
        }
    }
}
