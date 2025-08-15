using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPatientRepo
    {
        Task<bool> CreateAsync(Patient patient);
        Task<Patient> GetByIdAsync(int id);
        Task<List<Patient>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Patient patient);
        
        // New methods
        Task<Patient> GetPatientInfoByIdAsync(int id);
        Task<bool> EditPatientByIdAsync(int id, Patient patient);
        Task<List<FamilyMember>> GetFamilyMembersOfPatientAsync(int patientId);
        Task<bool> AddFamilyMemberToPatientAsync(int patientId, FamilyMember familyMember);
        Task<List<MedicalHistory>> GetMedicalHistoryOfPatientAsync(int patientId);
        Task<bool> AddMedicalHistoryToPatientAsync(int patientId, MedicalHistory medicalHistory);
        Task<List<Scan>> GetScansOfPatientAsync(int patientId);
        Task<bool> AddScanToPatientAsync(int patientId, Scan scan);
        Task<List<Book>> GetAllBooksOfPatientAsync(int patientId);
    }
}
