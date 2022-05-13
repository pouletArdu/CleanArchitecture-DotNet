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
            //return _authorRepository.Create(new AuthorDTO
            //{
            //    BirthDay = request.BirthDay,
            //    FirstName = request.FirstName,
            //    LastName = request.LastName,
            //    gender = request.Gender,
            //    CreationDate = DateTime.Now,
            //    ModificationDate = DateTime.Now
            //});
            return await _authorRepository.Create(_mapper.Map<AuthorDTO>(request));
        }
    }
}
