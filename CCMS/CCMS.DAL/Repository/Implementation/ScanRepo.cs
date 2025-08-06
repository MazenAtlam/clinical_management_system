using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class ScanRepo : IScanRepo
    {
        private readonly CcmsDbContext db;

        public ScanRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(Scan scan)
        {
            try
            {
                await db.scans.AddAsync(scan);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var scan = await db.scans.FirstOrDefaultAsync(a => a.Id == id);
                if (scan == null)
                    return false;
                scan.Delete("admin");
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Scan>> GetAllAsync()
        {
            return await db.scans.Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<Scan> GetByIdAsync(int id)
        {
            return await db.scans.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(Scan scan)
        {
            try
            {
                var sc = await db.scans.FirstOrDefaultAsync(a => a.Id == scan.Id);
                if (sc == null)
                    return false;
                sc.Edit(scan.ScanType, scan.ScanTech, scan.SDate, scan.PatientId, scan.Results);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}