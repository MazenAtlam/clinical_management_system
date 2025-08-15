namespace CCMS.BLL.ModelVM.Book
{
    public class CreateBookDTO
    {
        public double Price { get; set; }
        public string? Prescription { get; set; }
        public DateTime BookDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string RNumber { get; set; }
        public string CreatedBy { get; set; }
    }
}
