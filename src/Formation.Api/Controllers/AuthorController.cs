global using Formation.Application.Common.Model;
using Formation.Application.Authors.Commands.CreateAuthor;
using Formation.Application.Authors.Commands.DeleteAuthor;
using Formation.Application.Authors.Commands.UpdateAuthor;
using Formation.Application.Authors.Queries.GetAllAuthors;

namespace Formation.Api.Controllers;

public class AuthorController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Add(CreateAuthorCommand command)
    {
        return await
            Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<AuthorDTO>>> GetAll([FromQuery] GetAuthorsInPaginatedListQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteAuthorCommand(id));
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateAuthorCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}



