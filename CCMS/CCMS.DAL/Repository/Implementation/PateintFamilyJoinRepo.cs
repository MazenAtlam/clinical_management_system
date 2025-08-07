/**
 * غالبا الريبو دي مش هيبقى ليها أهمية
 * 
 * أنت ممكن تتحكم في المريض وأقاربه عن طريق ال2 ريبوز بتاعتهم وخلاص
 * 
 * ممكن تتناقشوا فيها: علي ويوسف
 */














//using CCMS.DAL.Database;
//using CCMS.DAL.Entities;
//using CCMS.DAL.Repository.Abstraction;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CCMS.DAL.Repository.Implementation
//{
//    public class PatientFamilyRepo : IPatientFamilyRepo
//    {
//        private readonly CcmsDbContext db;

//        public PatientFamilyRepo(CcmsDbContext db)
//        {
//            this.db = db;
//        }

//        public async Task<bool> CreateAsync(PatientFamily join)
//        {
//            try
//            {
//                await db.pateintFamilyJoins.AddAsync(join);
//                await db.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            try
//            {
//                var entity = await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == id);
//                if (entity == null)
//                    return false;
//                entity.Delete("admin");
//                await db.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<List<PatientFamily>> GetAllAsync()
//        {
//            return await db.pateintFamilyJoins.Where(a => a.IsDeleted == false).ToListAsync();
//        }

//        public async Task<PatientFamily> GetByIdAsync(int id)
//        {
//            return await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == id);
//        }

//        public async Task<bool> UpdateAsync(PatientFamily join)
//        {
//            try
//            {
//                var entity = await db.pateintFamilyJoins.FirstOrDefaultAsync(a => a.Id == join.Id);
//                if (entity == null)
//                    return false;
//                entity.Edit(join.Relationship, join.PatientId, join.FamilyMemberId);
//                await db.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}