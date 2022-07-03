using HR.Api.DataAccess;

namespace HR.DataAccess
{
    public interface IEmployeerepository
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> CreateEmployee(Employee employee);

        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(int id, Employee employee);
        Task<bool> DeleteEmployee(int id);
    }
}