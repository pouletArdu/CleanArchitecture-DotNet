namespace Formation.Application.Authors.Queries.GetAllAuthors
{
    public class GetAuthorsInPaginatedListQuery : IRequest<PaginatedList<AuthorDTO>>
    {
        public GetAuthorsInPaginatedListQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; }
        public int PageSize { get; }
    }

    public class GetAuthorsInPaginatedListQueryHandler : IRequestHandler<GetAuthorsInPaginatedListQuery, PaginatedList<AuthorDTO>>
    {
        private readonly AuthorRepository authorRepository;

        public GetAuthorsInPaginatedListQueryHandler(AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public async Task<PaginatedList<AuthorDTO>> Handle(GetAuthorsInPaginatedListQuery request, CancellationToken cancellationToken)
        {
            return await authorRepository.GetAll(request.PageNumber,request.PageSize);
        }
    }
}
