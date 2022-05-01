using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
