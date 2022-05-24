using Formation.Application.Common.Model;

namespace Formation.Infrastructure.Repositories
{
    public class AuthorRepositoryImp : AuthorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepositoryImp(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Create(AuthorDTO item)
        {
            var entity = _mapper.Map<Author>(item);
            await _context.Authors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var author = _context.Authors.Find(id);

            if (author == null) throw new NotFoundException();

            _context.Authors.Remove(author);

            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<AuthorDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<AuthorDTO>> GetAll(int pageNumber, int pageSize)
        {
            var result = await _context.Authors
                .Include(a => a.Books)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _context.Authors.CountAsync();
            return new PaginatedList<AuthorDTO>(_mapper.Map<List<AuthorDTO>>(result), count, pageNumber, pageSize);
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task Update(AuthorDTO item, int id)
        {
            var author = _context.Authors.Find(id);

            author.BirthDay = item.BirthDay;
            author.FirstName = item.FirstName;
            author.LastName = item.LastName;
            author.gender = item.Gender;

            await _context.SaveChangesAsync();
        }
    }
}
