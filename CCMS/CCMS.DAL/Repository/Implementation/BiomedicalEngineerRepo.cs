using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class BiomedicalEngineerRepo : IBiomedicalEngineerRepo
    {
        private readonly CcmsDbContext db;

        public BiomedicalEngineerRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(BiomedicalEngineer biomedicalEngineer) => db.biomedicalEngineers.Add(biomedicalEngineer);

        public async Task<List<BiomedicalEngineer>> GetAll() => db.biomedicalEngineers.Where(a => !a.IsDeleted).ToList();

        public async Task<BiomedicalEngineer> GetById(int id)
        {
            BiomedicalEngineer? biomedicalEngineer = db.biomedicalEngineers.Where(a => a.UID == id && !a.IsDeleted).FirstOrDefault();

            return biomedicalEngineer == null
                ? throw new ArgumentException($"There is no biomedical engineer with the ID = {id} .", "id")
                : biomedicalEngineer;
        }

        public async Task Save() => db.SaveChanges();
    }
}
