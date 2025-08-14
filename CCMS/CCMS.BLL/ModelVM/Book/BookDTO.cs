namespace CCMS.BLL.ModelVM.Book
{
    public class BookDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string? Prescription { get; set; }
        public DateTime BookDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        
        public string RoomNumber { get; set; }
    }
}
