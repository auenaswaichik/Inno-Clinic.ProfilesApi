using Domain.Entities;
using MediatR;

namespace Application.Doctors.Commands.CreateDoctor;

public class CreateDoctorCommand : IRequest<Doctor>
{
    public string? DoctorFirstName { get; set; }
    public string? DoctorMiddleName { get; set; }
    public string? DoctorLastName { get; set; }
    public DateTime DoctorDateBirth { get; set; }
    public DateTime DoctorCareerStartYear { get; set; }

}