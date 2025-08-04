using Riok.Mapperly.Abstractions;
using CCMS.DAL.Entities;
using CCMS.BLL.ModelVM.FamilyMember;
using System.Collections.Generic;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class FamilyMemberMapper
    {
        public partial FamilyMemberDTO ToDTO(FamilyMember member);
        public partial List<FamilyMemberDTO> ToDTOList(List<FamilyMember> members);
        // Reverse mapping
        public partial FamilyMember ToEntity(FamilyMemberDTO dto);
        public partial List<FamilyMember> ToEntityList(List<FamilyMemberDTO> dtos);
    }
}
