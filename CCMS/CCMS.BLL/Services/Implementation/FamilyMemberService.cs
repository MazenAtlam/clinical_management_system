using CCMS.BLL.ModelVM.FamilyMember;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<FamilyMemberDTO>> GetAllFamilyMembersAsync()
        {
            var members = await _familyMemberRepo.GetAllAsync();
            return _familyMemberMapper.ToDTOList(members);
        }
    }
}
