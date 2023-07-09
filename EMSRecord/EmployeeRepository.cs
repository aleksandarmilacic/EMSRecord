namespace EMSRecord
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;

        public EmployeeRepository()
        {
            employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employee = employee with { Id = employees.Count + 1 };
            employees.Add(employee);
            Console.WriteLine("Employee added successfully.");
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.Find(e => e.Id == id);
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            Employee employee = GetEmployeeById(updatedEmployee.Id);
            if (employee != null)
            {
                employee = employee with
                {
                    FirstName = updatedEmployee.FirstName,
                    LastName = updatedEmployee.LastName,
                    Position = updatedEmployee.Position,
                    Department = updatedEmployee.Department
                };
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }


}