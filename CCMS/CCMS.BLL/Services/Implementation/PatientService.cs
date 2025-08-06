using CCMS.BLL.ModelVM.Patient;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.ModelVM.FamilyMember;
using CCMS.BLL.ModelVM.MedicalHistory;
using CCMS.BLL.ModelVM.Scan;
using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Implementation
{
    public class PatientService
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IBookRepo _bookRepo;
        private readonly IFamilyMemberRepo _familyMemberRepo;
        private readonly IPateintFamilyJoinRepo _pateintFamilyJoinRepo;
        private readonly IMedicalHistoryRepo _medicalHistoryRepo;
        private readonly IScanRepo _scanRepo;
        private readonly PatientMapper _patientMapper;
        private readonly MedicalHistoryMapper _medicalHistoryMapper;
        private readonly ScanMapper _scanMapper;
        private readonly BookMapper _bookMapper;
        private readonly FamilyMemberMapper _familyMemberMapper;

        public PatientService(
            IPatientRepo patientRepo,
            IBookRepo bookRepo,
            IFamilyMemberRepo familyMemberRepo,
            IPateintFamilyJoinRepo pateintFamilyJoinRepo,
            IMedicalHistoryRepo medicalHistoryRepo,
            IScanRepo scanRepo,
            PatientMapper patientMapper,
            MedicalHistoryMapper medicalHistoryMapper,
            ScanMapper scanMapper,
            BookMapper bookMapper,
            FamilyMemberMapper familyMemberMapper)
        {
            _patientRepo = patientRepo;
            _bookRepo = bookRepo;
            _familyMemberRepo = familyMemberRepo;
            _pateintFamilyJoinRepo = pateintFamilyJoinRepo;
            _medicalHistoryRepo = medicalHistoryRepo;
            _scanRepo = scanRepo;
            _patientMapper = patientMapper;
            _medicalHistoryMapper = medicalHistoryMapper;
            _scanMapper = scanMapper;
            _bookMapper = bookMapper;
            _familyMemberMapper = familyMemberMapper;
        }

        public async Task<List<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _patientRepo.GetAllAsync();
            return _patientMapper.ToDTOList(patients);
        }

        public async Task<PatientDTO?> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);
            return patient == null ? null : _patientMapper.ToDTO(patient);
        }

        public async Task<bool> EditPatientAsync(int id, PatientDTO dto)
        {
            var patient = await _patientRepo.GetByIdAsync(id);
            if (patient == null) return false;
            patient.Edit(
                dto.FName,
                dto.MidName,
                dto.LName,
                dto.SSN,
                (DAL.Enums.Gender)Enum.Parse(typeof(DAL.Enums.Gender), dto.Gender),
                dto.BirthDate,
                dto.BloodType
            );
            return await _patientRepo.UpdateAsync(patient);
        }

        public async Task<bool> CreateBookAsync(CreateBookDTO dto)
        {
            var book = _patientMapper.ToBook(dto);
            return await _bookRepo.CreateAsync(book);
        }

        public async Task<List<FamilyMemberDTO>> GetFamilyMembersByPatientIdAsync(int patientId)
        {
            var joins = (await _pateintFamilyJoinRepo.GetAllAsync()).Where(j => j.PatientId == patientId).ToList();
            var familyMembers = joins.Select(j => j.FamilyMember).ToList();
            return _familyMemberMapper.ToDTOList(familyMembers);
        }

        public async Task<bool> AddFamilyMemberToPatientAsync(CreateFamilyMemberDTO dto, int patientId, string relationship)
        {
            var familyMember = _patientMapper.ToFamilyMember(dto);
            var created = await _familyMemberRepo.CreateAsync(familyMember);
            if (!created) return false;
            var join = new PateintFamilyJoin();
            join.Edit(relationship, patientId, familyMember.Id);
            return await _pateintFamilyJoinRepo.CreateAsync(join);
        }

        public async Task<List<MedicalHistoryDTO>> GetAllMedicalHistoryByPatientIdAsync(int patientId)
        {
            var histories = (await _medicalHistoryRepo.GetAllAsync()).Where(h => h.PatientId == patientId).ToList();
            return _medicalHistoryMapper.ToDTOList(histories);
        }

        public async Task<bool> AddMedicalHistoryToPatientAsync(MedicalHistoryDTO dto)
        {
            var history = new MedicalHistory();
            history.Edit(dto.FamilyHistory, dto.DiseaseName, dto.PatientId);
            return await _medicalHistoryRepo.CreateAsync(history);
        }

        public async Task<List<ScanDTO>> GetAllScansByPatientIdAsync(int patientId)
        {
            var scans = (await _scanRepo.GetAllAsync()).Where(s => s.PatientId == patientId).ToList();
            return _scanMapper.ToDTOList(scans);
        }

        public async Task<List<(BookDTO Book, string DoctorName)>> GetAllBooksByPatientIdWithDoctorNameAsync(int patientId)
        {
            var books = (await _bookRepo.GetAllAsync()).Where(b => b.PatientId == patientId).ToList();
            return books.Select(b => (_bookMapper.ToDTO(b), b.Doctor != null ? b.Doctor.FName + " " + b.Doctor.LName : "")).ToList();
        }

        public async Task<bool> EditBookPrescriptionAsync(int bookId, string newPrescription)
        {
            var book = await _bookRepo.GetByIdAsync(bookId);
            if (book == null) return false;
            book.Edit(book.price, book.BookDate, book.PatientId, book.DoctorId, book.RoomId, newPrescription);
            return await _bookRepo.UpdateAsync(book);
        }

        public async Task<List<PatientDTO>> GetAllPatientsWithBookByDoctorIdAsync(int doctorId)
        {
            var books = (await _bookRepo.GetAllAsync()).Where(b => b.DoctorId == doctorId).ToList();
            var patientIds = books.Select(b => b.PatientId).Distinct().ToList();
            var patients = (await _patientRepo.GetAllAsync()).Where(p => patientIds.Contains(p.Id)).ToList();
            return _patientMapper.ToDTOList(patients);
        }
    }
}
