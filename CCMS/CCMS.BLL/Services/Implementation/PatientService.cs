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

        public List<PatientDTO> GetAllPatients()
        {
            var patients = _patientRepo.GetAll();
            return _patientMapper.ToDTOList(patients);
        }

        public PatientDTO GetPatientById(int id)
        {
            var patient = _patientRepo.GetById(id);
            return patient == null ? null : _patientMapper.ToDTO(patient);
        }

        public bool EditPatient(int id, PatientDTO dto)
        {
            // Retrieve the patient entity from the repository by its ID
            var patient = _patientRepo.GetById(id);
            // If the patient does not exist, return false
            if (patient == null) return false;
            // Update the patient entity with new values from the DTO
            patient.Edit(
                dto.FName, // Update first name
                dto.MidName, // Update middle name
                dto.LName, // Update last name
                dto.SSN, // Update SSN
                (DAL.Enums.Gender)Enum.Parse(typeof(DAL.Enums.Gender), dto.Gender), // Update gender (parsed from string)
                dto.BirthDate, // Update birth date
                dto.BloodType // Update blood type
            );
            // Save the updated patient entity to the repository
            return _patientRepo.Update(patient);
        }

        public bool CreateBook(CreateBookDTO dto)
        {
            var book = _patientMapper.ToBook(dto);
            return _bookRepo.Create(book);
        }

        // Use Mapperly for mapping FamilyMember to FamilyMemberDTO
        public List<FamilyMemberDTO> GetFamilyMembersByPatientId(int patientId)
        {
            // Get all join records for the patient
            var joins = _pateintFamilyJoinRepo.GetAll().Where(j => j.PatientId == patientId).ToList();
            // Extract the related FamilyMember entities
            var familyMembers = joins.Select(j => j.FamilyMember).ToList();
            // Use Mapperly to map to DTOs
            return _familyMemberMapper.ToDTOList(familyMembers);
        }

        public bool AddFamilyMemberToPatient(CreateFamilyMemberDTO dto, int patientId, string relationship)
        {
            // Map the DTO to a FamilyMember entity
            var familyMember = _patientMapper.ToFamilyMember(dto);

            // Create the new FamilyMember in the repository
            var created = _familyMemberRepo.Create(familyMember);

            // If creation failed, return false
            if (!created) return false;

            // Use the ID from the just-created familyMember
            var join = new PateintFamilyJoin();
            join.Edit(relationship, patientId, familyMember.Id);

            // Save the join entity to the repository
            return _pateintFamilyJoinRepo.Create(join);
        }

        // 1. Get all medical history for a patient
        public List<MedicalHistoryDTO> GetAllMedicalHistoryByPatientId(int patientId)
        {
            // Get all medical histories and filter by patientId
            var histories = _medicalHistoryRepo.GetAll().Where(h => h.PatientId == patientId).ToList();
            // Map to DTOs
            return _medicalHistoryMapper.ToDTOList(histories);
        }

        // 2. Add medical history to a patient
        public bool AddMedicalHistoryToPatient(MedicalHistoryDTO dto)
        {
            // Create a new MedicalHistory entity and set its properties
            var history = new MedicalHistory();
            history.Edit(dto.FamilyHistory, dto.DiseaseName, dto.PatientId);
            // Save to repository
            return _medicalHistoryRepo.Create(history);
        }

        // 3. Get all scans for a patient
        public List<ScanDTO> GetAllScansByPatientId(int patientId)
        {
            // Get all scans and filter by patientId
            var scans = _scanRepo.GetAll().Where(s => s.PatientId == patientId).ToList();
            // Map to DTOs
            return _scanMapper.ToDTOList(scans);
        }

        // 4. Get all books by patient id (including doctor name)
        public List<(BookDTO Book, string DoctorName)> GetAllBooksByPatientIdWithDoctorName(int patientId)
        {
            // Get all books for the patient
            var books = _bookRepo.GetAll().Where(b => b.PatientId == patientId).ToList();
            // Map to DTOs and include doctor name
            return books.Select(b => (_bookMapper.ToDTO(b), b.Doctor != null ? b.Doctor.FName + " " + b.Doctor.LName : "")).ToList();
        }

        // 5. Edit book info (edit the prescription only)
        public bool EditBookPrescription(int bookId, string newPrescription)
        {
            // Get the book by id
            var book = _bookRepo.GetById(bookId);
            if (book == null) return false;
            // Use the Edit method to update only the prescription
            book.Edit(book.price, book.BookDate, book.PatientId, book.DoctorId, book.RoomId, newPrescription);
            // Save changes
            return _bookRepo.Update(book);
        }

        // 6. Get all patients that have a book with a doctor using doctor id
        public List<PatientDTO> GetAllPatientsWithBookByDoctorId(int doctorId)
        {
            // Get all books with the given doctorId
            var books = _bookRepo.GetAll().Where(b => b.DoctorId == doctorId).ToList();
            // Get unique patient ids
            var patientIds = books.Select(b => b.PatientId).Distinct().ToList();
            // Get patients and map to DTOs
            var patients = _patientRepo.GetAll().Where(p => patientIds.Contains(p.Id)).ToList();
            return _patientMapper.ToDTOList(patients);
        }
    }
}
