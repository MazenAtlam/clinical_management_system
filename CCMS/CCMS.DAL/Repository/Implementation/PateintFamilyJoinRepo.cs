using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace CCMS.DAL.Repository.Implementation
{
    public class PateintFamilyJoinRepo : IPateintFamilyJoinRepo
    {
        private readonly CcmsDbContext db;

        public PateintFamilyJoinRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(PateintFamilyJoin join)
        {
            try
            {
                db.pateintFamilyJoins.Add(join);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = db.pateintFamilyJoins.FirstOrDefault(a => a.Id == id);
                if (entity == null)
                    return false;
                entity.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PateintFamilyJoin> GetAll()
        {
            return db.pateintFamilyJoins.Where(a => a.IsDeleted == false).ToList();
        }

        public PateintFamilyJoin GetById(int id)
        {
            return db.pateintFamilyJoins.FirstOrDefault(a => a.Id == id);
        }

        public bool Update(PateintFamilyJoin join)
        {
            try
            {
                var entity = db.pateintFamilyJoins.FirstOrDefault(a => a.Id == join.Id);
                if (entity == null)
                    return false;
                entity.Edit(join.Relationship, join.PatientId, join.FamilyMemberId);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}