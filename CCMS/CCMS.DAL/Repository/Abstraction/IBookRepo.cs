using CCMS.DAL.Entities;
using System.Collections.Generic;

namespace CCMS.DAL.Repository.Abstraction
{
    public interface IBookRepo
    {
        bool Create(Book book);
        Book GetById(int id);
        List<Book> GetAll();
        bool Delete(int id);
        bool Update(Book book);
    }
}