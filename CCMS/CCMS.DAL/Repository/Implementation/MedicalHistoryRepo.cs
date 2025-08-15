using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class MedicalHistoryRepo : IMedicalHistoryRepo
    {
        private readonly CcmsDbContext db;

        public MedicalHistoryRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(MedicalHistory medicalHistory) => db.medicalHistories.Add(medicalHistory);

        // In MedicalHistoryService
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        var mh = await db.medicalHistories.FirstOrDefaultAsync(a => a.Id == id);
        //        if (mh == null)
        //            return false;
        //        mh.Delete("admin");
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<MedicalHistory>> GetAll() => db.medicalHistories.Where(a => !a.IsDeleted).ToList();

        public async Task<MedicalHistory> GetById(int id)
        {
            MedicalHistory? medicalHistory =  db.medicalHistories.FirstOrDefault(a => a.Id == id && !a.IsDeleted);

            return medicalHistory == null
                ? throw new ArgumentException($"There is no medical history with the ID = {id}", "id")
                : medicalHistory;
        }
        public async Task Save() => db.SaveChanges();

        // In MedicalHistoryService
        //public async Task<bool> UpdateAsync(MedicalHistory medicalHistory, string modifiedBy)
        //{
        //    try
        //    {
        //        var mh = await db.medicalHistories.FirstOrDefaultAsync(a => a.Id == medicalHistory.Id);
        //        if (mh == null)
        //            return false;
        //        mh.Edit(medicalHistory.IsAcceptable, medicalHistory.DiseaseName, medicalHistory.PatientId, modifiedBy);
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