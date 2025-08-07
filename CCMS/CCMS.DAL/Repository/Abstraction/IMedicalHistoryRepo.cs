using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IMedicalHistoryRepo
    {
        Task<bool> CreateAsync(MedicalHistory medicalHistory);
        Task<MedicalHistory> GetByIdAsync(int id);
        Task<List<MedicalHistory>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(MedicalHistory medicalHistory, string modifiedBy);
    }
}