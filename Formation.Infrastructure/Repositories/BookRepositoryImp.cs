using Formation.Application.Common.Model;

namespace Formation.Infrastructure.Repositories;

public class BookRepositoryImp : BookRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public BookRepositoryImp(ApplicationDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
    }

    public async Task<int> Create(BookDTO item)
    {
        var entity = _mapper.Map<Book>(item);
        entity.Author = _context.Authors.FirstOrDefault(a => a.Id == item.AutorId)!;
        await _context.Books.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(int id)
    {
        var book = _context.Books.Find(id);

        if (book == null) throw new NotFoundException(nameof(Application.Books), id);

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<BookDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<BookDTO>> GetAll(int pageNumber, int pageSize)
    {
        var result = await _context.Books
            .Include(a => a.Author)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var count = await _context.Books.CountAsync();
        return new PaginatedList<BookDTO>(_mapper.Map<List<BookDTO>>(result), count, pageNumber, pageSize);
    }

    public async Task<BookDTO> GetById(int id)
    {
        var book = await _context.Books.FindAsync(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task<BookDTO> GetByTitle(string title)
    {
        var book = await _context.Books.FirstOrDefaultAsync(f => f.Title == title);
        return _mapper.Map<BookDTO>(book);
    }

    public Task<BookDTO> Update(BookDTO item)
    {
        throw new NotImplementedException();
    }
}
