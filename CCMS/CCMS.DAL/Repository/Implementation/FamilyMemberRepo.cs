using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace CCMS.DAL.Repository.Implementation
{
    public class FamilyMemberRepo : IFamilyMemberRepo
    {
        private readonly CcmsDbContext db;

        public FamilyMemberRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(FamilyMember familyMember)
        {
            try
            {
                db.familyMembers.Add(familyMember);
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
                var member = db.familyMembers.FirstOrDefault(a => a.Id == id);
                if (member == null)
                    return false;
                member.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<FamilyMember> GetAll()
        {
            return db.familyMembers.Where(a => a.IsDeleted == false).ToList();
        }

        public FamilyMember GetById(int id)
        {
            return db.familyMembers.FirstOrDefault(a => a.Id == id);
        }

        public bool Update(FamilyMember familyMember)
        {
            try
            {
                var member = db.familyMembers.FirstOrDefault(a => a.Id == familyMember.Id);
                if (member == null)
                    return false;
                member.Edit(familyMember.name, familyMember.Gender, familyMember.SSN, familyMember.phone);
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