using Formation.Domain.Events;

namespace Formation.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public CreateAuthorCommand(string firstName, string lastName, DateTime birthDay, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDay = birthDay;
            Gender = gender;
        }

        public CreateAuthorCommand()
        {
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDay { get; init; }
        public Gender Gender { get; init; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly AuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(AuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {

            var dto = _mapper.Map<AuthorDTO>(request);
            dto.DomainEvents.Add(new AuthorCreatedEvent(dto));

            return await _authorRepository.Create(dto);
        }
    }
}
