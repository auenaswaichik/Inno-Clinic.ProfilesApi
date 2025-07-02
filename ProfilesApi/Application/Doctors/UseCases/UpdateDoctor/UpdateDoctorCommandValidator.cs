using FluentValidation;

namespace Application.Doctors.UseCases.UpdateDoctor;

public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(m => m.FirstName)
            .Length(2, 50)
            .WithMessage("Your name is not in the length range(from 2 to 50 symbols)");

        RuleFor(m => m.LastName)
            .Length(2, 50)
            .WithMessage("Your last name is not in the length range(from 2 to 50 symbols)");
            
        RuleFor(m => m.DateBirth)
            .LessThan(DateTime.Now.AddYears(-27))
            .GreaterThan(DateTime.Now.AddYears(-700))
            .WithMessage("Incorrect date of birth");
            
        RuleFor(m => m.CareerStartYear)
            .LessThan(DateTime.Now)
            .GreaterThan(DateTime.Now.AddYears(-50))
            .WithMessage("Incorrect date of career start");
    }
}