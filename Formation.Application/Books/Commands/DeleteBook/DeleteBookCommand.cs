namespace Formation.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; init; }
        public DeleteBookCommand()
        {
        }

        public DeleteBookCommand(int id)
        {
            Id = id;
        }

    }
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private BookRepository _bookRepository;

        public DeleteBookCommandHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _bookRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}
