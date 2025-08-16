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

        public async Task Add(Doctor doctor) => db.doctors.Add(doctor);

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

        public async Task<List<Specialization>> GetAllSpecializations()
            => Enum.GetValues(typeof(Specialization))
            .Cast<Specialization>()
            .ToList();

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
