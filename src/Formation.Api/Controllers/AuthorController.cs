global using Formation.Application.Common.Model;
using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Authors.Queries.GetAllAuthors;
using Formation.Domain.Entities;

namespace Formation.Api.Controllers;

public class AuthorController : ApiControllerBase
{
    [HttpPost]
    public async void Add(CreateAuthorCommand command)
    {
        _ = await
            Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<AuthorDTO>>> GetAll([FromQuery] GetAuthorsInPaginatedListQuery query)
    {
        return await Mediator.Send(query);
    }
}



