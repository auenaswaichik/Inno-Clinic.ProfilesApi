using MediatR;

namespace Application.Patients.UseCases.DeletePatient;

public class DeletePatientCommand : IRequest
{
    public Guid Id { get; set; }
}