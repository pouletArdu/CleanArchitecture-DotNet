using Formation.Application.Common.Model;

namespace Application.Validation.Tests.Drivers;

public class AuthorRepositoryMock : AuthorRepository, IDisposable
{
    static readonly List<AuthorDTO> Authors = new();

    public async Task<int> Create(AuthorDTO item)
    {
        await Task.Yield();
        Authors.Add(item);
        return item.Id;
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<AuthorDTO>> GetAll()
    {
        await Task.Yield();
        return Authors;
    }

    public async Task<AuthorDTO> GetById(int id)
    {
        await Task.Yield();
        return Authors.FirstOrDefault(x => x.Id == id)!;
    }

    public Task Update(AuthorDTO book, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginatedList<AuthorDTO>> GetAll(int pageNumber, int pageSize)
    {
        await Task.Yield();
        var count = Authors.Count();

        return new PaginatedList<AuthorDTO>(
            Authors.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
            count,
            pageNumber,
            pageSize);
    }

    public void AddRange(IEnumerable<AuthorDTO> authors) => Authors.AddRange(authors);

    public void Dispose()
    {
        Authors.Clear();
    }
}
