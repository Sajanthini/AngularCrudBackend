using AngularBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularBackEnd.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        { 

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
