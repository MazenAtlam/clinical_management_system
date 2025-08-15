using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

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

                //return repo.Create(doc);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            //return repo.Delete(id);
            return false;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<List<Doctor>> GetAllByMajor(Specialization major)
        {
            return await repo.GetAllByMajor(major);
        }

        public async Task<List<Doctor>> GetAllByName(string name)
        {
            return await repo.GetAllByName(name);
        }

        public async Task<List<Doctor>> GetAllByRating(Rating rating)
        {
            return await repo.GetAllByRating(rating);
        }

        public async Task<Doctor> GetById(int id)
        {
            return await repo.GetById(id);
        }

        public async Task<bool> Update(DoctorDTO doctor)
        {
            try
            {
                var existingDoctor = await repo.GetById(doctor.UID);
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

                //return repo.Update(existingDoctor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // New methods implementation
        public async Task<List<Specialization>> GetAllSpecializations()
        {
            return await repo.GetAllSpecializations();
        }

        public async Task<List<Doctor>> GetDoctorsBySpecialization(Specialization specialization)
        {
            return await repo.GetDoctorsBySpecialization(specialization);
        }

        //public async Task<List<WorkingSlot>> GetDoctorWorkingSlots(int doctorId)
        //{
        //    return await repo.GetDoctorWorkingSlots(doctorId);
        //}

        //public List<Room> GetEmptyRoomsInDoctorDepartment(int doctorId)
        //{
        //    return repo.GetEmptyRoomsInDoctorDepartment(doctorId);
        //}

        //public Doctor GetDoctorInfoById(int id)
        //{
        //    return repo.GetById(id);
        //}

        public async Task<bool> EditDoctorInfoById(int id, DoctorDTO doctor)
        {
            try
            {
                var existingDoctor = await repo.GetById(id);
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

                //return repo.Update(existingDoctor);
                return false;
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

        //public bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots)
        //{
        //    return repo.UpdateDoctorWorkingSlots(doctorId, workingSlots);
        //}

        //public bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots)
        //{
        //    return repo.AddWorkingSlotsToDoctor(doctorId, workingSlots);
        //}
    }
}
