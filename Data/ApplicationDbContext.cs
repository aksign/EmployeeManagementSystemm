using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystemm.Models;
namespace EmployeeManagementSystemm.Data
    
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
