using CCMS.BLL.ModelVM.Book;
using CCMS.BLL.Services.Abstraction;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.BLL.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepo bookRepo;
        private readonly IPatientRepo patientRepo;
        private readonly IDoctorRepo doctorRepo;
        private readonly IRoomRepo roomRepo;
        //private readonly INotificationService notificationService;

        public BookService(IBookRepo bookRepo, IPatientRepo patientRepo, IDoctorRepo doctorRepo, IRoomRepo roomRepo/*, INotificationService notificationService*/)
        {
            this.bookRepo = bookRepo;
            this.patientRepo = patientRepo;
            this.doctorRepo = doctorRepo;
            this.roomRepo = roomRepo;
            //this.notificationService = notificationService;
        }

        public async Task Create(CreateBookDTO book)
        {
            try
            {
                var newBook = new Book(
                    book.Price,
                    book.Prescription,
                    book.BookDate,
                    book.PatientId,
                    book.DoctorId,
                    book.RNumber,
                    "admin"
                );
                await bookRepo.Add(newBook);
            }
            catch
            {
                //return false;
            }
        }

        public bool Update(BookDTO book)
        {
            try
            {
                //var existingBook = bookRepo.GetByIdAsync(book.Id).Result;
                //if (existingBook == null)
                //    return false;

                //existingBook.Edit(
                //    book.Price,
                //    book.Prescription,
                //    book.BookDate,
                //    book.PatientId,
                //    book.DoctorId,
                //    book.RoomNumber,
                //    "admin"
                //);

                //return bookRepo.UpdateAsync(existingBook, "admin").Result;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            //return bookRepo.DeleteAsync(id).Result;
            return true;
        }

        public Book? GetById(int id)
        {
            //return bookRepo.GetByIdAsync(id).Result;
            return null;
        }

        public List<Book> GetAll()
        {
            //return bookRepo.GetAllAsync().Result;
            return new List<Book>();
        }

        public List<Book> GetByPatient(int patientId)
        {
            //return patientRepo.GetAllBooksOfPatientAsync(patientId).Result;
            return new List<Book>();
        }

        public List<Book> GetByDoctor(int doctorId)
        {
            //return bookRepo.GetAllAsync().Result.FindAll(b => b.DoctorId == doctorId);
            return new List<Book>();
        }

        public List<Book> GetByDate(DateTime date)
        {
            //return bookRepo.GetAllAsync().Result.FindAll(b => b.BookDate.Date == date.Date);
            return new List<Book>();
        }

        public bool CancelAppointment(int bookId)
        {
            //return bookRepo.DeleteAsync(bookId).Result;
            return true;
        }

        // New methods implementation
        public bool CreateBookWithFixedPrice(int patientId, int doctorId, string roomNumber, DateTime bookDate, string prescription)
        {
            //return bookRepo.CreateBookWithFixedPriceAsync(patientId, doctorId, roomNumber, bookDate, prescription, "admin").Result;
            return true;
        }

        public bool AddPrescriptionToPatientBook(int bookId, string prescription)
        {
            //return bookRepo.AddPrescriptionToPatientBookAsync(bookId, prescription, "admin").Result;
            return true;
        }
    }
}
