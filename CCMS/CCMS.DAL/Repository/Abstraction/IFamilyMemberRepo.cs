using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IFamilyMemberRepo
    {
        public Task Add(FamilyMember familyMember);
        public Task<FamilyMember> GetById(int id);
        public Task<List<FamilyMember>> GetAll();
        public Task Save();
    }
}