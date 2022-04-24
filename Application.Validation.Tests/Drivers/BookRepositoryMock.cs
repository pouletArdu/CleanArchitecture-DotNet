namespace Application.Validation.Tests.Drivers
{
    public class BookRepositoryMock : BookRepository,IDisposable
    {
        List<Book> books;

        public BookRepositoryMock()
        {
            books = new List<Book>();
        }

        public async Task<Book> Create(Book book)
        {
            books.Add(book);
            return book;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            books.Clear();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return books;
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetByTitle(string title)
        {
            return books.FirstOrDefault(x => x.Title == title);
        }

        public Task<Book> Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
