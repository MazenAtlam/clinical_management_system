using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class ScanRepo : IScanRepo
    {
        private readonly CcmsDbContext db;

        public ScanRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(Scan scan) => db.scans.Add(scan);

        // In ScanService
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        var scan = await db.scans.FirstOrDefaultAsync(a => a.Id == id);
        //        if (scan == null)
        //            return false;
        //        scan.Delete("admin");
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<Scan>> GetAll() => db.scans.Where(a => a.IsDeleted == false).ToList();

        public async Task<Scan> GetById(int id)
        {
            Scan? scan =  db.scans.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefault();

            return scan == null
                ? throw new ArgumentException($"There is no scan with the ID = {id}", nameof(id))
                : scan;
        }

        public async Task Save() => db.SaveChanges();

        // In ScanService
        //public async Task<bool> UpdateAsync(Scan scan, string modifiedBy)
        //{
        //    try
        //    {
        //        var sc = await db.scans.FirstOrDefaultAsync(a => a.Id == scan.Id);
        //        if (sc == null)
        //            return false;
        //        sc.Edit(scan.ScanType, scan.ScanTech, scan.Results, scan.SDate, scan.LDID, scan.PatientId, modifiedBy);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}