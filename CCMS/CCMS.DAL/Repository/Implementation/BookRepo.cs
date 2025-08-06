using CCMS.DAL.Database;
using CCMS.DAL.Entities;
using CCMS.DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Implementation
{
    public class BookRepo : IBookRepo
    {
        private readonly CcmsDbContext db;

        public BookRepo(CcmsDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> CreateAsync(Book book)
        {
            try
            {
                await db.books.AddAsync(book);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var book = await db.books.FirstOrDefaultAsync(a => a.Id == id);
                if (book == null)
                    return false;
                book.Delete("admin");
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await db.books.Where(a => a.IsDeleted == false).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await db.books.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            try
            {
                var b = await db.books.FirstOrDefaultAsync(a => a.Id == book.Id);
                if (b == null)
                    return false;
                b.Edit(book.price, book.BookDate, book.PatientId, book.DoctorId, book.RoomId, book.Perscription);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}