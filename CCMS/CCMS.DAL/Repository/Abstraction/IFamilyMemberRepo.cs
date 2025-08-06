using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IFamilyMemberRepo
    {
        Task<bool> CreateAsync(FamilyMember familyMember);
        Task<FamilyMember> GetByIdAsync(int id);
        Task<List<FamilyMember>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(FamilyMember familyMember);
    }
}