using Formation.Domain.Enums;

namespace Application.Validation.Tests.StepDefinitions;

[Binding]
public class AddAuthorStepDefinitions
{
    private AuthorDTO _author = null!;
    private CreateAuthorCommand _command = null!;

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

    [Given(@"his Geder is ""([^""]*)""")]
    public void GivenHisGederIs(string male)
    {
        if (Enum.TryParse<Gender>(male, out var gender))
        {
            _author.Gender = gender;
        }
    }


    [Given(@"his birthDay  is ""([^""]*)""")]
    public void GivenHisBirthDayIs(string birthDay)
    {
        _author.Birthday = DateTime.Parse(birthDay);
    }

    [When(@"I add the author")]
    public async void WhenIAddTheAuthor()
    {
        _command = new CreateAuthorCommand(_author.FirstName, _author.LastName, _author.Birthday, _author.Gender);
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
        author.Birthday.Should().Be(_author.Birthday);
    }
}
