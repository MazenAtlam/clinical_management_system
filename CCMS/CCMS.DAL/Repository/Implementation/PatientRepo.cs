using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly CcmsDbContext db;

        public PatientRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(Patient patient)
        {
            try
            {
                await db.patients.AddAsync(patient);
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
                var patient = await db.patients.FirstOrDefaultAsync(a => a.UID == id);
                if (patient == null)
                    return false;
                patient.Delete("admin");
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await db.patients.Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await db.patients.FirstOrDefaultAsync(a => a.UID == id);
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
            try
            {
                var pat = await db.patients.FirstOrDefaultAsync(a => a.UID == patient.UID);
                if (pat == null)
                    return false;
                // The Edit method has been updated
                //pat.Edit(
                //    patient.FName,
                //    patient.MidName,
                //    patient.LName,
                //    patient.SSN,
                //    patient.Gender,
                //    patient.BirthDate,
                //    patient.BloodType
                //);
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
