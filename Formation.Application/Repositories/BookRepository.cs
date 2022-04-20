namespace Formation.Application.Repositories
{
    public interface BookRepository : GenericRepository<Book>
    {
        Task<Book> GetByTitle(string title);
    }
}
