using CCMS.DAL.Entities;
using CCMS.DAL.Enums;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IDoctorRepo
    {
        public Task Create(Doctor doctor);
        public Task<Doctor> GetById(int id);
        public Task<List<Doctor>> GetAll();
        public Task<List<Doctor>> GetAllByMajor(Specialization major);
        public Task<List<Doctor>> GetAllByName(string name);
        public Task<List<Doctor>> GetAllByRating(Rating rating);
        public Task Save();
        
        // New methods
        public Task<List<Specialization>> GetAllSpecializations();
        public Task<List<Doctor>> GetDoctorsBySpecialization(Specialization specialization);
    }
}
