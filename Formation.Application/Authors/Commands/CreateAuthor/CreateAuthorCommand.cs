namespace Formation.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<AuthorDTO>
    {
        public CreateAuthorCommand(string firstName, string lastName, DateTime birthDay, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Gender = gender;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDay { get; init; }
        public Gender Gender { get; init; }
            }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorDTO>
    {
        private AuthorRepository _authorRepository;

        public CreateAuthorCommandHandler(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<AuthorDTO> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            return _authorRepository.Create(new AuthorDTO {
            BirthDay = request.BirthDay});
        }
    }
}
