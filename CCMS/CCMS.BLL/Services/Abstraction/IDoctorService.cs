using CCMS.BLL.ModelVM.Doctor;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IDoctorService
    {
        bool Create(CreateDoctor doctor);
        Doctor GetById(int id);
        List<Doctor> GetAll();
        List<Doctor> GetAllByMajor(Specialization major);
        List<Doctor> GetAllByName(string name);
        List<Doctor> GetAllByRating(Rating rating);
        bool Delete(int id);
        bool Update(DoctorDTO doctor);
        
        // New methods
        List<Specialization> GetAllSpecializations();
        List<Doctor> GetDoctorsBySpecialization(Specialization specialization);
        List<WorkingSlot> GetDoctorWorkingSlots(int doctorId);
        List<Room> GetEmptyRoomsInDoctorDepartment(int doctorId);
        Doctor GetDoctorInfoById(int id);
        bool EditDoctorInfoById(int id, DoctorDTO doctor);
        List<Patient> GetPatientsWithBooksByDoctor(int doctorId);
        bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots);
        bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots);
    }
}
