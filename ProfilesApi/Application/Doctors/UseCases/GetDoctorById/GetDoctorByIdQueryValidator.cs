using FluentValidation;

namespace Application.Doctors.UseCases.GetDoctorById;

public sealed class GetDoctorByIdQueryValidator : AbstractValidator<GetDoctorByIdQuery>
{
    public GetDoctorByIdQueryValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not supposed to be empty");
    }
}