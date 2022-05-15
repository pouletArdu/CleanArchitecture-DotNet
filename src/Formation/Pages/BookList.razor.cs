using Formation.Application.Authors.Queries.GetAllAuthors;
using Formation.Application.Books.Commands.DeleteBook;
using Formation.Application.Books.Queries.GetAll;
using Formation.Domain.Entities;

namespace Formation.Pages;

public partial class BookList
{
    private Book book;
    private List<BookDTO> books;
    private List<AuthorDTO> authors;
    async protected override Task OnInitializedAsync()
    {
        book = new Book();
        await GetAllBooks();
        await GetAuthors();
    }

    private async Task CreateNewBook()
    {
        await Sender.Send(book.ToCreateCommand());
        book = new Book();
        await GetAllBooks();
    }

    private async Task RemoveBook(int id)
    {
        await Sender.Send(new DeleteBookCommand(id));
        await GetAllBooks();
    }

    private async Task GetAllBooks()
    {
        books = (await Sender.Send(new GetBooksInPaginatedListQuery(1, 10))).Items;
        StateHasChanged();
    }

    private async Task GetAuthors()
    {
        authors = (await Sender.Send(new GetAuthorsInPaginatedListQuery(1, 10))).Items;
        StateHasChanged();
    }
}
