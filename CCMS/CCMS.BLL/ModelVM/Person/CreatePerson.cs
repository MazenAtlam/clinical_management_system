using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Person
{
    public class CreatePerson
    {
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
