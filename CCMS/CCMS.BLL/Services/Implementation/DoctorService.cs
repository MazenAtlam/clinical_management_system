using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo repo;
        private readonly IBookRepo bookRepo;

        public DoctorService(IDoctorRepo repo, IBookRepo bookRepo)
        {
            this.repo = repo;
            this.bookRepo = bookRepo;
        }

        public bool Create(CreateDoctor doctor)
        {
            try
            {
                var doc = new Doctor(
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
                    doctor.AdmId,
                    doctor.DeptId,
                    doctor.major,
                    doctor.rating,
                    "admin"
                );
                
                return repo.Create(doc);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        public List<Doctor> GetAll()
        {
            return repo.GetAll();
        }

        public List<Doctor> GetAllByMajor(Specialization major)
        {
            return repo.GetAllByMajor(major);
        }

        public List<Doctor> GetAllByName(string name)
        {
            return repo.GetAllByName(name);
        }

        public List<Doctor> GetAllByRating(Rating rating)
        {
            return repo.GetAllByRating(rating);
        }

        public Doctor GetById(int id)
        {
            return repo.GetById(id);
        }

        public bool Update(DoctorDTO doctor)
        {
            try
            {
                var existingDoctor = repo.GetById(doctor.UID);
                if (existingDoctor == null)
                    return false;

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
                    "admin"
                );

                return repo.Update(existingDoctor);
            }
            catch
            {
                return false;
            }
        }

        // New methods implementation
        public List<Specialization> GetAllSpecializations()
        {
            return repo.GetAllSpecializations();
        }

        public List<Doctor> GetDoctorsBySpecialization(Specialization specialization)
        {
            return repo.GetDoctorsBySpecialization(specialization);
        }

        public List<WorkingSlot> GetDoctorWorkingSlots(int doctorId)
        {
            return repo.GetDoctorWorkingSlots(doctorId);
        }

        public List<Room> GetEmptyRoomsInDoctorDepartment(int doctorId)
        {
            return repo.GetEmptyRoomsInDoctorDepartment(doctorId);
        }

        public Doctor GetDoctorInfoById(int id)
        {
            return repo.GetById(id);
        }

        public bool EditDoctorInfoById(int id, DoctorDTO doctor)
        {
            try
            {
                var existingDoctor = repo.GetById(id);
                if (existingDoctor == null)
                    return false;

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
                    "admin"
                );

                return repo.Update(existingDoctor);
            }
            catch
            {
                return false;
            }
        }

        public List<Patient> GetPatientsWithBooksByDoctor(int doctorId)
        {
            //return bookRepo.GetPatientsWithBooksByDoctorAsync(doctorId).Result;
            return new List<Patient>();
        }

        public bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots)
        {
            return repo.UpdateDoctorWorkingSlots(doctorId, workingSlots);
        }

        public bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots)
        {
            return repo.AddWorkingSlotsToDoctor(doctorId, workingSlots);
        }
    }
}
