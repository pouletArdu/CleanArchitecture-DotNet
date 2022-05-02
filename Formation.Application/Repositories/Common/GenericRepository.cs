namespace Formation.Application.Repositories.Common
{
    public interface GenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T item);
        Task<T> GetById(int id);
        Task<PaginatedList<T>> GetAll(int pageNumber, int pageSize);
        Task<T> Update(T item);
        Task Delete(int id);
    }
}
