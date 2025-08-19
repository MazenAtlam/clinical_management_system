using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPatientFamilyRepo
    {
        public Task Add(PatientFamily patientFamily);
        public Task<PatientFamily> GetByIds(string patientId, int familyMemberId);
        public Task Save();
    }
}