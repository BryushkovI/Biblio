using BiblioContext.Model;

namespace DataProvider
{
    public class BookProviderApi : IBookPrivider
    {
        public bool BookExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
