namespace Formation.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public Author Author { get; set; }
        public CreateAuthorCommand(Author author)
        {
            Author = author;
        }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        public Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
