using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using System.Collections.Generic;
using System.Linq;

namespace CCMS.DAL.Repository.Implementation
{
    public class BookRepo : IBookRepo
    {
        private readonly CcmsDbContext db;

        public BookRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public bool Create(Book book)
        {
            try
            {
                db.books.Add(book);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var book = db.books.FirstOrDefault(a => a.Id == id);
                if (book == null)
                    return false;
                book.Delete("admin");
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Book> GetAll()
        {
            return db.books.Where(a => a.IsDeleted == false).ToList();
        }

        public Book GetById(int id)
        {
            return db.books.FirstOrDefault(a => a.Id == id);
        }

        public bool Update(Book book)
        {
            try
            {
                var b = db.books.FirstOrDefault(a => a.Id == book.Id);
                if (b == null)
                    return false;
                b.Edit(book.price, book.BookDate, book.PatientId, book.DoctorId, book.RoomId,book.Perscription);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}