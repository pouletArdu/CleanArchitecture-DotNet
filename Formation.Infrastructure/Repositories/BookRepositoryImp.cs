using Formation.Application.Common.Model;

namespace Formation.Infrastructure.Repositories;

public class BookRepositoryImp : BookRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public BookRepositoryImp(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<BookDTO> Create(BookDTO item)
    {
        var entity = _mapper.Map<Book>(item);
        entity.Author = _dbContext.Authors.FirstOrDefault(a => a.Id == item.AutorId)!;
        await _dbContext.Books.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BookDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedList<BookDTO>> GetAll(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task<BookDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<BookDTO> GetByTitle(string title)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(f => f.Title == title);
        return _mapper.Map<BookDTO>(book);
    }

    public Task<BookDTO> Update(BookDTO item)
    {
        throw new NotImplementedException();
    }
}
