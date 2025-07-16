using System.Text;
using Application.Patients.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Patients.UseCases.CreatePatient;

public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDTO>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreatePatientCommand> _validator;

    public CreatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IValidator<CreatePatientCommand> validator)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<PatientDTO> Handle(CreatePatientCommand request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            var stringBuilder = new StringBuilder();

            foreach (var error in validationResult.Errors)
            {
                stringBuilder.AppendLine(error.ErrorMessage);
            }

            throw new BadRequestException(stringBuilder.ToString());
        }

        var patient = new Patient()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth
        };

        var createdPatient = _patientRepository.Insert(patient);
        await _unitOfWork.SaveAsync(token);

        return new PatientDTO(
                    createdPatient.FirstName,
                    createdPatient.LastName,
                    createdPatient.DateBirth,
                    createdPatient.ProfileId
                );
    }
}