using CCMS.BLL.ModelVM.FamilyMember;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using System.Collections.Generic;

namespace CCMS.BLL.Services.Implementation
{
    public class FamilyMemberService
    {
        private readonly IFamilyMemberRepo _familyMemberRepo;
        private readonly FamilyMemberMapper _familyMemberMapper;

        public FamilyMemberService(IFamilyMemberRepo familyMemberRepo, FamilyMemberMapper familyMemberMapper)
        {
            _familyMemberRepo = familyMemberRepo;
            _familyMemberMapper = familyMemberMapper;
        }

        public List<FamilyMemberDTO> GetAllFamilyMembers()
        {
            var members = _familyMemberRepo.GetAll();
            return _familyMemberMapper.ToDTOList(members);
        }
    }
}
