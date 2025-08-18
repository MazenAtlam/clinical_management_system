using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPatientRepo
    {
        public Task Add(Patient patient);
        public Task<Patient> GetById(string id);
        public Task<List<Patient>> GetAll();
        public Task Save();
    }
}
