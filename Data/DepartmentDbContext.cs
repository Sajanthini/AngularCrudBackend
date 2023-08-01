using AngularBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularBackEnd.Data
{
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }
    }
}
