using CCMS.BLL.ModelVM.Patient;
using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IPatientService
    {
        bool Create(PatientDTO patient);
        bool Update(PatientDTO patient);
        bool Delete(int id);
        Patient GetById(int id);
        List<Patient> GetAll();
        List<Patient> GetPatientsByDoctor(int doctorId);
        List<Book> GetPatientAppointments(int patientId);
        bool RateDoctor(int patientId, int doctorId, int rating);
        
        // New methods
        Patient GetPatientInfoById(int id);
        bool EditPatientById(int id, PatientDTO patient);
        List<FamilyMember> GetFamilyMembersOfPatient(int patientId);
        bool AddFamilyMemberToPatient(int patientId, FamilyMember familyMember);
        List<MedicalHistory> GetMedicalHistoryOfPatient(int patientId);
        bool AddMedicalHistoryToPatient(int patientId, MedicalHistory medicalHistory);
        List<Scan> GetScansOfPatient(int patientId);
        bool AddScanToPatient(int patientId, Scan scan);
        List<Book> GetAllBooksOfPatient(int patientId);
    }
}
