namespace Application.Validation.Tests.Drivers;

public class AuthorRepositoryMock : AuthorRepository
{
    List<AuthorDTO> Authors { get; set; }

    public AuthorRepositoryMock()
    {
        Authors = new List<AuthorDTO>();
    }

    public async Task<AuthorDTO> Create(AuthorDTO item)
    {
        Authors.Add(item);
        return item;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AuthorDTO>> GetAll()
    {
        return Authors;
    }

    public Task<AuthorDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AuthorDTO> Update(AuthorDTO book)
    {
        throw new NotImplementedException();
    }
}
