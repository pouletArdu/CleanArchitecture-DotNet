namespace Formation.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public CreateBookCommand(Book book)
        {
            Book = book;
        }

        public Book Book { get; }


    }

    public class CreateBookCommandHander : IRequestHandler<CreateBookCommand, Book>
    {
        private readonly BookRepository _bookRepository;

        public CreateBookCommandHander(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateBookCommandValidator(_bookRepository);
            //var validation = validator.Validate(request);
            //if (!validation.IsValid) throw new ArgumentException(validation.Errors.First()!.ErrorMessage);

            var book = _bookRepository.Create(request.Book);
            return book;
        }
    }
}
