using Application.Patients.Models;
using MediatR;

namespace Application.Patients.UseCases.UpdatePatient;

public class UpdatePatientCommand : IRequest<PatientDTO>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
    public Guid ProfileId { get; set; }
}