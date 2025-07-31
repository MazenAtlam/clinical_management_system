using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace CCMS.DAL.Repository.Implementation
{
    public class MedicalHistoryRepo : IMedicalHistoryRepo
    {
        private readonly CcmsDbContext db;

        public MedicalHistoryRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(MedicalHistory medicalHistory)
        {
            try
            {
                db.medicalHistories.Add(medicalHistory);
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
                var mh = db.medicalHistories.FirstOrDefault(a => a.Id == id);
                if (mh == null)
                    return false;
                mh.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<MedicalHistory> GetAll()
        {
            return db.medicalHistories.Where(a => a.IsDeleted == false).ToList();
        }

        public MedicalHistory GetById(int id)
        {
            return db.medicalHistories.FirstOrDefault(a => a.Id == id);
        }

        public bool Update(MedicalHistory medicalHistory)
        {
            try
            {
                var mh = db.medicalHistories.FirstOrDefault(a => a.Id == medicalHistory.Id);
                if (mh == null)
                    return false;
                mh.Edit(medicalHistory.FamilyHistory, medicalHistory.DiseaseName, medicalHistory.PatientId);
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