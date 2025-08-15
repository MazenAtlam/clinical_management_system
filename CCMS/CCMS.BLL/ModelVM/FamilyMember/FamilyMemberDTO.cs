using System;

namespace CCMS.BLL.ModelVM.FamilyMember
{
    public class FamilyMemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Ssn { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
    }
}
