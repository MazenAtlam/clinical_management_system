using CCMS.DAL.Enums;

namespace CCMS.DAL.Entities
{
    public class FamilyMember : Base
    {
        public int Id { get; set; }
        public string  name { get; set; }
        public Gender Gender { get; set; }
        public int SSN { get; set; }
        public string phone { get; set; }

        //navigation
        public List<PateintfFamilyJoin> pateintfFamily { get; set; }
    }
}
