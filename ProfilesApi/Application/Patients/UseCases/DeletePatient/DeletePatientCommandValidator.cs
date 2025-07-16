using FluentValidation;

namespace Application.Patients.UseCases.DeletePatient;

public sealed class DeletePatientCommandValidator : AbstractValidator<DeletePatientCommand>
{
    public DeletePatientCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not suppose to be null");
    }
}