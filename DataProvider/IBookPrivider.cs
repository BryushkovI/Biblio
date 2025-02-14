using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioContext.Model;

namespace DataProvider
{

    public interface IBookPrivider
    {
        public Task<IEnumerable<Book>> GetBooksAsync();

        public Task<Book> GetBookAsync(int? id);

        public Task CreateBookAsync(Book book);

        public Task UpdateBookAsync(Book book);

        public Task DeleteBookAsync(int? id);

        bool BookExists(int id);
    }

}
