using HR.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}