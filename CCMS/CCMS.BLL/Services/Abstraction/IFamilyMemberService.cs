using CCMS.BLL.ModelVM.FamilyMember;
using CCMS.DAL.Entities;

namespace CCMS.BLL.Services.Abstraction
{
    public interface IFamilyMemberService
    {
        bool Create(CreateFamilyMemberDTO familyMember);
        bool Update(FamilyMemberDTO familyMember);
        bool Delete(int id);
        FamilyMember GetById(int id);
        List<FamilyMember> GetAll();
        List<FamilyMember> GetByPatient(int patientId);
    }
}
