using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class MedicalHistoryRepo : IMedicalHistoryRepo
    {
        private readonly CcmsDbContext db;

        public MedicalHistoryRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(MedicalHistory medicalHistory)
        {
            try
            {
                await db.medicalHistories.AddAsync(medicalHistory);
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
                var mh = await db.medicalHistories.FirstOrDefaultAsync(a => a.Id == id);
                if (mh == null)
                    return false;
                mh.Delete("admin");
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<MedicalHistory>> GetAllAsync()
        {
            return await db.medicalHistories.Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<MedicalHistory> GetByIdAsync(int id)
        {
            return await db.medicalHistories.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(MedicalHistory medicalHistory, string modifiedBy)
        {
            try
            {
                var mh = await db.medicalHistories.FirstOrDefaultAsync(a => a.Id == medicalHistory.Id);
                if (mh == null)
                    return false;
                mh.Edit(medicalHistory.IsAcceptable, medicalHistory.DiseaseName, medicalHistory.PatientId, modifiedBy);
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