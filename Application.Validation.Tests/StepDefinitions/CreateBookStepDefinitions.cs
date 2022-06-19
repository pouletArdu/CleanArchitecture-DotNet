using ValidationException = Formation.Application.Common.Exceptions.ValidationException;

namespace Application.Validation.Tests.StepDefinitions;

[Binding]
public class CreateBookStepDefinitions
{
    private BookDTO _book = null!;
    private CreateBookCommand _command = null!;
    private BookRepositoryMock _bookRepository = null!;
    private AuthorRepositoryMock _authorRepository = null!;

    [Before]
    public void BeforeAnyTest()
    {
        _authorRepository = (AuthorRepositoryMock)GetService<AuthorRepository>();
        _bookRepository = (BookRepositoryMock)GetService<BookRepository>();
        _authorRepository.Dispose();
        _bookRepository.Dispose();
    }

    [After]
    public void AfterAnyTest()
    {
        _authorRepository.Dispose();
        _bookRepository.Dispose();
    }


    [Given(@"available authors are:")]
    public void GivenAvailableAuthorsAre(Table table)
    {
        var authors = table.CreateSet<AuthorDTO>();
        _authorRepository.AddRange(authors);
    }

    [Given(@"available Books are :")]
    public void GivenAvailableBooksAre(Table table)
    {
        var books = table.CreateSet<BookDTO>();
        _bookRepository.AddRange(books);
    }

    [Given(@"I have a new book to add :")]
    public void GivenIHaveANewBookToAdd(Table table)
    {
        _book = table.CreateInstance<BookDTO>();
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
        _command = new CreateBookCommand(_book.Title, _book.Description, _book.AuthorId);
        await SendAsync(_command);
    }

    [Then(@"The book is added")]
    public void ThenTheBookIsAdded()
    {
        var repository = (BookRepositoryMock)GetService<BookRepository>();
        var books = repository.GetAll().Result;
        Assert.NotNull(_bookRepository.GetByTitle(_book.Title));
    }

    [When(@"I add the book to the validator")]
    public void WhenIAddTheBookToTheValidator()
    {
        _command = new CreateBookCommand(_book.Title, _book.Description, _book.AuthorId);
    }

    [Then(@"An ValidationException is raised by the validator")]
    public async void ThenAnErrorIsRaisedByTheValidator()
    {
        await FluentActions.Invoking(() =>
                 SendAsync(_command)).Should().ThrowAsync<ValidationException>();
    }
}

