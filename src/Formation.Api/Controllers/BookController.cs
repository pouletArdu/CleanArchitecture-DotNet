using Formation.Application.Books.Commands.CreateBook;
using Formation.Application.Books.Commands.DeleteBook;
using Formation.Application.Books.Queries.GetAll;

namespace Formation.Api.Controllers;

public class BookController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Add(CreateBookCommand command)
    {
        return await
            Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<BookDTO>>> GetAll([FromQuery] GetBooksInPaginatedListQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteBookCommand(id));
        return NoContent();
    }

}
