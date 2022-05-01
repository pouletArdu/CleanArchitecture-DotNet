namespace Formation.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private BookRepository bookRepository;
        private AuthorRepository authorRepository;

        public CreateBookCommandValidator(BookRepository bookRepository, AuthorRepository authorRepository)
        {
            this.bookRepository = bookRepository;

            RuleFor(b => b.AuthorId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .MustAsync(AuthorShouldExist).WithMessage("This author is unknow");

            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title alredy exist");
            this.authorRepository = authorRepository;
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await bookRepository.GetByTitle(title) == null;
        }
        
        public async Task<bool> AuthorShouldExist(int id, CancellationToken cancellationToken)
        {
            return await authorRepository.GetById(id) == null;
        }
    }
}
