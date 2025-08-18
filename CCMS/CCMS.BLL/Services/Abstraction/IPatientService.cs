using CCMS.BLL.ModelVM.Patient;
using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IPatientService
    {
        Task<bool> Create(PatientDTO patient, string createdBy);
        Task<bool> Update(PatientDTO patient);
        //Task<bool> Delete(string id);
        Task<Patient> GetById(string id);
        Task<List<Patient>> GetAll();
        List<Patient> GetPatientsByDoctor(string doctorId);
        List<Book> GetPatientAppointments(string patientId);
        Task<bool> RateDoctor(string patientId, string doctorId, int rating);
        
        // New methods
        //Patient GetPatientInfoById(string id);
        //bool EditPatientById(string id, PatientDTO patient);
        //List<FamilyMember> GetFamilyMembersOfPatient(int patientId);
        //bool AddFamilyMemberToPatient(int patientId, FamilyMember familyMember);
        //List<MedicalHistory> GetMedicalHistoryOfPatient(int patientId);
        //bool AddMedicalHistoryToPatient(int patientId, MedicalHistory medicalHistory);
        //List<Scan> GetScansOfPatient(int patientId);
        //bool AddScanToPatient(int patientId, Scan scan);
        //List<Book> GetAllBooksOfPatient(int patientId);
    }
}
