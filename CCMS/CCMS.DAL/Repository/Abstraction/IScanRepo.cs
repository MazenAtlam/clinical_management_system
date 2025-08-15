using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IScanRepo
    {
        public Task Add(Scan scan);
        public Task<Scan> GetById(int id);
        public Task<List<Scan>> GetAll();
        public Task Save();
    }
}