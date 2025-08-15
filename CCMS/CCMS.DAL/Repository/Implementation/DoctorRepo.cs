using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly CcmsDbContext db;
        
        public DoctorRepo(CcmsDbContext db) => this.db = db;

        public async Task Create(Doctor doctor) => db.doctors.Add(doctor);

        // In DoctorService
        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var doctor = db.doctors.FirstOrDefault(a => a.UID == id);
        //        if (doctor == null)
        //            return false;
                
        //        doctor.Delete("admin");
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error deleting doctor: {ex}");
        //        return false;
        //    }
        //}

        public async Task<List<Doctor>> GetAll() => db.doctors.Where(a => !a.IsDeleted).ToList();

        public async Task<List<Doctor>> GetAllByMajor(Specialization major)
            => db.doctors.Where(a => !a.IsDeleted && a.major == major).ToList();

        public async Task<List<Doctor>> GetAllByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
                    
            List<Doctor> doctors = db.doctors
                .Where(a => !a.IsDeleted && a.GetFullName().Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (doctors.Count == 0)
                throw new ArgumentException($"There is no doctors have the name {name}.", "name");

            return doctors;
        }

        public async Task<List<Doctor>> GetAllByRating(Rating rating)
        {
            List<Doctor> doctors = db.doctors.Where(a => !a.IsDeleted && a.rating == rating).ToList();

            if (doctors.Count == 0)
                throw new ArgumentException($"There is no doctors have the rating {rating}.", "rating");

            return doctors;
        }

        public async Task<Doctor> GetById(int id)
        {
            Doctor? doctor = db.doctors.Where(a => a.UID == id && !a.IsDeleted).FirstOrDefault();
            
            return doctor == null
                ? throw new ArgumentException($"There is no doctors with the ID = {id}", "id")
                : doctor;
        }

        public async Task Save() => db.SaveChanges();

        // In DoctorService
        //public bool Update(Doctor doctor)
        //{
        //    try
        //    {
        //        var existingDoctor = db.doctors.FirstOrDefault(a => a.UID == doctor.UID && !a.IsDeleted);
        //        if (existingDoctor == null)
        //            return false;

        //        // Use the entity's Edit method to update properties
        //        existingDoctor.Edit(
        //            doctor.FName,
        //            doctor.MidName,
        //            doctor.LName,
        //            doctor.Ssn,
        //            doctor.Gender,
        //            doctor.BirthDate,
        //            doctor.Salary,
        //            doctor.YearsOfExperience,
        //            doctor.HiringDate,
        //            doctor.MgrId,
        //            doctor.DeptId,
        //            doctor.major,
        //            doctor.rating,
        //            doctor.ModifiedBy ?? "admin"
        //        );

        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error updating doctor: {ex}");
        //        return false;
        //    }
        //}

        public async Task<List<Specialization>> GetAllSpecializations()
            => Enum.GetValues(typeof(Specialization))
            .Cast<Specialization>()
            .ToList();

        public async Task<List<Doctor>> GetDoctorsBySpecialization(Specialization specialization)
        {
            List<Doctor> doctors = db.doctors.Where(d => !d.IsDeleted && d.major == specialization).ToList();

            if (doctors.Count == 0)
                throw new ArgumentException($"This specialization has no doctors yet.", "specialization");

            return doctors;
        }

        // In EmployeeService
        //public List<WorkingSlot> GetDoctorWorkingSlots(int doctorId)
        //{
        //    try
        //    {
        //        var doctor = db.doctors.Include(d => d.WorkingSlots)
        //            .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
        //        return doctor?.WorkingSlots?.Where(ws => !ws.IsDeleted).ToList() ?? new List<WorkingSlot>();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error getting doctor working slots: {ex}");
        //        return new List<WorkingSlot>();
        //    }
        //}

        // In DoctorService
        //public List<Room> GetEmptyRoomsInDoctorDepartment(int doctorId)
        //{
        //    try
        //    {
        //        var doctor = db.doctors.Include(d => d.Department)
        //            .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
        //        if (doctor?.Department == null)
        //            return new List<Room>();

        //        return db.rooms.Where(r => !r.IsDeleted && 
        //                                 r.DeptId == doctor.Department.ID && 
        //                                 r.rstatus == Rstatus.Available)
        //                     .ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error getting empty rooms: {ex}");
        //        return new List<Room>();
        //    }
        //}

        // In DoctorService
        //public bool UpdateDoctorWorkingSlots(int doctorId, List<WorkingSlot> workingSlots)
        //{
        //    try
        //    {
        //        var doctor = db.doctors.Include(d => d.WorkingSlots)
        //            .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
        //        if (doctor == null)
        //            return false;

        //        // Soft delete existing slots
        //        foreach (var existingSlot in doctor.WorkingSlots.Where(w => !w.IsDeleted))
        //        {
        //            existingSlot.Delete("admin");
        //        }

        //        // Add new slots
        //        foreach (var slot in workingSlots)
        //        {
        //            doctor.WorkingSlots.Add(slot);
        //        }

        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error updating doctor working slots: {ex}");
        //        return false;
        //    }
        //}

        // In DoctorService
        //public bool AddWorkingSlotsToDoctor(int doctorId, List<WorkingSlot> workingSlots)
        //{
        //    try
        //    {
        //        var doctor = db.doctors.Include(d => d.WorkingSlots)
        //            .FirstOrDefault(d => d.UID == doctorId && !d.IsDeleted);
        //        if (doctor == null)
        //            return false;

        //        foreach (var slot in workingSlots)
        //        {
        //            doctor.WorkingSlots.Add(slot);
        //        }

        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Error adding working slots to doctor: {ex}");
        //        return false;
        //    }
        //}
    }
}
