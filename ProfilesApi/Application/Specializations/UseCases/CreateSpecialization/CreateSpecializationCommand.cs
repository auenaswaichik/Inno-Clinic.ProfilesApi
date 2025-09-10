using Application.Specializations.Models;
using MediatR;

namespace Application.Specializations.UseCases.CreateSpecialization;

public class CreateSpecializationCommand : IRequest<SpecializationDTO>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}