using FluentValidation;

namespace Application.Specializations.UseCases.CreateSpecialization;

public sealed class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
{
    public CreateSpecializationCommandValidator()
    {
        RuleFor(m => m.Name)
            .Length(2, 50)
            .WithMessage("Your specialization name is not in the length range(from 2 to 50 symbols)");

        RuleFor(m => m.Description)
            .Length(10, 100)
            .WithMessage("Your description is not in the length range(from 10 to 100 symbols)");
    }
}