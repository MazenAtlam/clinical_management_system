using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.ModelVM.Room;
using CCMS.BLL.ModelVM.WorkingSlot;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IDoctorService
    {
        public Task<string?> Create(CreateDoctor doc, string createdBy);
        public Task<(DoctorDTO?, string?)> GetById(int id);
        public Task<(List<DoctorDTO>?, string?)> GetAll();
        public Task<(List<DoctorDTO>?, string?)> GetAllByMajor(Specialization major);
        public Task<(List<DoctorDTO>?, string?)> GetAllByName(string name);
        public Task<(List<DoctorDTO>?, string?)> GetAllByRating(Rating rating);
        public Task<string?> Delete(int id, string modifiedBy);
        public Task<string?> Update(DoctorDTO doctor, string modifiedBy);
        
        // New methods
        public Task<(List<Specialization>?, string?)> GetAllSpecializations();
        public Task<(List<PatientDTO>?, string?)> GetPatientsWithBooksByDoctor(int doctorId);
        public Task<(List<WorkingSlotDTO>?, string?)> GetDoctorWorkingSlots(int doctorId);
        public Task<(List<RoomDTO>?, string?)> GetEmptyRoomsInDoctorDepartment(int doctorId);
        //public bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots);
        //public bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots);
    }
}
