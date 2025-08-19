using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.FamilyMember
{
    public class CreateFamilyMemberDTO
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Ssn { get; set; }
        public string PhoneNumber { get; set; }
    }
}
