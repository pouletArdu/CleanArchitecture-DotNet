using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Authors.Commands.DeleteAuthor;
using Formation.Application.Authors.Queries.GetAllAuthors;
using Formation.Application.Common.Model;
using Microsoft.AspNetCore.Components;

namespace Formation.Pages
{
    public partial class Authors
    {
        [Parameter]
        public int PageNumber { get; set; }

        private Author author;
        private PaginatedList<Author> authors;
        private int currentPage = 1;
        private int pageSize = 5;


        async protected override Task OnInitializedAsync()
        {
            author = new Author();
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
            authors = Mapper.Map<PaginatedList<Author>>(source);
            StateHasChanged();
        }

        private async Task CreateNewAuthor()
        {
            //await Sender.Send(new CreateAuthorCommand(author.FirstName, author.LastName, author.BirthDay, author.Gender));
            await Sender.Send(Mapper.Map<CreateAuthorCommand>(author));
            author = new Author();
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