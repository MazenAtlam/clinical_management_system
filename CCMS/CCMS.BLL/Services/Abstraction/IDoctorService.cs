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
        public Task<(DoctorDTO?, string?)> GetById(string id);
        public Task<(List<DoctorDTO>?, string?)> GetAll();
        public Task<(List<DoctorDTO>?, string?)> GetAllByMajor(Specialization major);
        public Task<(List<DoctorDTO>?, string?)> GetAllByName(string name);
        public Task<(List<DoctorDTO>?, string?)> GetAllByRating(Rating rating);
        public Task<string?> Delete(string id, string modifiedBy);
        public Task<string?> Update(DoctorDTO doctor, string modifiedBy);
        
        // New methods
        public Task<(List<Specialization>?, string?)> GetAllSpecializations();
        public Task<(List<PatientDTO>?, string?)> GetPatientsWithBooksByDoctor(string doctorId);
        public Task<(List<WorkingSlotDTO>?, string?)> GetDoctorWorkingSlots(string doctorId);
        public Task<(List<RoomDTO>?, string?)> GetEmptyRoomsInDoctorDepartment(string doctorId);
        //public bool UpdateDoctorWorkingSlots(string doctorId, List<WorkingSlot> workingSlots);
        //public bool AddWorkingSlotsToDoctor(string doctorId, List<WorkingSlot> workingSlots);
    }
}
