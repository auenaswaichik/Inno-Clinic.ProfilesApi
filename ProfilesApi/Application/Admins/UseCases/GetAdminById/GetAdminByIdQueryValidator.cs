using FluentValidation;

namespace Application.Admins.UseCases.GetAdminById;

public class GetAdminByIdQueryValidator : AbstractValidator<GetAdminByIdQuery>
{
    public GetAdminByIdQueryValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not supposed to be empty");
    }
}