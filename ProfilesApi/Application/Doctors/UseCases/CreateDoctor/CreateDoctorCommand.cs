using Application.Doctors.Models;
using MediatR;

namespace Application.Doctors.UseCases.CreateDoctor;

public class CreateDoctorCommand : IRequest<DoctorDTO>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public DateTime CareerStartYear { get; set; }
}