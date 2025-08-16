using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.Doctor;
using CCMS.BLL.ModelVM.Patient;
using CCMS.BLL.ModelVM.Room;
using CCMS.BLL.ModelVM.WorkingSlot;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Enums;
using CCMS.DAL.Repository.Abstraction;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepo _doctorRepo;
        private readonly IBookRepo _bookRepo;

        private readonly DoctorMapper doctorMapper = new DoctorMapper();
        private readonly PatientMapper patientMapper = new PatientMapper();
        private readonly WorkingSlotMapper workingSlotMapper = new WorkingSlotMapper();
        private readonly RoomMapper roomMapper = new RoomMapper();

        public DoctorService(IDoctorRepo doctorRepo, IBookRepo bookRepo)
        {
            _doctorRepo = doctorRepo;
            _bookRepo = bookRepo;
        }

        public async Task<string?> Create(CreateDoctor doc, string createdBy)
        {
            try
            {
                Doctor doctor = new Doctor(doc.FName, doc.MidName, doc.LName, doc.Ssn,
                    doc.Gender, doc.BirthDate, PersonType.Employee, doc.Salary,
                    EmployeeType.Doctor, doc.YearsOfExperience, doc.HiringDate,
                    doc.MgrId, doc.AdmId, doc.DeptId, doc.major, doc.rating, createdBy
                );

                await _doctorRepo.Add(doctor);
                await _doctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<string?> Delete(int id, string modifiedBy)
        {
            try
            {
                Doctor doctor = await _doctorRepo.GetById(id);

                doctor.Delete(modifiedBy);
                await _doctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public async Task<(List<DoctorDTO>?, string?)> GetAll()
        {
            try
            {
                List<Doctor> doctors = await _doctorRepo.GetAll();

                if (doctors.Count == 0)
                    return (null, "No data found");

                List<DoctorDTO> docs = doctorMapper.ToListResponseDto(doctors);

                return (docs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<DoctorDTO>?, string?)> GetAllByMajor(Specialization major)
        {
            try
            {
                List<Doctor> doctors = await _doctorRepo.GetAllByMajor(major);

                if (doctors.Count == 0)
                    return (null, "No data found");

                List<DoctorDTO> docs = doctorMapper.ToListResponseDto(doctors);

                return (docs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<DoctorDTO>?, string?)> GetAllByName(string name)
        {
            try
            {
                List<Doctor> doctors = await _doctorRepo.GetAllByName(name);

                if (doctors.Count == 0)
                    return (null, "No data found");

                List<DoctorDTO> docs = doctorMapper.ToListResponseDto(doctors);

                return (docs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<DoctorDTO>?, string?)> GetAllByRating(Rating rating)
        {
            try
            {
                List<Doctor> doctors = await _doctorRepo.GetAllByRating(rating);

                if (doctors.Count == 0)
                    return (null, "No data found");

                List<DoctorDTO> docs = doctorMapper.ToListResponseDto(doctors);

                return (docs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(DoctorDTO?, string?)> GetById(int id)
        {
            try
            {
                Doctor doctor = await _doctorRepo.GetById(id);

                DoctorDTO doc = doctorMapper.ToResponseDto(doctor);

                return (doc, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<string?> Update(DoctorDTO doc, string modifiedBy)
        {
            try
            {
                Doctor doctor = await _doctorRepo.GetById(doc.UID);

                doctor.Edit(
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
                    modifiedBy
                );
                await _doctorRepo.Save();

                return null;
            }
            catch (Exception ex) { return ex.Message; }
        }

        // New methods implementation
        public async Task<(List<Specialization>?, string?)> GetAllSpecializations()
        {
            try
            {
                List<Specialization> specializations = await _doctorRepo.GetAllSpecializations();

                if (specializations.Count == 0)
                    return (null, "No data found");

                return (specializations, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<WorkingSlotDTO>?, string?)> GetDoctorWorkingSlots(int doctorId)
        {
            try
            {
                Doctor doctor = await _doctorRepo.GetById(doctorId);

                List<WorkingSlot> workingSlots = doctor.WorkingSlots;

                if (workingSlots.Count == 0)
                    return (null, "No data found");

                List<WorkingSlotDTO> wSlots = workingSlotMapper.ToListResponseDto(workingSlots);

                return (wSlots, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<RoomDTO>?, string?)> GetEmptyRoomsInDoctorDepartment(int doctorId)
        {
            try
            {
                Doctor doctor = await _doctorRepo.GetById(doctorId);

                if (doctor.Department == null)
                    return (null, "This doctor has not joined a department yet");

                List<Room> rooms = doctor.Department.Rooms
                    .Where(r => !r.IsDeleted && r.rstatus == Rstatus.Available)
                    .ToList();

                if (rooms.Count == 0)
                    return (null, "No data found");

                List<RoomDTO> roomDTOs = roomMapper.ToListResponseDto(rooms);

                return (roomDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
        }

        public async Task<(List<PatientDTO>?, string?)> GetPatientsWithBooksByDoctor(int doctorId)
        {
            try
            {
                List<Book> books = await _bookRepo.GetAll();

                List<Patient> patientsOfDocBooks = books
                    .Where(bk => bk.DoctorId == doctorId)
                    .Select(bk => bk.Patient)
                    .ToList();

                if (patientsOfDocBooks.Count == 0)
                    return (null, "No data found");

                List<PatientDTO> patientDTOs = patientMapper.ToDTOList(patientsOfDocBooks);

                return (patientDTOs, null);
            }
            catch (Exception ex) { return (null, ex.Message); }
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
