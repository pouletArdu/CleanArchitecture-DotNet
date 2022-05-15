using Formation.Application.Books.Commands.CreateBook;

namespace Formation.Data;

public class Book
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }

    public CreateBookCommand ToCreateCommand() => new CreateBookCommand(Title, Description, AuthorId);
}