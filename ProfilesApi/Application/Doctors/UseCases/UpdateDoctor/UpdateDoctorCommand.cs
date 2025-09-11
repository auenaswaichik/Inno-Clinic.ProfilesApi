using Application.Doctors.Models;
using MediatR;

namespace Application.Doctors.UseCases.UpdateDoctor;

public class UpdateDoctorCommand : IRequest<DoctorDTO>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public DateTime DateBirth { get; set; }
    public DateTime CareerStartYear { get; set; }
    public Guid SpecializationId { get; set; }
    public Guid OfficeId { get; set; }

}