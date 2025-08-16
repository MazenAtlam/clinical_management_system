using CCMS.BLL.ModelVM.Patient;
using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IPatientService
    {
        Task<bool> Create(PatientDTO patient);
        Task<bool> Update(PatientDTO patient);
        //Task<bool> Delete(int id);
        Task<Patient> GetById(int id);
        Task<List<Patient>> GetAll();
        List<Patient> GetPatientsByDoctor(int doctorId);
        Task<List<Book>> GetPatientAppointments(int patientId);
        Task<bool> RateDoctor(int patientId, int doctorId, int rating);
        
        // New methods
        //Patient GetPatientInfoById(int id);
        //bool EditPatientById(int id, PatientDTO patient);
        Task<List<FamilyMember>> GetFamilyMembersOfPatient(int patientId);
        Task<List<(FamilyMember FamilyMember, string Relationship)>> GetFamilyMembersWithRelationshipOfPatient(int patientId);
        Task<List<Scan>> GetScansOfPatient(int patientId);
        Task<List<MedicalHistory>> GetMedicalHistoryOfPatient(int patientId);
        List<string> GetAllSpecializations();
        Task<bool> CreateBookAsync(CCMS.BLL.ModelVM.Book.CreateBookDTO bookDto);
        Task<bool> AddFamilyMemberToPatient(int patientId, string name, string ssn, string phoneNumber, string gender, string relationship);
        Task<bool> AddMedicalHistoryToPatient(int patientId, string diseaseName, bool familyHistory);
        //List<MedicalHistory> GetMedicalHistoryOfPatient(int patientId);
        //bool AddMedicalHistoryToPatient(int patientId, MedicalHistory medicalHistory);
        //bool AddFamilyMemberToPatient(int patientId, FamilyMember familyMember);
        //bool AddScanToPatient(int patientId, Scan scan);
        //List<Book> GetAllBooksOfPatient(int patientId);
    }
}
