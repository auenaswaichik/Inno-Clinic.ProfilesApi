using Application.Specializations.Models;
using MediatR;

namespace Application.Specializations.UseCases.GetSpecializationById;

public class GetSpecializationByIdQuery : IRequest<SpecializationDTO>
{
    public Guid Id{ get; set; }
}