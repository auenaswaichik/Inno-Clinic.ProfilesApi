using Application.Specializations.Models;
using MediatR;

namespace Application.Specializations.UseCases.UpdateSpecialization;

public class UpdateSpecializationCommand : IRequest<SpecializationDTO>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}