
using Formation.Application.Books.Commands.CreateBook;

namespace Formation.Api.Controllers
{
    public class BookController : ApiControllerBase
    {
        [HttpPost]
        public async void Add(CreateBookCommand command)
        {
            _ =  await 
                Mediator.Send(command);
        }
    }
}
