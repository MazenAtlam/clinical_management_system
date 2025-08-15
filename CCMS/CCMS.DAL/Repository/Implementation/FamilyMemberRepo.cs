using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class FamilyMemberRepo : IFamilyMemberRepo
    {
        private readonly CcmsDbContext db;

        public FamilyMemberRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(FamilyMember familyMember)
        {
            try
            {
                await db.familyMembers.AddAsync(familyMember);
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
                var member = await db.familyMembers.FirstOrDefaultAsync(a => a.Id == id);
                if (member == null)
                    return false;
                member.Delete("admin");
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<FamilyMember>> GetAllAsync()
        {
            return await db.familyMembers.Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<FamilyMember> GetByIdAsync(int id)
        {
            return await db.familyMembers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(FamilyMember familyMember, string modifiedBy)
        {
            try
            {
                var member = await db.familyMembers.FirstOrDefaultAsync(a => a.Id == familyMember.Id);
                if (member == null)
                    return false;
                member.Edit(familyMember.Name, familyMember.Gender, familyMember.Ssn, familyMember.PhoneNumber, modifiedBy);
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