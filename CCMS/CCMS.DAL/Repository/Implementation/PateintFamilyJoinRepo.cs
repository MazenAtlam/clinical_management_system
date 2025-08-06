using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class PateintFamilyJoinRepo : IPateintFamilyJoinRepo
    {
        private readonly CcmsDbContext db;

        public PateintFamilyJoinRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(PateintFamilyJoin join)
        {
            try
            {
                await db.pateintFamilyJoins.AddAsync(join);
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
                var entity = await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == id);
                if (entity == null)
                    return false;
                entity.Delete("admin");
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<PateintFamilyJoin>> GetAllAsync()
        {
            return await db.pateintFamilyJoins.Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<PateintFamilyJoin> GetByIdAsync(int id)
        {
            return await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(PateintFamilyJoin join)
        {
            try
            {
                var entity = await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == join.Id);
                if (entity == null)
                    return false;
                entity.Edit(join.Relationship, join.PatientId, join.FamilyMemberId);
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