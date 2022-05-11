namespace Formation.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; init; }
        public DeleteAuthorCommand()
        {
        }

        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly AuthorRepository _repository;

        public DeleteAuthorCommandHandler(AuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
