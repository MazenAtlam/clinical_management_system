using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.FamilyMember
{
    public class CreateFamilyMemberDTO
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int SSN { get; set; }
        public string Phone { get; set; }
    }
}
