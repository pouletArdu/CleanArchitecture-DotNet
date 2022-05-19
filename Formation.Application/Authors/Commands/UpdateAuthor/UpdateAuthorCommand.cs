namespace Formation.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

        public UpdateAuthorCommand()
        {
        }
    }
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly AuthorRepository _repository;
        public IMapper _mapper { get; }

        public UpdateAuthorCommandHandler(AuthorRepository repository, IMapper mapper)
            => (_repository, _mapper) = (repository, mapper);

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.Update(_mapper.Map<AuthorDTO>(request), request.Id);
            return Unit.Value;
        }
    }
}
