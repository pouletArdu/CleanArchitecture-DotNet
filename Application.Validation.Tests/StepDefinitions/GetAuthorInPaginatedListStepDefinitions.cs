namespace Application.Validation.Tests.StepDefinitions;

[Binding]
public class GetAuthorInPaginatedListStepDefinitions
{
    private readonly AuthorRepositoryMock _repository;
    private GetAuthorsInPaginatedListQuery _query;
    private int _size;
    private int _pageSize;
    private int _page;

    public GetAuthorInPaginatedListStepDefinitions()
    {
        _repository = (AuthorRepositoryMock)GetService<AuthorRepository>();
    }

    [Given(@"there is (.*) authors")]
    public async void GivenThereIsAuthors(int size)
    {
        _size = size;
        for (int i = 0; i < size; i++)
        {
            var author = Mock.Of<AuthorDTO>();
            author.Id = i;
            await _repository.Create(author);
        }
    }

    [When(@"i want to get the page (.*) with (.*) items")]
    public async void WhenIWantToGetThePageWithItems(int page, int pageSize)
    {
        _pageSize = pageSize;
        _page = page;

        _query = new GetAuthorsInPaginatedListQuery(page, pageSize);
    }

    [Then(@"I got the expected page")]
    public async void ThenIGotTheExpectedPage()
    {
        var result = await SendAsync(_query);
        result.Should().NotBeNull();
        result.TotalCount.Should().Be(_size);
        result.PageNumber.Should().Be(_page);
        result.Items.Count.Should().Be(_pageSize);
        result.HasNextPage.Should().BeTrue();
    }
}
