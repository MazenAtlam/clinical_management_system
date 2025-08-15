using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class PatientFamilyRepo : IPatientFamilyRepo
    {
        private readonly CcmsDbContext db;

        public PatientFamilyRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(PatientFamily patientFamily) => db.pateintFamilyJoins.Add(patientFamily);

        // In PatientFamilyMemberService
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        var entity = await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == id);
        //        if (entity == null)
        //            return false;
        //        entity.Delete("admin");
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<PatientFamily> GetByIds(int patientId, int familyMemberId)
        {
            PatientFamily? patientFamily = db.pateintFamilyJoins
            .Where(a => a.PatientId == patientId && a.FamilyMemberId == familyMemberId && !a.IsDeleted)
            .FirstOrDefault();

            return patientFamily == null
                ? throw new ArgumentException($"The patient with ID = {patientId} has no relation with the family member with ID = {familyMemberId} Or one of them does not exist.")
                : patientFamily;
        }

        // In PatientFamilyMemberService
        //public async Task<bool> UpdateAsync(PatientFamily join)
        //{
        //    try
        //    {
        //        var entity = await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == join.Id);
        //        if (entity == null)
        //            return false;
        //        entity.Edit(join.Relationship, join.PatientId, join.FamilyMemberId);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task Save() => db.SaveChanges();
    }
}