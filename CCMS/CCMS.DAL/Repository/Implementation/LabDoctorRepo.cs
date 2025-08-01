using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class LabDoctorRepo:ILabDoctorRepo
    {
        private readonly CcmsDbContext db;

        public LabDoctorRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(LabDoctor labDoctor)
        {
            try
            {
                db.labDoctors.Add(labDoctor);
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
                var labDoc = db.labDoctors.Where(a => a.Id == id).FirstOrDefault();
                if (labDoc == null)
                    return false;
                //add modifiing user
                labDoc.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<LabDoctor> GetAll()
        {
            var result = db.labDoctors.Where(a => a.IsDeleted == false).ToList();
            return result;
        }

        public LabDoctor GetById(int id)
        {
            var labDoc = db.labDoctors.Where(a => a.Id == id).FirstOrDefault();
            return labDoc;
        }

        public bool Update(LabDoctor labDoctor)
        {
            try
            {
                var lab = db.labDoctors.Where(a => a.Id == labDoctor.Id).FirstOrDefault();
                if (lab == null)
                    return false;
                //fix when person class is done
                lab.Edit(/*patient.Name, patient.Age*/);
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
