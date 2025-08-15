using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Patient
{
    public class PatientDTO
    {
        public int UID { get; set; }
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public BloodType BloodType { get; set; }
    }
}
