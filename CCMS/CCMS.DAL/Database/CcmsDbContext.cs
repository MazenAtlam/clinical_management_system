using Microsoft.EntityFrameworkCore;
using CCMS.DAL.Entities;
namespace CCMS.DAL.Database
{
    public class CcmsDbContext : DbContext
    {
        public CcmsDbContext(DbContextOptions<CcmsDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }

    }
}
