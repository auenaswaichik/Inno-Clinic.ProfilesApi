using FluentValidation;

namespace Application.Doctors.UseCases.DeleteDoctor;

public sealed class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
{
    public DeleteDoctorCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not suppose to be null");
    }
}