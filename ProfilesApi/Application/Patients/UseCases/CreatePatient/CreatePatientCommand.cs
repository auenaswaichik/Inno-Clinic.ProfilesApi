using Application.Patients.Models;
using MediatR;

namespace Application.Patients.UseCases.CreatePatient;

public class CreatePatientCommand : IRequest<PatientDTO>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateBirth { get; set; }
}