using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Formation.Application.Common.Model;

namespace Formation.Infrastructure.Repositories
{
    public class AuthorRepositoryImp : AuthorRepository
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public AuthorRepositoryImp(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Create(AuthorDTO item)
        {
            var entity = _mapper.Map<Author>(item);
            await _context.Authors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<AuthorDTO>> GetAll(int pageNumber, int pageSize)
        {
            var result = await _context.Authors.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = await _context.Authors.CountAsync();
            return new PaginatedList<AuthorDTO>(_mapper.Map<List<AuthorDTO>>(result),count,pageNumber,pageSize);
        }

        public async Task<AuthorDTO> GetById(int id)
        {
            var author =  await _context.Authors.FindAsync(id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public Task<AuthorDTO> Update(AuthorDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
