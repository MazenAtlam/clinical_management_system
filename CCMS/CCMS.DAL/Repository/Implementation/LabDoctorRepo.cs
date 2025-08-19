using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class LabDoctorRepo : ILabDoctorRepo
    {
        private readonly CcmsDbContext db;

        public LabDoctorRepo(CcmsDbContext db) =>this.db = db;

        public async Task Add(LabDoctor labDoctor) => db.labDoctors.Add(labDoctor);

        // In LabDoctorService
        //public bool Delete(string id)
        //{
        //    try
        //    {
        //        var labDoc = db.labDoctors.Where(a => a.UID == id).FirstOrDefault();
        //        if (labDoc == null)
        //            return false;
        //        //add modifiing user
        //        labDoc.Delete("admin");
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public async Task<List<LabDoctor>> GetAll() => db.labDoctors.Where(a => a.IsDeleted).ToList();

        public async Task<LabDoctor> GetById(string id)
        {
            LabDoctor? labDoc = db.labDoctors.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefault();

            return labDoc == null
                ? throw new ArgumentException($"There is no Lab Doctor with this ID", "id")
                : labDoc;
        }

        public async Task Save() => db.SaveChanges();

        // In LabDoctorService
        //public bool Update(LabDoctor labDoctor)
        //{
        //    try
        //    {
        //        var lab = db.labDoctors.Where(a => a.UID == labDoctor.UID).FirstOrDefault();
        //        if (lab == null)
        //            return false;
        //        // The Edit method has been updated
        //        //lab.Edit(labDoctor.GetFullName());
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
