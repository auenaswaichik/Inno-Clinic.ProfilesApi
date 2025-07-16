using FluentValidation;

namespace Application.Admins.UseCases.DeleteAdmin;

public sealed class DeleteAdminCommandValidator : AbstractValidator<DeleteAdminCommand>
{
    public DeleteAdminCommandValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not suppose to be null");
    }
}