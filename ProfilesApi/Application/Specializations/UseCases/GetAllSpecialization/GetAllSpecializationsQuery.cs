using Application.Specializations.Models;
using Domain.Entities.Parameters;
using MediatR;

namespace Application.Specializations.UseCases.GetAllSpecializations;

public class GetAllSpecializationsQuery : IRequest<List<SpecializationDTO>>
{
    public SpecializationParameters SpecializationParameters { get; set; }
}