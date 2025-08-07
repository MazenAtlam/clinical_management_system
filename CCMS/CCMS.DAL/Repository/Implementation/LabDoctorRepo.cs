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
                var labDoc = db.labDoctors.Where(a => a.UID == id).FirstOrDefault();
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
            var labDoc = db.labDoctors.Where(a => a.UID == id).FirstOrDefault();
            return labDoc;
        }

        public bool Update(LabDoctor labDoctor)
        {
            try
            {
                var lab = db.labDoctors.Where(a => a.UID == labDoctor.UID).FirstOrDefault();
                if (lab == null)
                    return false;
                // The Edit method has been updated
                //lab.Edit(labDoctor.GetFullName());
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
