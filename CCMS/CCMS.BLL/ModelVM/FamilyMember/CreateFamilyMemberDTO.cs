using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.FamilyMember
{
    public class CreateFamilyMemberDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Ssn { get; set; }
        public string Phone { get; set; }
    }
}
