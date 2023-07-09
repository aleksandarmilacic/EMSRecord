namespace EMSRecord
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            employeeRepository.AddEmployee(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            return employeeRepository.GetEmployeeById(id);
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            employeeRepository.UpdateEmployee(updatedEmployee);
        }

        public void DeleteEmployee(int id)
        {
            employeeRepository.DeleteEmployee(id);
        }
    }


}