using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class FamilyMemberRepo : IFamilyMemberRepo
    {
        private readonly CcmsDbContext db;

        public FamilyMemberRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(FamilyMember familyMember) => db.familyMembers.Add(familyMember);

        // In FamilyMemberService
        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        var member = await db.familyMembers.FirstOrDefaultAsync(a => a.Id == id);
        //        if (member == null)
        //            return false;
        //        member.Delete("admin");
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<FamilyMember>> GetAll() => db.familyMembers.Where(a => !a.IsDeleted).ToList();

        public async Task<FamilyMember> GetById(int id)
        {
            FamilyMember familyMember =  db.familyMembers.Where(a => a.Id == id).FirstOrDefault();

            return familyMember == null
                ? throw new ArgumentException($"There is no family member with the ID = {id}", "id")
                : familyMember;
        }

        public async Task Save() => db.SaveChanges();

        // In FamilyMemberService
        //public async Task<bool> UpdateAsync(FamilyMember familyMember, string modifiedBy)
        //{
        //    try
        //    {
        //        var member = await db.familyMembers.FirstOrDefaultAsync(a => a.Id == familyMember.Id);
        //        if (member == null)
        //            return false;
        //        member.Edit(familyMember.Name, familyMember.Gender, familyMember.Ssn, familyMember.PhoneNumber, modifiedBy);
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