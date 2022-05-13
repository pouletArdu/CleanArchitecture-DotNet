namespace Formation.Application.Books.Queries.GetAll;

public class GetBooksInPaginatedListQuery : IRequest<PaginatedList<BookDTO>>
{
    public GetBooksInPaginatedListQuery()
    {
    }
    public GetBooksInPaginatedListQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}

public class GetBooksInPaginatedListQueryHandler : IRequestHandler<GetBooksInPaginatedListQuery, PaginatedList<BookDTO>>
{
    private readonly BookRepository BookRepository;

    public GetBooksInPaginatedListQueryHandler(BookRepository BookRepository)
    {
        this.BookRepository = BookRepository;
    }
    public async Task<PaginatedList<BookDTO>> Handle(GetBooksInPaginatedListQuery request, CancellationToken cancellationToken)
    {
        return await BookRepository.GetAll(request.PageNumber, request.PageSize);
    }
}
