using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface ILabDoctorRepo
    {
        public Task Add(LabDoctor labDoctor);
        public Task<LabDoctor> GetById(string id);
        public Task<List<LabDoctor>> GetAll();
        public Task Save();
    }
}
