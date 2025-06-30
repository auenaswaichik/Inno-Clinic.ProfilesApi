using MediatR;

namespace Application.Doctors.UseCases.DeleteDoctor;

public class DeleteDoctorCommand : IRequest
{
    public Guid Id { get; set; }
}