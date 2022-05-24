namespace Formation.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a => a.Id)
                .NotNull().WithMessage("Id could not be null")
                .GreaterThan(0).WithMessage("Id should be greater than 0");
        }
    }
}
