using HR.Api.DataAccess.Entities;
using HR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}