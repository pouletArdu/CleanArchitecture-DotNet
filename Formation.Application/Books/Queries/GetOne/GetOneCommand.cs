namespace Formation.Application.Books.Queries.GetOne
{
    public class GetOneCommand : IRequest<BookDTO>
    {
        public int Id { get; set; }

        public GetOneCommand(int id)
        {
            Id = id;
        }
    }

    public class GetOneCommandHandler : IRequestHandler<GetOneCommand, BookDTO>
    {
        readonly BookRepository _repository;

        public GetOneCommandHandler(BookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDTO> Handle(GetOneCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Id);
        }
    }
}
