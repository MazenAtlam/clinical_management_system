using System;

namespace CCMS.BLL.ModelVM.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string SSN { get; set; }
        public string BloodType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
    }
}
