namespace Formation.Application.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<BookDTO>
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

public class CreateBookCommandHander : IRequestHandler<CreateBookCommand, BookDTO>
{
    private readonly BookRepository _bookRepository;
    private readonly AuthorRepository _authorRepository;

    public CreateBookCommandHander(BookRepository bookRepository, AuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<BookDTO> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.Create(new BookDTO
        {
            Title = request.Title,
            Description = request.Description,
            AutorId = request.AuthorId
        });

        return book;
    }
}
