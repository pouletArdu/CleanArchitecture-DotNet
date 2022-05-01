namespace Application.Validation.Tests.Drivers
{
    public class BookRepositoryMock : BookRepository,IDisposable
    {
        List<BookDTO> books;

        public BookRepositoryMock()
        {
            books = new List<BookDTO>();
        }

        public async Task<BookDTO> Create(BookDTO book)
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

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            return books;
        }

        public Task<BookDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDTO> GetByTitle(string title)
        {
            return books.FirstOrDefault(x => x.Title == title);
        }

        public Task<BookDTO> Update(BookDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
