using Microsoft.EntityFrameworkCore;

namespace CCMS.DAL.Database
{
    public class CcmsDbContext
    {
        public CcmsDbContext(DbContextOptions<CcmsDbContext> options) : base(options)
        {

        }
    }
}
