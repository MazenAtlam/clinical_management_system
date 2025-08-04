using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Person
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MidName { get; set; }
        public string LName { get; set; }
        public string SSN { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
