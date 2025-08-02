using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class DoctorRepo:IDoctorRepo
    {
        private readonly CcmsDbContext db;

        public DoctorRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(Doctor doctor)
        {
            try
            {
                db.doctors.Add(doctor);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            //mestany employee 3alashan id we delete
            try
            {
                var doctor = db.doctors.Where(a => a.Id == id).FirstOrDefault();
                if (doctor == null)
                    return false;
                doctor.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Doctor> GetAll()
        {
            var result = db.doctors.Where(a => a.IsDeleted == false).ToList();
            return result;
        }

        public List<Doctor> GetAllByMajor(Specialization major)
        {
            var result = db.doctors.Where(a => a.IsDeleted == false && a.major == major).ToList();
            return result;
        }

        public List<Doctor> GetAllByName(string name)
        {
            var result = db.doctors.Where(a => a.IsDeleted == false /*&& a.name == name*/).ToList();
            return result;
        }

        public List<Doctor> GetAllByRating(Rating rating)
        {
            var result = db.doctors.Where(a => a.IsDeleted == false && a.rating == rating).ToList();
            return result;
        }

        public Doctor GetById(int id)
        {
            var doctor = db.doctors.Where(a => a.Id == id).FirstOrDefault();
            return doctor;
        }

        public bool Update(Doctor doctor)
        {
            try
            {
                var doc = db.doctors.Where(a => a.Id == doctor.Id).FirstOrDefault();
                if (doc == null)
                    return false;
                //fix when person class is done
                //doc.Edit(/*doc.Name, doc.Age*/);
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
