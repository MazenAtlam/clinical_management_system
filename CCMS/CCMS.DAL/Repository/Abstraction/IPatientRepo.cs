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
    }
}
