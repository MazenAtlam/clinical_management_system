using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IPateintFamilyJoinRepo
    {
        Task<bool> CreateAsync(PateintFamilyJoin join);
        Task<PateintFamilyJoin> GetByIdAsync(int id);
        Task<List<PateintFamilyJoin>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(PateintFamilyJoin joinKeys);
    }
}