using Application.Patients.Models;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Patients.UseCases.GetPatientById;

public sealed class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDTO>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IValidator<GetPatientByIdQuery> _validator;

    public GetPatientByIdQueryHandler(IPatientRepository patientRepository, IValidator<GetPatientByIdQuery> validator)
    {
        _patientRepository = patientRepository;
        _validator = validator;
    }

    public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var patient = await _patientRepository.GetByIdAsync(request.Id, token);

        if (patient is null)
        {
            throw new NotFoundException($"Patient with id: {request.Id} doesn't exist");
        }

        return new PatientDTO(
                    patient.FirstName,
                    patient.LastName,
                    patient.DateBirth
                );
    }

}