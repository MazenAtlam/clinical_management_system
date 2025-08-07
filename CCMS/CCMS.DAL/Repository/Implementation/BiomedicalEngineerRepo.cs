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
    public class BiomedicalEngineerRepo:IBiomedicalEngineerRepo
    {
        private readonly CcmsDbContext db;

        public BiomedicalEngineerRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(BiomedicalEngineer biomedicalEngineer)
        {
            try
            {
                db.biomedicalEngineers.Add(biomedicalEngineer);
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
                var bioMed = db.biomedicalEngineers.Where(a => a.UID == id).FirstOrDefault();
                if (bioMed == null)
                    return false;
                //add modifiing user
                bioMed.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BiomedicalEngineer> GetAll()
        {
            var result = db.biomedicalEngineers.Where(a => a.IsDeleted == false).ToList();
            return result;
        }

        public BiomedicalEngineer GetById(int id)
        {
            var bioMed = db.biomedicalEngineers.Where(a => a.UID == id).FirstOrDefault();
            return bioMed;
        }

        public bool Update(BiomedicalEngineer biomedicalEngineer )
        {
            try
            {
                var bio = db.biomedicalEngineers.Where(a => a.UID == biomedicalEngineer.UID).FirstOrDefault();
                if (bio == null)
                    return false;
                // The Edit method has been updated
                //bio.Edit(biomedicalEngineer.GetFullName());
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
