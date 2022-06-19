namespace Formation.Application.Books.Commands.UpdateBook
{
    public class UpateBookCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; init; }
        public string? Description { get; init; }
        public int AuthorId { get; init; }
    }

    public class UpateBookCommandHandler : IRequestHandler<UpateBookCommand>
    {
        readonly IMapper _mapper;
        readonly BookRepository _bookRepository;

        public UpateBookCommandHandler(BookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpateBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.Update(_mapper.Map<BookDTO>(request), request.Id);
            return Unit.Value;
        }
    }
}
