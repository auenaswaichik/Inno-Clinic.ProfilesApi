using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using FluentValidation;
using MediatR;

namespace Application.Doctors.UseCases.DeleteDoctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeleteDoctorCommand> _validator;

    public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IValidator<DeleteDoctorCommand> validator)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Handle(DeleteDoctorCommand request, CancellationToken token)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Incorrect Id");
        }

        var doctor = await _doctorRepository.GetByIdAsync(request.Id, token);

        if (doctor is null)
        {
            throw new NotFoundException("There is no such doctor to delete");
        }

        _doctorRepository.Delete(doctor);
        await _unitOfWork.SaveAsync();
    }
}