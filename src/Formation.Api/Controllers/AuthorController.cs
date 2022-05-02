using Formation.Application.Authors.Commands.CreateAuthor;
namespace Formation.Api.Controllers
{
    public class AuthorController : ApiControllerBase
    {
        [HttpPost]
        public async void Add(CreateAuthorCommand command)
        {
            _ = await
                Mediator.Send(command);
        }
    }
}
