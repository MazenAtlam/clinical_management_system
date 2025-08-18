namespace CCMS.BLL.ModelVM.Book
{
    public class CreateBookDTO
    {
        public double Price { get; set; }
        public string? Prescription { get; set; }
        public DateTime BookDate { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string RNumber { get; set; }
    }
}
