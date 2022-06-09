namespace Formation.Application.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<int>
{
    public string Title { get; init; }
    public string? Description { get; init; }
    public int AuthorId { get; init; }

    public CreateBookCommand(string title, string? description, int authorId)
    {
        Title = title;
        Description = description;
        AuthorId = authorId;
    }
}

public class CreateBookCommandHander : IRequestHandler<CreateBookCommand, int>
{
    private readonly BookRepository _bookRepository;

    public CreateBookCommandHander(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        return await _bookRepository.Create(
            BookDTO.CreateBuilder()
            .WithAuthorId(request.AuthorId)
            .WithDescription(request.Description)
            .WithTitle(request.Title)
            .Build()
            );
    }
}
