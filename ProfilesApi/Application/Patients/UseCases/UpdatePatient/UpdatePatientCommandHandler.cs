using System.Text;
using Application.Patients.Models;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Patients.UseCases.UpdatePatient;

public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientDTO>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdatePatientCommand> _validator;

    public UpdatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IValidator<UpdatePatientCommand> validator)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<PatientDTO> Handle(UpdatePatientCommand request, CancellationToken token)
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
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateBirth = request.DateBirth
        };

        var updatedPatient = _patientRepository.Update(patient);
        await _unitOfWork.SaveAsync(token);

        return new PatientDTO(
                    updatedPatient.Id,
                    updatedPatient.FirstName,
                    updatedPatient.LastName,
                    updatedPatient.DateBirth
                );
    }
}