namespace Formation.Application.Authors.Queries.GetOneAuthor
{
    public class GetOneCommand : IRequest<AuthorDTO>
    {
        public int Id { get; set; }

        public GetOneCommand(int id)
        {
            Id = id;
        }
    }
    public class Handler : IRequestHandler<GetOneCommand, AuthorDTO>
    {
        readonly AuthorRepository repository;

        public Handler(AuthorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AuthorDTO> Handle(GetOneCommand request, CancellationToken cancellationToken)
        {
            return await repository.GetById(request.Id);
        }
    }
}
