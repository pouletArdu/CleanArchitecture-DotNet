using static Application.Validation.Tests.Testing;

namespace Application.Validation.Tests.StepDefinitions;

[Binding]
public class AddAuthorStepDefinitions
{
    private AuthorDTO _author = null!;
    private CreateAuthorCommand _command = null;

    [Given(@"I have a new author to add")]
    public void GivenIHaveANewAuthorToAdd()
    {
        _author = new AuthorDTO();
    }

    [Given(@"his last name is ""([^""]*)""")]
    public void GivenHisLastNameIs(string foo)
    {
        _author.LastName = foo;
    }

    [Given(@"his first name is ""([^""]*)""")]
    public void GivenHisFirstNameIs(string bar)
    {
        _author.LastName = bar;
    }

    [Given(@"his birthDay  is ""([^""]*)""")]
    public void GivenHisBirthDayIs(string birthDay)
    {
        _author.BirthDay = DateTime.Parse(birthDay);
    }

    [When(@"I add the author")]
    public async void WhenIAddTheAuthor()
    {
        _command = new CreateAuthorCommand("John", "Doe", new DateTime(25, 04, 1985), Formation.Domain.Enums.Gender.Male);
        await SendAsync(_command);
    }

    [Then(@"The author is added")]
    public void ThenTheAuthorIsAdded()
    {
        var repository = (AuthorRepositoryMock)GetService<AuthorRepository>();
        var authors = repository.GetAll().Result;
        authors.Should().NotBeNull();
        authors.Should().HaveCount(1);
        var author = authors.First();
        author.FirstName.Should().Be(_author.FirstName);
        author.LastName.Should().Be(_author.LastName);
        author.BirthDay.Should().Be(_author.BirthDay);
    }

    private void MockTest()
    {
        var t = new Mock<AuthorDTO>();

    }
}
