using Formation.Application.Common.Model;

namespace Application.Validation.Tests.Drivers
{
    public class BookRepositoryMock : BookRepository, IDisposable
    {
        readonly List<BookDTO> books;

        public BookRepositoryMock()
        {
            books = new List<BookDTO>();
        }

        public async Task<int> Create(BookDTO book)
        {
            books.Add(book);
            return books.Count() + 1;
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

        public Task<PaginatedList<BookDTO>> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDTO> GetById(int id)
        {
            return books.FirstOrDefault(x => x.Id == id)!;
        }

        public async Task<BookDTO> GetByTitle(string title)
        {
            return books.FirstOrDefault(x => x.Title == title)!;
        }

        public Task<BookDTO> Update(BookDTO book)
        {
            throw new NotImplementedException();
        }
    }
}
