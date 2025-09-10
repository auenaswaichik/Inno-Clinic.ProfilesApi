using Application.Specializations.Models;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Specializations.UseCases.GetSpecializationById;

public sealed class GetSpecializationByIdQueryHandler : IRequestHandler<GetSpecializationByIdQuery, SpecializationDTO>
{
    private readonly ISpecializationRepository _specializationRepository;
    private readonly IValidator<GetSpecializationByIdQuery> _validator;

    public GetSpecializationByIdQueryHandler(ISpecializationRepository specializationRepository, IValidator<GetSpecializationByIdQuery> validator)
    {
        _specializationRepository = specializationRepository;
        _validator = validator;
    }

    public async Task<SpecializationDTO> Handle(GetSpecializationByIdQuery request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var specialization = await _specializationRepository.GetByIdAsync(request.Id, token);

        if (specialization is null)
        {
            throw new NotFoundException($"Specialization with id: {request.Id} doesn't exist");
        }

        return new SpecializationDTO(
                    specialization.Id,
                    specialization.Name,
                    specialization.Description,
                    specialization.Doctors.Select(d => d.FirstName).ToList()
                );
    }

}