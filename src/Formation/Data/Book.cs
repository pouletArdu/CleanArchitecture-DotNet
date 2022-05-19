using Formation.Application.Books.Commands.CreateBook;
using Formation.Data.Common;

namespace Formation.Data;

public class Book : Paginated
{
    [Data("Titre", 1)]
    public string Title { get; set; }

    [Data("Description", 3)]
    public string? Description { get; set; }

    [Data("Auteur", 2)]
    public string Name { get => $"{Author.FirstName} {Author.LastName}"; }

    public int Id { get; set; }

    public int AuthorId { get; set; }

    public Author Author { get; set; }

    public Book()
    {

    }
    public CreateBookCommand ToCreateCommand() => new CreateBookCommand(Title, Description, AuthorId);
}