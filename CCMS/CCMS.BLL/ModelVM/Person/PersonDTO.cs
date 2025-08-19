using CCMS.BLL.ModelVM.User;
using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Person
{
    public class PersonDTO : UserDTO
    {
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public string CreatedBy { get; set; }

        public string GetFullName() => FName + (MidName == null ? " " : $" {MidName} ") + LName;
    }
}
