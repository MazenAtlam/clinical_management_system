using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IBiomedicalEngineerRepo
    {
        public Task Add(BiomedicalEngineer biomedicalEngineer);
        public Task<BiomedicalEngineer> GetById(string id);
        public Task<List<BiomedicalEngineer>> GetAll();
        public Task Save();
    }
}
