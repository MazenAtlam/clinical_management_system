using Microsoft.EntityFrameworkCore;
using CCMS.DAL.Entities;
namespace CCMS.DAL.Database
{
    public class CcmsDbContext : DbContext
    {
        public CcmsDbContext(DbContextOptions<CcmsDbContext> options) : base(options)
        {

        }
        
    }
}
