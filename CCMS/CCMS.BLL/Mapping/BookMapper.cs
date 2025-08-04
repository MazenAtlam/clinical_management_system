using Riok.Mapperly.Abstractions;
using CCMS.DAL.Entities;
using CCMS.BLL.ModelVM.Book;
using System.Collections.Generic;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class BookMapper
    {
        public partial BookDTO ToDTO(Book book);
        public partial List<BookDTO> ToDTOList(List<Book> books);
        // Reverse mapping
        public partial Book ToEntity(BookDTO dto);
        public partial List<Book> ToEntityList(List<BookDTO> dtos);
    }
}
