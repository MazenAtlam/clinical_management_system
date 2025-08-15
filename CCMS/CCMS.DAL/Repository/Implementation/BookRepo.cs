using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;

namespace CCMS.DAL.Repository.Implementation
{
    public class BookRepo : IBookRepo
    {
        private readonly CcmsDbContext db;

        public BookRepo(CcmsDbContext db) => this.db = db;

        public async Task Add(Book book) => db.books.Add(book);

        public async Task<List<Book>> GetAll() => db.books.Where(a => !a.IsDeleted).ToList();

        public async Task<Book> GetById(int id)
        {
            Book? book =  db.books.Where(a => a.Id == id && !a.IsDeleted).FirstOrDefault();

            return book == null
                ? throw new ArgumentException($"There is no book with the ID = {id}", "id") 
                : book;
        }

        public async Task Save(int id) => db.SaveChanges();

        // New methods implementation
        // In BookService
        //public async Task<bool> CreateBookWithFixedPriceAsync(int patientId, int doctorId, string roomNumber, DateTime bookDate, string prescription, string createdBy)
        //{
        //    try
        //    {
        //        const double fixedPrice = 80.0;
        //        var book = new Book(fixedPrice, prescription, bookDate, patientId, doctorId, roomNumber, createdBy);
        //        await db.books.AddAsync(book);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        // In BookService
        //public async Task<List<Patient>> GetPatientsWithBooksByDoctorAsync(int doctorId)
        //{
        //    return await db.patients
        //        .Include(p => p.Books.Where(b => b.DoctorId == doctorId && b.IsDeleted == false))
        //        .Include(p => p.Scans.Where(s => s.IsDeleted == false))
        //        .Include(p => p.MedicalHistories.Where(mh => mh.IsDeleted == false))
        //        .Include(p => p.PatientFamilyMembers.Where(pf => pf.IsDeleted == false))
        //        .ThenInclude(pf => pf.FamilyMember)
        //        .Where(p => p.IsDeleted == false && p.Books.Any(b => b.DoctorId == doctorId && b.IsDeleted == false))
        //        .ToListAsync();
        //}

        // In BookService
        //public async Task<bool> AddPrescriptionToPatientBookAsync(int bookId, string prescription, string modifiedBy)
        //{
        //    try
        //    {
        //        var book = await db.books.FirstOrDefaultAsync(b => b.Id == bookId);
        //        if (book == null)
        //            return false;

        //        book.Edit(book.Price, prescription, book.BookDate, book.PatientId, book.DoctorId, book.RNumber, modifiedBy);
        //        await db.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}