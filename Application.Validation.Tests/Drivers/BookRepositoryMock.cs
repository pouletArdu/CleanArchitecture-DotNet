using Formation.Application.Common.Model;

namespace Application.Validation.Tests.Drivers
{
    public class BookRepositoryMock : BookRepository, IDisposable
    {
        static readonly List<BookDTO> Books = new();

        public async Task<int> Create(BookDTO book)
        {
            Books.Add(book);
            return Books.Count() + 1;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            return Books;
        }

        public Task<PaginatedList<BookDTO>> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<BookDTO> GetById(int id)
        {
            return Books.FirstOrDefault(x => x.Id == id)!;
        }

        public async Task<BookDTO> GetByTitle(string title)
        {
            return Books.FirstOrDefault(x => x.Title == title)!;
        }

        internal void AddRange(IEnumerable<BookDTO> books) => Books.AddRange(books);

        public Task<BookDTO> Update(BookDTO book)
        {
            throw new NotImplementedException();
        }

        public Task Update(BookDTO item, int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Books.Clear();
        }
    }
}
