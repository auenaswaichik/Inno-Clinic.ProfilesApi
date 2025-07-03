using FluentValidation;

namespace Application.Patients.UseCases.GetPatientById;

public class GetPatientByIdQueryValidator : AbstractValidator<GetPatientByIdQuery>
{
    public GetPatientByIdQueryValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not supposed to be empty");
    }
}