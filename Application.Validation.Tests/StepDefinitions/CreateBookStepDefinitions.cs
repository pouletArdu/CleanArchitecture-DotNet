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
        BookDTO.CreateBuilder()
            .WithTitle("Title")
            .WithAuthorId(1)
            .WithDescription("Description");
    }

    [Given(@"I had alredy register the Author")]
    public async void GivenIHadAlredyRegisterTheAuthor()
    {
        var repository = (AuthorRepositoryMock)GetService<AuthorRepository>();
        await repository.Create(Mock.Of<AuthorDTO>(x => x.Id == 1 && x.FirstName == "Pop le POPA"));
    }


    [When(@"I add the book")]
    public async void WhenIAddTheBook()
    {
        _command = new CreateBookCommand(_book.Title, _book.Description, _book.AutorId);
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
        BookDTO.CreateBuilder()
            .WithAuthorId(1)
            .Build();
    }

    [Given(@"a list of book :")]
    public async void GivenAListOfBook(Table table)
    {
        var repository = (BookRepositoryMock)GetService<BookRepository>();
        foreach (var row in table.Rows)
        {
            var (title, authorFirstName, _) = row.Values;
            await repository.Create(
                BookDTO.CreateBuilder()
                .WithAuthorId(0)
                .WithTitle(title)
                .Build());
        }
    }

    [Given(@"I have a new book '([^']*)' to add")]
    public void GivenIHaveANewBookToAdd(string title)
    {
        _book = BookDTO.CreateBuilder()
            .WithTitle(title)
            .WithAuthorId(1)
            .Build();
    }

    [When(@"I add the book to the validator")]
    public void WhenIAddTheBookToTheValidator()
    {
        _command = new CreateBookCommand(_book.Title, _book.Description, _book.Author.Id);
    }

    [Then(@"An ValidationException is raised by the validator")]
    public async void ThenAnErrorIsRaisedByTheValidator()
    {
        await FluentActions.Invoking(() =>
                 SendAsync(_command)).Should().ThrowAsync<ValidationException>();
    }
}

