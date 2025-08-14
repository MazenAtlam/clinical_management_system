using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IDoctorRepo
    {
        bool Create(Doctor doctor);
        Doctor GetById(int id);
        List<Doctor> GetAll();
        List<Doctor> GetAllByMajor(Specialization major);
        List<Doctor> GetAllByName(string name);
        List<Doctor> GetAllByRating(Rating rating);
        bool Delete(int id);
        bool Update(Doctor doctor);
        
        // New methods
        List<Specialization> GetAllSpecializations();
        List<Doctor> GetDoctorsBySpecialization(Specialization specialization);
        List<WorkingSlot> GetDoctorWorkingSlots(int doctorId);
        List<Room> GetEmptyRoomsInDoctorDepartment(int doctorId);
        bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots);
        bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots);
    }
}
