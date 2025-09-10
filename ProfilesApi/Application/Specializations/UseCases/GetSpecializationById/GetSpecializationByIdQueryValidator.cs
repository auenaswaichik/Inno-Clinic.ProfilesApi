using FluentValidation;

namespace Application.Specializations.UseCases.GetSpecializationById;

public sealed class GetSpecializationByIdQueryValidator : AbstractValidator<GetSpecializationByIdQuery>
{
    public GetSpecializationByIdQueryValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not supposed to be empty");
    }
}