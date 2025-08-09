using CCMS.BLL.ModelVM.Book;
using CCMS.DAL.Repository.Abstraction;
using CCMS.BLL.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCMS.BLL.Services.Implementation
{
    public class BookService
    {
        private readonly IBookRepo _bookRepo;
        private readonly BookMapper _bookMapper;

        public BookService(IBookRepo bookRepo, BookMapper bookMapper)
        {
            _bookRepo = bookRepo;
            _bookMapper = bookMapper;
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return _bookMapper.ToDTOList(books);
        }
    }
}
