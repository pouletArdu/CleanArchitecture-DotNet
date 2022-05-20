using Formation.Application.Authors.Queries.GetAllAuthors;
using Formation.Application.Books.Commands.DeleteBook;
using Formation.Application.Books.Queries.GetAll;
using Formation.Application.Common.Model;
using Formation.Blazor.Data;
using Formation.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Formation.Blazor.Pages;

public partial class Books
{
    [Parameter]
    public int PageNumber { get; set; }

    private Book book;
    private PaginatedList<Book> books;
    private List<AuthorDTO> authors;
    private int currentPage = 1;
    private int pageSize = 5;
    async protected override Task OnInitializedAsync()
    {
        book = new Book();
        await GetAllBooks();
        await GetAuthors();
    }

    async protected override Task OnParametersSetAsync()
    {
        if (PageNumber < 1) PageNumber = 1;
        currentPage = PageNumber;
        await GetAllBooks();
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
        var query = new GetBooksInPaginatedListQuery(currentPage, pageSize);
        var source = await Sender.Send(query);
        books = Mapper.Map<PaginatedList<Book>>(source);
        StateHasChanged();
    }

    private async Task GetAuthors()
    {
        authors = (await Sender.Send(new GetAuthorsInPaginatedListQuery(1, 100))).Items;
        StateHasChanged();
    }

    private async void ChangePagination(int size)
    {
        pageSize = size;
        currentPage = 1;
        await GetAllBooks();
    }

}
