using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CCMS.DAL.Repository.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly CcmsDbContext db;
        
        public DoctorRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(Doctor doctor)
        {
            try
            {
                db.doctors.Add(doctor);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating doctor: {ex}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var doctor = db.doctors.FirstOrDefault(a => a.UID == id);
                if (doctor == null)
                    return false;
                
                doctor.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting doctor: {ex}");
                return false;
            }
        }

        public List<Doctor> GetAll()
        {
            try
            {
                return db.doctors.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting all doctors: {ex}");
                return new List<Doctor>();
            }
        }

        public List<Doctor> GetAllByMajor(Specialization major)
        {
            try
            {
                return db.doctors.Where(a => !a.IsDeleted && a.major == major).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting doctors by major: {ex}");
                return new List<Doctor>();
            }
        }

        public List<Doctor> GetAllByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return new List<Doctor>();
                    
                return db.doctors.Where(a => !a.IsDeleted && a.GetFullName().Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting doctors by name: {ex}");
                return new List<Doctor>();
            }
        }

        public List<Doctor> GetAllByRating(Rating rating)
        {
            try
            {
                return db.doctors.Where(a => !a.IsDeleted && a.rating == rating).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting doctors by rating: {ex}");
                return new List<Doctor>();
            }
        }

        public Doctor GetById(int id)
        {
            try
            {
                return db.doctors.FirstOrDefault(a => a.UID == id && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting doctor by id: {ex}");
                return null;
            }
        }

        public bool Update(Doctor doctor)
        {
            try
            {
                var existingDoctor = db.doctors.FirstOrDefault(a => a.UID == doctor.UID && !a.IsDeleted);
                if (existingDoctor == null)
                    return false;

                // Use the entity's Edit method to update properties
                existingDoctor.Edit(
                    doctor.FName,
                    doctor.MidName,
                    doctor.LName,
                    doctor.Ssn,
                    doctor.Gender,
                    doctor.BirthDate,
                    doctor.Salary,
                    doctor.YearsOfExperience,
                    doctor.HiringDate,
                    doctor.MgrId,
                    doctor.DeptId,
                    doctor.major,
                    doctor.rating,
                    doctor.ModifiedBy ?? "admin"
                );

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating doctor: {ex}");
                return false;
            }
        }

        public List<Specialization> GetAllSpecializations()
        {
            try
            {
                return Enum.GetValues(typeof(Specialization)).Cast<Specialization>().ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting specializations: {ex}");
                return new List<Specialization>();
            }
        }

        public List<Doctor> GetDoctorsBySpecialization(Specialization specialization)
        {
            try
            {
                return db.doctors.Where(d => !d.IsDeleted && d.major == specialization).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting doctors by specialization: {ex}");
                return new List<Doctor>();
            }
        }

        public List<WorkingSlot> GetDoctorWorkingSlots(int doctorId)
        {
            try
            {
                var doctor = db.doctors.Include(d => d.WorkingSlots)
                    .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
                return doctor?.WorkingSlots?.Where(ws => !ws.IsDeleted).ToList() ?? new List<WorkingSlot>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting doctor working slots: {ex}");
                return new List<WorkingSlot>();
            }
        }

        public List<Room> GetEmptyRoomsInDoctorDepartment(int doctorId)
        {
            try
            {
                var doctor = db.doctors.Include(d => d.Department)
                    .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
                if (doctor?.Department == null)
                    return new List<Room>();

                return db.rooms.Where(r => !r.IsDeleted && 
                                         r.DeptId == doctor.Department.ID && 
                                         r.rstatus == Rstatus.Available)
                             .ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting empty rooms: {ex}");
                return new List<Room>();
            }
        }

        public bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots)
        {
            try
            {
                var doctor = db.doctors.Include(d => d.WorkingSlots)
                    .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
                if (doctor == null)
                    return false;

                // Soft delete existing slots
                foreach (var existingSlot in doctor.WorkingSlots.Where(w => !w.IsDeleted))
                {
                    existingSlot.Delete("admin");
                }

                // Add new slots
                foreach (var slot in workingSlots)
                {
                    doctor.WorkingSlots.Add(slot);
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating doctor working slots: {ex}");
                return false;
            }
        }

        public bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots)
        {
            try
            {
                var doctor = db.doctors.Include(d => d.WorkingSlots)
                    .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
                if (doctor == null)
                    return false;

                foreach (var slot in workingSlots)
                {
                    doctor.WorkingSlots.Add(slot);
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding working slots to doctor: {ex}");
                return false;
            }
        }
    }
}
