namespace Formation.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private BookRepository bookRepository;
        
        public CreateBookCommandValidator(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;

            RuleFor(b => b.Book.Autor)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(b => b.Book.Title)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .MustAsync(BeUniqueTitle).WithMessage("The specified title alredy exist");                
        }

        public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await bookRepository.GetByTitle(title) == null;
        }
        
    }
}
