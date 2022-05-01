namespace Formation.Application.Repositories
{
    public interface BookRepository : GenericRepository<BookDTO>
    {
        Task<BookDTO> GetByTitle(string title);
    }
}
