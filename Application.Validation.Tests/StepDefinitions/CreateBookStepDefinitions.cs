using static Application.Validation.Tests.Testing;
using ValidationException = Formation.Application.Common.Exceptions.ValidationException;

namespace Application.Validation.Tests.StepDefinitions;

[Binding]
public class CreateBookStepDefinitions
{
    private BookDTO _book = null!;
    private CreateBookCommand _command = null!;


    [Before]
    public void AfterAnyTest()
    {
        var repo = (BookRepositoryMock)GetService<BookRepository>();
        repo.Dispose();
    }

    [Given(@"I have a new book to add")]
    public void GivenIHaveANewBookToAdd()
    {
        _book = new BookDTO
        {
            Title = "Titre",
            Autor = new AuthorDTO
            {
                FirstName = "André"
            }
        };
    }

    [When(@"I add the book")]
    public async void WhenIAddTheBook()
    {
        _command = new CreateBookCommand(_book.Title,_book.Description,_book.Autor.Id);
        await SendAsync(_command);
    }

    [Then(@"The book is added")]
    public void ThenTheBookIsAdded()
    {
        var repository = (BookRepositoryMock)GetService<BookRepository>();
        var books = repository.GetAll().Result;
        Assert.AreEqual(books.First().Title, _book.Title);
        repository.Dispose();
    }

    [Given(@"I have a new book without title to add")]
    public void GivenIHaveANewBookWithoutTitleToAdd()
    {
        _book = new BookDTO
        {
            Autor = new AuthorDTO
            {
                FirstName = "André"
            },
            CreationDate = DateTime.Now
        };
    }

    [Given(@"a list of book :")]
    public async void GivenAListOfBook(Table table)
    {
        var repository = (BookRepositoryMock)GetService<BookRepository>();
        foreach (var row in table.Rows)
        {
            var (title, authorFirstName,_) = row.Values;
            await repository.Create(new BookDTO
            {
                Title = title,
                Autor = new AuthorDTO
                {
                    FirstName = authorFirstName
                },
                CreationDate = DateTime.Now
            }) ;
        }
    }

    [Given(@"I have a new book '([^']*)' to add")]
    public void GivenIHaveANewBookToAdd(string title)
    {
        _book = new BookDTO
        {
            Title = title,
            Autor = new AuthorDTO
            {
                FirstName = "Nathanaël"
            },
            CreationDate = DateTime.Now
        };
    }

    [When(@"I add the book to the validator")]
    public void WhenIAddTheBookToTheValidator()
    {
        _command = new CreateBookCommand(_book.Title, _book.Description, _book.Autor.Id);
    }

    [Then(@"An ValidationException is raised by the validator")]
    public async void ThenAnErrorIsRaisedByTheValidator()
    {
        await FluentActions.Invoking(() =>
                 SendAsync(_command)).Should().ThrowAsync<ValidationException>();
    }
}

