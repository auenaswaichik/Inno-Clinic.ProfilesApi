using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Patients.UseCases.DeletePatient;

public sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeletePatientCommand> _validator;

    public DeletePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork, IValidator<DeletePatientCommand> validator)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(DeletePatientCommand request, CancellationToken token)
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

        _patientRepository.Delete(patient);
        await _unitOfWork.SaveAsync(token);
    }
}