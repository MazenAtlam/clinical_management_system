using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPatientFamilyRepo
    {
        Task<bool> CreateAsync(PatientFamily join);
        Task<PatientFamily> GetByIdAsync(int id);
        Task<List<PatientFamily>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(PatientFamily joinKeys);
    }
}