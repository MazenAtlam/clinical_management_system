using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IScanRepo
    {
        Task<bool> CreateAsync(Scan scan);
        Task<Scan> GetByIdAsync(int id);
        Task<List<Scan>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Scan scan);
    }
}