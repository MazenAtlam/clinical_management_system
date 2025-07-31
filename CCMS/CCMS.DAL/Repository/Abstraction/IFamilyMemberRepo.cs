using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IFamilyMemberRepo
    {
        bool Create(FamilyMember familyMember);
        FamilyMember GetById(int id);
        List<FamilyMember> GetAll();
        bool Delete(int id);
        bool Update(FamilyMember familyMember);
    }
}