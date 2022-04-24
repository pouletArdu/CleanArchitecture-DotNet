namespace Application.Validation.Tests.StepDefinitions;

using static Testing;
using ValidationException = Formation.Application.Common.Exceptions.ValidationException;

[Binding]
public class CreateBookStepDefinitions
{
    private Book _book;
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
        _book = new Book
        {
            Title = "Titre",
            Autor = new Author
            {
                FirstName = "André"
            }
        };
    }

    [When(@"I add the book")]
    public async void WhenIAddTheBook()
    {
        _command = new CreateBookCommand(_book);
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
        _book = new Book
        {
            Autor = new Author
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
            await repository.Create(new Book
            {
                Title = row[0],
                Autor = new Author
                {
                    FirstName = row[1]
                },
                CreationDate = DateTime.Now
            });
        }
    }

    [Given(@"I have a new book '([^']*)' to add")]
    public void GivenIHaveANewBookToAdd(string title)
    {
        _book = new Book
        {
            Title = title,
            Autor = new Author
            {
                FirstName = "Nathanaël"
            },
            CreationDate = DateTime.Now
        };
    }

    [When(@"I add the book to the validator")]
    public void WhenIAddTheBookToTheValidator()
    {
        _command = new CreateBookCommand(_book);
    }

    [Then(@"An ValidationException is raised by the validator")]
    public async void ThenAnErrorIsRaisedByTheValidator()
    {
        await FluentActions.Invoking(() =>
                 SendAsync(_command)).Should().ThrowAsync<ValidationException>();
    }
}

