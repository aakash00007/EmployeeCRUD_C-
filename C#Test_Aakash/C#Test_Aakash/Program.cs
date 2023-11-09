using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeeCRUD
{
    class Employee
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Hobbies { get; set; } = string.Empty;
        public int Salary { get; set; } 
    }
    class Program
    {
        enum Department
        {
            IT,
            HR,
            Sales,
            Marketing,
            Production
        }

        static List<Employee> employeeList = new List<Employee>()
        {
        new Employee {Name = "John Singh", Age = 20, Department = "IT", Hobbies = "Cricket", Salary = 10000},
        new Employee {Name = "Michael Mayers", Age = 20, Department = "IT", Hobbies = "Singing", Salary = 20000},
        new Employee {Name = "Kyle Mayers", Age = 20, Department = "HR", Hobbies = "Dancing", Salary = 120000},
        new Employee {Name = "Chris Lynn", Age = 20, Department = "HR", Hobbies = "Football", Salary = 25000},
        new Employee {Name = "Rick Morty", Age = 20, Department = "Sales", Hobbies = "Tennis", Salary = 15000},
        };
        static void viewEmployee()
        {
            Console.WriteLine("\nEmployee Data: \n");
            Console.WriteLine($"{"Name",-30}\t{"Age",-10}\t{"Department",-20}\t{"Hobbies",-25}\t{"Salary",-20}\n");

            foreach (Employee emp in employeeList)
            {
                Console.WriteLine($"{emp.Name,-30}\t{emp.Age,-10}\t{emp.Department,-20}\t{emp.Hobbies,-25}\t{"$" +emp.Salary,-20}");
            }
        }

        static void addEmployee()
        {           
            Employee emp = new Employee();
            bool validName = false;
            while (!validName)
            {
                Console.Write("\nEnter Employee Name: ");
                emp.Name = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(emp.Name) || !Regex.IsMatch(emp.Name, @"^[a-zA-Z](?:[a-zA-Z,'_ -]*[a-zA-Z])?$"))
                {
                    Console.WriteLine("\nPlease Enter a valid name!!\n");
                }
                else
                {
                    validName = true;
                }
            }

            bool validAge = false;
            while (!validAge)
            {
                try
                {
                    Console.Write("\nEnter Employee Age: ");
                    emp.Age = int.Parse(Console.ReadLine() ?? "");

                    if(!(emp.Age > 0))
                    {
                        Console.WriteLine("\nAge can not be zero!!\n");
                    }
                    else
                    {
                        validAge = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nEnter age in numbers only!!\n");
                }
            }

            bool valid = true;
            while (valid)
            {
                try
                {
                    Console.WriteLine("\nEnter Employee Department: (IT/HR/Sales/Marketing/Production): ");
                    string value = Console.ReadLine() ?? "";
                    Department department = (Department)Enum.Parse(typeof(Department), value, true);
                    emp.Department = value;
                    valid = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\nInvalid department entered. Please choose from mentioned options only!!\n");
                }
            }
            


            Console.Write("\nEnter Employee Hobbies: ");
            emp.Hobbies = Console.ReadLine() ?? "";

            bool validSalary = false;
            while (!validSalary)
            {
                try
                {
                    Console.Write("\nEnter Employee Salary: ");
                    emp.Salary = int.Parse(Console.ReadLine() ?? "");

                    if (!(emp.Salary > 0))
                    {
                        Console.WriteLine("\nSalary can not be zero!!\n");
                    }
                    else
                    {
                        validSalary = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nEnter Salary in numbers only!!\n");
                }
            }

            employeeList.Add(emp);
            Console.WriteLine("\nEmployee Added Successfully!!\n");  
        }

        static void editEmployee()
        {
            Console.WriteLine("\nEnter the Name of Employee to Update: ");
            string name = Console.ReadLine() ?? "";

            Employee empToUpdate = employeeList.FirstOrDefault(emp => emp.Name == name) ?? new Employee();

            if (!employeeList.Any(emp => emp.Name == name))
            {
                Console.WriteLine("\nEmployee Not Found!!\n");
                return;
            }

            if (empToUpdate != null)
            {
                bool validName = false;
                while (!validName)
                {
                    Console.Write("\nEnter Employee Name: ");
                    empToUpdate.Name = Console.ReadLine() ?? "";

                    if (string.IsNullOrWhiteSpace(empToUpdate.Name) || !Regex.IsMatch(empToUpdate.Name, @"^[a-zA-Z](?:[a-zA-Z,'_ -]*[a-zA-Z])?$"))
                    {
                        Console.WriteLine("\nPlease Enter a valid name!!\n");
                    }
                    else
                    {
                        validName = true;
                    }
                }

                bool validAge = false;
                while (!validAge)
                {
                    try
                    {
                        Console.Write("\nEnter Employee Age: ");
                        empToUpdate.Age = int.Parse(Console.ReadLine() ?? "");

                        if (!(empToUpdate.Age > 0))
                        {
                            Console.WriteLine("\nAge can not be zero!!\n");
                        }
                        else
                        {
                            validAge = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nEnter age in numbers only!!\n");
                    }
                }

                bool valid = true;
                while (valid)
                {
                    try
                    {
                        Console.WriteLine("\nEnter Employee Department: (IT/HR/Sales/Marketing/Production): ");
                        string value = Console.ReadLine() ?? "";
                        Department department = (Department)Enum.Parse(typeof(Department), value, true);
                        empToUpdate.Department = value;
                        valid = false;
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("\nInvalid department entered. Please choose from mentioned options only!!\n");
                    }
                }

                Console.Write("\nEnter New Employee Hobbies: ");
                empToUpdate.Hobbies = Console.ReadLine() ?? "";

                bool validSalary = false;
                while (!validSalary)
                {
                    try
                    {
                        Console.Write("\nEnter Employee Salary: ");
                        empToUpdate.Salary = int.Parse(Console.ReadLine() ?? "");

                        if (!(empToUpdate.Salary > 0))
                        {
                            Console.WriteLine("\nSalary can not be zero!!\n");
                        }
                        else
                        {
                            validSalary = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nEnter Salary in numbers only!!\n");
                    }
                }

                Console.WriteLine("\nEmployee Details updated successfully!!\n");
            }
        }
        static void deleteEmployee()
        {
            Console.WriteLine("\nEnter Name of Employee to Delete: ");
            string name = Console.ReadLine() ?? "";

            if (!employeeList.Any(emp => emp.Name == name))
            {
                Console.WriteLine("\nEmployee Not Found!!\n");
                return;
            }

            Employee empToDelete = employeeList.FirstOrDefault(emp => emp.Name == name) ?? new Employee();
            Console.WriteLine($"Are you sure you want to delete Employee: {empToDelete.Name} (y/n)");
            string value = Console.ReadLine() ?? "";

            if (empToDelete != null && (value == "y" || value == "Y"))
            {
                employeeList.Remove(empToDelete);
                Console.WriteLine("\nEmployee Removed Successfully!!\n");
            }
            else
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            while (true) { 
                try
                {
                    Console.WriteLine("\nPlease select one of the below options to continue: \n");
                    Console.WriteLine("1.View Employees");
                    Console.WriteLine("2.Add Employees");
                    Console.WriteLine("3.Edit Employees");
                    Console.WriteLine("4.Delete Employees");
                    Console.WriteLine("5.Quit Application");
                    Console.WriteLine();
                    int choice = int.Parse(Console.ReadLine() ?? "");

                    switch (choice)
                    {
                        case 1:
                            viewEmployee();
                            break;
                        case 2:
                            addEmployee();
                            break;
                        case 3:
                            editEmployee();
                            break;
                        case 4:
                            deleteEmployee();
                            break;
                        case 5:
                            Console.WriteLine("Are you sure you want to Quit?(y/n)");
                            string quit = Console.ReadLine() ?? "";
                            
                            if(quit == "y" || quit == "Y")
                            {
                                return;
                            }
                            else
                            {
                                break;
                            }
                        default:
                            Console.WriteLine("\nPlease choose from above options only!!\n");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nPlease choose from above options only!!\n");
                }
            }
        }
    }
}