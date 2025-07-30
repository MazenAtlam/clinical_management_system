
using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly CcmsDbContext db;

        public PatientRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(Patient patient)
        {
            try
            {
                db.patients.Add(patient);
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
                var patient = db.patients.Where(a => a.Id == id).FirstOrDefault();
                if (patient == null)
                    return false;
                //add modifiing user
                patient.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Patient> GetAll()
        {
            var result = db.patients.Where(a => a.IsDeleted == false).ToList();
            return result;
        }

        public Patient GetById(int id)
        {
            var patient = db.patients.Where(a => a.Id == id).FirstOrDefault();
            return patient;
        }

        public bool Update(Patient patient)
        {
            try
            {
                var pat = db.patients.Where(a => a.Id == patient.Id).FirstOrDefault();
                if (pat == null)
                    return false;
                //fix when person class is done
                pat.Edit(/*patient.Name, patient.Age*/);
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
