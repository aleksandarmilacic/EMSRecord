using System;
using System.Collections.Generic;

namespace EMSRecord
{

    public class Program
    {
        private static EmployeeService employeeService;
        private static IPrintService printService;

        static void Main()
        {
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            employeeService = new EmployeeService(employeeRepository);
            printService = new ConsolePrintService();
            bool exit = false;

            while (!exit)
            {
                PrintMenu();
                string choice = GetUserInput("Enter your choice: ");

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        ViewAllEmployees();
                        break;
                    case "3":
                        ViewEmployeeById();
                        break;
                    case "4":
                        UpdateEmployee();
                        break;
                    case "5":
                        DeleteEmployee();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        printService.Print("Invalid choice. Please try again.");
                        break;
                }

                printService.Print("");
            }
        }

        static void PrintMenu()
        {
            printService.Print("Employee Management System");
            printService.Print("1. Add Employee");
            printService.Print("2. View All Employees");
            printService.Print("3. View Employee by ID");
            printService.Print("4. Update Employee");
            printService.Print("5. Delete Employee");
            printService.Print("6. Exit");
        }

        static void AddEmployee()
        {
            string firstName = GetUserInput("Enter first name: ");
            string lastName = GetUserInput("Enter last name: ");
            string position = GetUserInput("Enter position: ");
            string department = GetUserInput("Enter department: ");

            Employee employee = new Employee(0, firstName, lastName, position, department);
            employeeService.AddEmployee(employee);
            printService.Print("Employee added successfully.");
        }

        static void ViewAllEmployees()
        {
            List<Employee> employees = employeeService.GetAllEmployees();
            if (employees.Count == 0)
            {
                printService.Print("No employees found.");
            }
            else
            {
                printService.Print("Employee List:");
                foreach (Employee employee in employees)
                {
                    printService.Print($"ID: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}, Department: {employee.Department}");
                }
            }
        }

        static void ViewEmployeeById()
        {
            int id = GetIntInput("Enter employee ID: ");
            Employee employee = employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                printService.Print($"ID: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, Position: {employee.Position}, Department: {employee.Department}");
            }
            else
            {
                printService.Print("Employee not found.");
            }
        }

        static void UpdateEmployee()
        {
            int id = GetIntInput("Enter employee ID: ");
            Employee employee = employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                string firstName = GetUserInput("Enter new first name: ");
                string lastName = GetUserInput("Enter new last name: ");
                string position = GetUserInput("Enter new position: ");
                string department = GetUserInput("Enter new department: ");

                Employee updatedEmployee = employee with
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Position = position,
                    Department = department
                };

                employeeService.UpdateEmployee(updatedEmployee);
                printService.Print("Employee updated successfully.");
            }
            else
            {
                printService.Print("Employee not found.");
            }
        }

        static void DeleteEmployee()
        {
            int id = GetIntInput("Enter employee ID: ");
            employeeService.DeleteEmployee(id);
        }

        static string GetUserInput(string message)
        {
            printService.Print(message);
            return printService.ReadLine();
        }

        static int GetIntInput(string message)
        {
            printService.Print(message);
            if (int.TryParse(printService.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                printService.Print("Invalid input. Please enter a valid integer.");
                return GetIntInput(message);
            }
        }
    }




}