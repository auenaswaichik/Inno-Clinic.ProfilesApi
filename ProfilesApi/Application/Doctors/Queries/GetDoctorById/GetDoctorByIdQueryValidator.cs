using FluentValidation;

namespace Application.Doctors.Queries.GetDoctorById;

public class GetDoctorByIdQueryValidator : AbstractValidator<GetDoctorByIdQuery>
{

    public GetDoctorByIdQueryValidator()
    {
        RuleFor(m => m.Id)
            .NotEmpty()
            .WithMessage("Id is not supposed to be empty");
    }

}