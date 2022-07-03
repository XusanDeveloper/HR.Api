using HR.Api.DataAccess;
using HR.Api.Models;
using HR.DataAccess;

namespace HR.Api.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeerepository _employeeRepository;
        public EmployeeCRUDService(IEmployeerepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email
            };
            var createdEmployee = await _employeeRepository.CreateEmployee(employee);
            var result = new EmployeeModel
            {
                FullName = createdEmployee.FullName,
                Department = createdEmployee.Department,
                Email = createdEmployee.Email,
                Id = createdEmployee.Id
            };
            return result;
        }

        public Task<bool> Delete(int id)
        {
            return _employeeRepository.DeleteEmployee(id);
        }

        public async Task<EmployeeModel> Get(int id)
        {
            var employee = await _employeeRepository.GetEmployee(id);
            var model = new EmployeeModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Department = employee.Department,
                Email= employee.Email
            };
            return model;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            var result = new List<EmployeeModel>();
            var empployees = await _employeeRepository.GetEmployees();
            foreach (var employee in empployees)
            {
                var model = new EmployeeModel
                {
                    FullName = employee.FullName,
                    Department = employee.Department,
                    Email = employee.Email,
                    Id = employee.Id
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Id = model.Id
            };
            var updatesEmployee = await _employeeRepository.UpdateEmployee(id, employee);
            var result = new EmployeeModel
            {
                FullName = updatesEmployee.FullName,
                Department = updatesEmployee.Department,
                Email = updatesEmployee.Email,
                Id = updatesEmployee.Id
            };
            return result;
        }
    }
}
