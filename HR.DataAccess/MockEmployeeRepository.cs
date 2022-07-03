using HR.Api.DataAccess;
using System.Collections.Concurrent;

namespace HR.DataAccess
{
    public class MockEmployeeRepository : IEmployeerepository
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private  object locker = new();


        public MockEmployeeRepository()
        {
            Init();
        }
        public void Init()
        {
            _employees.TryAdd(1, new Employee { Id = 1, FullName = "Xusan Nematov", Department = "CEO", Email = "huseyntechs@gmail.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "Xasan Nematov", Department = "CTO", Email = "xasannematov@gmail.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "Sherzod Xurazov", Department = "CTO", Email = "khurazovsherzod@gmail.com" });
            _employees.TryAdd(4, new Employee { Id = 4, FullName = "Oybek Toshpulaov", Department = "CTO", Email = "oybektoshpulatov@gmail.com" });
            _employees.TryAdd(5, new Employee { Id = 5, FullName = "Ozodbek", Department = "CEO", Email = "ozodbektechs@gmail.com" });
        }

        public  async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await Task.FromResult(_employees.Values);
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            int newId = 0;
            lock (locker)
            {
                newId = _employees.Keys.Max() + 1;
            }
            employee.Id = newId;
            _employees.TryAdd(newId, employee);
            return await Task.FromResult(employee);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            await Task.FromResult(_employees[id] = employee);
            return employee;
        }

        public Task<bool> DeleteEmployee(int id)
        {
            if (_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
