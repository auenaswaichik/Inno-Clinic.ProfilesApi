using FluentValidation;

namespace Application.Doctors.Commands.CreateDoctor;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{

    public CreateDoctorCommandValidator()
    {
        RuleFor(m => m.DoctorFirstName)
            .Length(2, 50)
            .WithMessage("Your name is not in the length range(from 2 to 50 symbols)");
        RuleFor(m => m.DoctorMiddleName)
            .Length(2, 50)
            .WithMessage("Your middle name is not in the length range(from 2 to 50 symbols)");
        RuleFor(m => m.DoctorLastName)
            .Length(2, 50)
            .WithMessage("Your last name is not in the length range(from 2 to 50 symbols)");
        RuleFor(m => m.DoctorDateBirth)
            .GreaterThan(DateTime.Now)
            .LessThan(DateTime.Now.AddYears(-100))
            .WithMessage("Incorrect date of birth");
        RuleFor(m => m.DoctorCareerStartYear)
            .GreaterThan(DateTime.Now)
            .LessThan(DateTime.Now.AddYears(-100))
            .WithMessage("Incorrect date of career start");
    }

}