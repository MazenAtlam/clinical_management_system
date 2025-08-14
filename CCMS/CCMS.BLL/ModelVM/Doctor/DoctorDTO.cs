using CCMS.DAL.Enums;

namespace CCMS.BLL.ModelVM.Doctor
{
    public class DoctorDTO
    {
        public int UID { get; set; }
        public string FName { get; set; }
        public string? MidName { get; set; }
        public string LName { get; set; }
        public string Ssn { get; set; }
        public Gender Gender { get; set; }
        public DateOnly BirthDate { get; set; }
        public decimal Salary { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime HiringDate { get; set; }
        public int? MgrId { get; set; }
        public int? AdmId { get; set; }
        public int? DeptId { get; set; }
        public Specialization major { get; set; }
        public Rating rating { get; set; }
    }
}
