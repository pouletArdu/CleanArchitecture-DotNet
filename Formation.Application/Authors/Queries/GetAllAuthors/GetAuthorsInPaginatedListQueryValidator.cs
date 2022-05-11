namespace Formation.Application.Authors.Queries.GetAllAuthors
{
    public class GetAuthorsInPaginatedListQueryValidator : AbstractValidator<GetAuthorsInPaginatedListQuery>
    {
        public GetAuthorsInPaginatedListQueryValidator()
        {
            RuleFor(r => r.PageNumber)
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("PageNumber cannot be negative");
            RuleFor(r => r.PageSize)
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("PageSize cannot be negative");
        }
    }
}
