using Domain.Exceptions;
using Domain.Interfaces.IRepositories;
using MediatR;

namespace Application.Doctors.UseCases.DeleteDoctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteDoctorCommand request, CancellationToken token)
    {
        var validations = new DeleteDoctorCommandValidator();
        var valRes = validations.Validate(request);

        if (!valRes.IsValid)
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