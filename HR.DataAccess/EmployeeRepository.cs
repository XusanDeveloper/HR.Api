using HR.Api.DataAccess;
using HR.Api.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess
{
    public class EmployeeRepository : IGenericRepository<Employee>
    {
        private readonly AppDbContext _dbcontext;
        public EmployeeRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Employee> Create(Employee employee)
        {
            await _dbcontext.Employees.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var employee = await _dbcontext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbcontext.Employees.Remove(employee);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> Get(int id)
        {
            return await _dbcontext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbcontext.Employees.ToListAsync();
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var updatedEmployee = _dbcontext.Employees.Attach(employee);
            updatedEmployee.State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return employee;
        }
    }
}
