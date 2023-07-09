namespace EMSRecord
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void UpdateEmployee(Employee updatedEmployee);
        void DeleteEmployee(int id);
    }


}