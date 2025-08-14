using CCMS.DAL.Entities;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IBookRepo
    {
        public Task Add(Book book);
        public Task<Book> GetById(int id);
        public Task<List<Book>> GetAll();
        public Task Save(int id);
        
        // New methods
        //public Task<bool> CreateBookWithFixedPriceAsync(int patientId, int doctorId, string roomNumber, DateTime bookDate, string prescription, string createdBy);
        //public Task<List<Patient>> GetPatientsWithBooksByDoctorAsync(int doctorId);
        //public Task<bool> AddPrescriptionToPatientBookAsync(int bookId, string prescription, string modifiedBy);
    }
}