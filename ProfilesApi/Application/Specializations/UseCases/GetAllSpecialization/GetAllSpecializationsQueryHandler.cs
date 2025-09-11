using MediatR;
using Domain.Interfaces.IRepositories;
using Application.Specializations.Models;

namespace Application.Specializations.UseCases.GetAllSpecializations;

public sealed class GetAllSpecializationsQueryHandler : IRequestHandler<GetAllSpecializationsQuery, List<SpecializationDTO>>
{
    private readonly ISpecializationRepository _specializationRepository;

    public GetAllSpecializationsQueryHandler(ISpecializationRepository specializationRepository)
    {
        _specializationRepository = specializationRepository;
    }

    public async Task<List<SpecializationDTO>> Handle(GetAllSpecializationsQuery request, CancellationToken token)
    {
        var parameters = request.SpecializationParameters ?? new Domain.Entities.Parameters.SpecializationParameters();
        var specializationsList = await _specializationRepository.GetSpecializationsAsync(parameters, token);

        return specializationsList
            .Select(m =>
                new SpecializationDTO(
                    m.Id,
                    m.Name,
                    m.Description,
                    m.Doctors.Select(d => d.FirstName).ToList()
                ))
            .ToList();
    }
}