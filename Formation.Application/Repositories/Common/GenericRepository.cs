namespace Formation.Application.Repositories.Common
{
    public interface GenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> Create(T item);
        Task<T> GetById(int id);
        Task<PaginatedList<T>> GetAll(int pageNumber, int pageSize);
        Task Update(T item, int id);
        Task Delete(int id);
    }
}
