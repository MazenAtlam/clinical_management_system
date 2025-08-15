using CCMS.BLL.ModelVM.Doctor;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IDoctorService
    {
        bool Create(CreateDoctor doctor);
        Task<Doctor> GetById(int id);
        Task<List<Doctor>> GetAll();
        Task<List<Doctor>> GetAllByMajor(Specialization major);
        Task<List<Doctor>> GetAllByName(string name);
        Task<List<Doctor>> GetAllByRating(Rating rating);
        bool Delete(int id);
        Task<bool> Update(DoctorDTO doctor);
        
        // New methods
        Task<List<Specialization>> GetAllSpecializations();
        Task<List<Doctor>> GetDoctorsBySpecialization(Specialization specialization);
        //Task<List<WorkingSlot>> GetDoctorWorkingSlots(int doctorId);
        //Task<List<Room>> GetEmptyRoomsInDoctorDepartment(int doctorId);
        //Task<Doctor> GetDoctorInfoById(int id);
        Task<bool> EditDoctorInfoById(int id, DoctorDTO doctor);
        //Task<List<Patient>> GetPatientsWithBooksByDoctor(int doctorId);
        //bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots);
        //bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots);
    }
}
