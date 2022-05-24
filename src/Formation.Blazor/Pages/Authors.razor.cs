using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Authors.Commands.DeleteAuthor;
using Formation.Application.Authors.Queries.GetAllAuthors;
using Formation.Application.Common.Model;
using Microsoft.AspNetCore.Components;
using AuthorModel = Formation.Blazor.Data.Author;

namespace Formation.Blazor.Pages
{
    public partial class Authors
    {
        [Parameter]
        public int PageNumber { get; set; }

        private AuthorModel author;
        private PaginatedList<AuthorModel> authors;
        private int currentPage = 1;
        private int pageSize = 5;


        async protected override Task OnInitializedAsync()
        {
            author = new AuthorModel();
            await GetAllAuthors();
        }
        async protected override Task OnParametersSetAsync()
        {
            if (PageNumber < 1) PageNumber = 1;
            currentPage = PageNumber;
            await GetAllAuthors();
        }
        private async Task GetAllAuthors()
        {
            var query = new GetAuthorsInPaginatedListQuery(currentPage, pageSize);
            var source = await Sender.Send(query);
            authors = Mapper.Map<PaginatedList<AuthorModel>>(source);
            StateHasChanged();
        }

        private async Task CreateNewAuthor()
        {
            await Sender.Send(Mapper.Map<CreateAuthorCommand>(author));
            author = new AuthorModel();
            await GetAllAuthors();
        }

        private async void ChangePagination(int size)
        {
            pageSize = size;
            currentPage = 1;
            await GetAllAuthors();
        }

        private async Task RemoveAuthor(int id)
        {
            await Sender.Send(new DeleteAuthorCommand(id));
            await GetAllAuthors();
        }
    }
}