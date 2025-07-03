using Application.Patients.Models;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Patients.UseCases.GetPatientById;

public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, PatientDTO>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IValidator<GetPatientByIdQuery> _validator;

    public GetPatientByIdHandler(IPatientRepository patientRepository, IValidator<GetPatientByIdQuery> validator)
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
            throw new NotFoundException("There is no such Patient to find");
        }

        return new PatientDTO(
                    patient.FirstName,
                    patient.LastName,
                    patient.DateBirth,
                    patient.ProfileId
                );
    }

}