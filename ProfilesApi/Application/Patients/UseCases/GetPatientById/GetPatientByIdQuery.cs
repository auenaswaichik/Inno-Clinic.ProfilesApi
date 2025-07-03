using Application.Patients.Models;
using MediatR;

namespace Application.Patients.UseCases.GetPatientById;

public class GetPatientByIdQuery : IRequest<PatientDTO>
{
    public Guid Id;
}