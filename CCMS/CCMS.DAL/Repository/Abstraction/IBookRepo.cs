using CCMS.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IBookRepo
    {
        Task<bool> CreateAsync(Book book);
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Book book, string modifiedBy);
    }
}