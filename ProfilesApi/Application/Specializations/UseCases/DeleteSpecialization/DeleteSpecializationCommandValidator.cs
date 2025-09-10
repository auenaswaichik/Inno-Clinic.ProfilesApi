using FluentValidation;

namespace Application.Specializations.UseCases.DeleteSpecialization;

public sealed class DeleteSpecializationCommandValidator : AbstractValidator<DeleteSpecializationCommand>
{
    public DeleteSpecializationCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not suppose to be null");
    }
}