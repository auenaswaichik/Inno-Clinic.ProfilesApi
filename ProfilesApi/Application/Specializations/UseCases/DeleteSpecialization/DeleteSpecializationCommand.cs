using MediatR;

namespace Application.Specializations.UseCases.DeleteSpecialization;

public class DeleteSpecializationCommand : IRequest
{
    public Guid Id { get; set; }
}