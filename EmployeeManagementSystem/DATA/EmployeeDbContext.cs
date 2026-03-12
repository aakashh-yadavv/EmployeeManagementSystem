using EmployeeManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.DATA
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options):base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
