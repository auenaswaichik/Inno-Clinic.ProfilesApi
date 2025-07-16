using FluentValidation;

namespace Application.Patients.UseCases.CreatePatient;

public sealed class CreatePatientCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public CreatePatientCommandValidator()
    {
        RuleFor(m => m.FirstName)
            .Length(2, 50)
            .WithMessage("Your name is not in the length range(from 2 to 50 symbols)");

        RuleFor(m => m.LastName)
            .Length(2, 50)
            .WithMessage("Your last name is not in the length range(from 2 to 50 symbols)");
    }
}